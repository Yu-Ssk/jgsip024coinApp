/// <summary>
/// IP024Coinクラス
/// </summary>
/// <author>
/// Yu Sasaki, Jiei Kimura
/// </author>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBitcoin;
using QBitNinja.Client;
using QBitNinja.Client.Models;
using System.IO;
using System.Diagnostics;

namespace jgsip024coinApp
{
    class jgsip024coinClass
    {
        private static string logFileName = "executed_tx.log";
        public static string[] GeneratePrivateKeyAndAddress()
        {
            string[] address;
            address = new string[10];

            for (int i = 0; i < 10; i++)
            {
                // 秘密鍵、公開鍵、ビットコインアドレスを生成して内容を確認する
                var privateKey = new Key();
                PubKey publicKey = privateKey.PubKey;
                // Mainnet or Testnet
                var bitcoinPrivateKey = privateKey.GetWif(Network.TestNet); // Testnetにしておく
                address[i] = bitcoinPrivateKey + " : " + publicKey + " : " + publicKey.GetAddress(Network.TestNet).ToString();
            }
            return address;
        }

        public static string[] GetBalance(string bitAddr, string placeFlag)
        {
            string[] BalanceText;
            BalanceText = new string[4];
            long Balance = 0;
            long CumulativeTotalByAct = 0;

            // 色別残高計算
            long BalanceByPay = 0;
            long BalanceByIssue = 0;
            long BalanceByAct = 0;

            // 対象エリア外ボーナス
            Boolean inTargetArea = false;
            List<long> bonusCoin = new List<long>();

            // ビットコインアドレスをもとに残高を取得する
            QBitNinjaClient client = new QBitNinjaClient(Network.TestNet);
            BitcoinPubKeyAddress pubkey = new BitcoinPubKeyAddress(bitAddr);
            var balanceModel = client.GetBalance(pubkey).Result;

            // トランザクションアウトプットに該当のアドレスがあるトランザクションID毎の残高を取得
            foreach (var operation in SortByIP024OperationOrder(balanceModel.Operations))
            {
                var transactionId = operation.TransactionId;

                // トランザクション内の複数のトランザクションアプトプットにOP_RETURNがあれば取得
                uint N = 99;
                var Coins = client.GetTransaction(transactionId).Result.ReceivedCoins;
                foreach (var Coin in Coins)
                {

                    // 自アドレスが何番目のトランザクションアウトプットかを取得する（残高算出用）
                    // [0]:１番目はIP024コインのFromを意味する
                    // [1]:２番目はIP024コインのTo
                    // [2]:３番目はIP024コインの発行者
                    if (Coin.TxOut.ScriptPubKey == pubkey.ScriptPubKey)
                    {
                        N = Coin.Outpoint.N;
                    }

                    string opReturnText = "OP_RETURN";
                    if (Coin.TxOut.ScriptPubKey.ToString().IndexOf(opReturnText) >= 0)
                    {
                        string metadataString = Coin.TxOut.ScriptPubKey.ToString().Substring(opReturnText.Length + 1, Coin.TxOut.ScriptPubKey.ToString().Length - opReturnText.Length - 1);
                        var bytes = FromHexString(metadataString);
                        metadataString = Encoding.GetEncoding("shift_jis").GetString(bytes);

                        // メタデータから独自コインの情報を取得する
                        // metadataString = "JGSIP024F50T50_P";//test用
                        string markText = "JGSIP024";
                        if (metadataString.IndexOf(markText) >= 0)
                        {
                            int idxF = metadataString.IndexOf('F');
                            int idxT = metadataString.IndexOf('T');
                            int idxUnderBar = metadataString.IndexOf('_');
                            string fromValue = metadataString.Substring(idxF + 1, idxT - idxF - 1);
                            string toValue = metadataString.Substring(idxT + 1, idxUnderBar - idxT - 1);
                            string coinSource = metadataString.Substring(idxUnderBar + 1, 1);

                            // 対象エリア内ボーナス処理（トランザクション処理中の残高計算）
                            Boolean inTargetAreaTransaction = false;
                            if (metadataString.Length > idxUnderBar + 2)
                            {
                                inTargetAreaTransaction = metadataString.Substring(idxUnderBar + 2, 1) == "1";
                            }

                            // 最後のトランザクションが対象エリア外かつ、最新トランザクションが対象エリア内
                            if (!inTargetArea && inTargetAreaTransaction)
                            {
                                BalanceByAct = BalanceByAct - Enumerable.Sum(bonusCoin);
                                bonusCoin.Clear();
                                inTargetArea = false;
                            }
                            // 最後：内、最新：外
                            else if (inTargetArea && !inTargetAreaTransaction)
                            {
                                bonusCoin.Add(BalanceByAct);
                                BalanceByAct = BalanceByAct * 2;
                                inTargetArea = true;
                            }


                            // 残高算出
                            // 残高からマイナスする金額
                            if (N == 0)
                            {
                                long amountOfPayment = long.Parse(fromValue);

                                var afterPay = CalculateBalance(BalanceByPay, amountOfPayment);
                                var afterIssue = CalculateBalance(BalanceByIssue, afterPay.AfterPayment);
                                var afterAct = CalculateBalance(BalanceByAct, afterIssue.AfterPayment);

                                BalanceByPay = afterPay.AfterBalance;
                                BalanceByIssue = afterIssue.AfterBalance;
                                BalanceByAct = afterAct.AfterBalance;

                            }
                            // 残高にプラスする金額
                            else if (N == 1)
                            {
                                if (coinSource == "P")
                                {
                                    BalanceByPay = BalanceByPay + long.Parse(toValue);
                                }
                                if (coinSource == "I")
                                {
                                    BalanceByIssue = BalanceByIssue + long.Parse(toValue);
                                }
                                if (coinSource == "V")
                                {
                                    if (inTargetArea)
                                    {
                                        BalanceByAct = BalanceByAct + long.Parse(toValue);
                                    }
                                    else
                                    {
                                        bonusCoin.Add(long.Parse(toValue));
                                        BalanceByAct = BalanceByAct + (long.Parse(toValue) * 2);
                                    }
                                    CumulativeTotalByAct = CumulativeTotalByAct + long.Parse(toValue);
                                }
                            }
                            else
                            {
                                // ないはず
                            }

                            // 現在の残高（合計）
                            Balance = BalanceByPay + BalanceByIssue + BalanceByAct;
                        }

                    }
                }
            }

            BalanceText[0] = BalanceByIssue.ToString();
            BalanceText[1] = BalanceByPay.ToString();

            // 最後：外、現在：内
            if (!inTargetArea && jgsip024coinClass.inTargetArea(placeFlag))
            {
                BalanceText[2] = (BalanceByAct - Enumerable.Sum(bonusCoin)).ToString();
            }
            // 最後：内、現在：外
            else if (inTargetArea && !jgsip024coinClass.inTargetArea(placeFlag))
            {
                BalanceText[2] = (BalanceByAct * 2).ToString();
            }
            // 通常時
            else
            {
                BalanceText[2] = BalanceByAct.ToString();
            }

            BalanceText[3] = CumulativeTotalByAct.ToString();
            return BalanceText;
        }


        public static string SendMoney(String saPrivateKey, String FromAddr, String DestinationAddr, int SendBtc, double SendBtcFee, String message)
        {
            string result = "";

            // 秘密鍵のインポート
            var bitcoinPrivateKey = new
            BitcoinSecret(saPrivateKey);

            // 発行者のパブリックキーアドレスを取得する
            QBitNinjaClient client = new QBitNinjaClient(Network.TestNet);
            BitcoinPubKeyAddress saPub = new BitcoinPubKeyAddress(bitcoinPrivateKey.PubKey.GetAddress(Network.TestNet).ToString());
            Console.WriteLine(bitcoinPrivateKey.PubKey.GetAddress(Network.TestNet).ToString());

            // IP024コインの送付先と送付元のパブリックキーアドレスを取得する
            var fromPub = new BitcoinPubKeyAddress(FromAddr);
            var destPub = new BitcoinPubKeyAddress(DestinationAddr);

            // 残高情報を取得する
            var balanceModel = client.GetBalance(saPub).Result;
            // 実運用を考えると発行者の残高管理（秘密鍵）は複数あったほうがいい。パフォーマンスが激重になる懸念あり。
            /*
                        var balanceModel = client.GetBalance(fromPub).Result;
                        if (balanceModel.Operations.Count == 0) 
                        {
                            balanceModel = client.GetBalance(saPub).Result;
                        }
            */

            // 最新のトランザクションIDをもとに支払用トランザクションを作成する
            // ブロック高 = 0のトランザクションが複数ある場合に二重決済が行われるため、foreachはNG
            var operation = SortByIP024OperationOrder(balanceModel.Operations).Last();


            var transactionId = operation.TransactionId;
            var transactionResponse = client.GetTransaction(transactionId).Result;

            // トランザクションのoutpointを確認
            var receivedCoins = transactionResponse.ReceivedCoins;
            OutPoint outPointToSpend = null;
            foreach (var coin in receivedCoins)
            {
                if (coin.TxOut.ScriptPubKey == saPub.ScriptPubKey)
                {
                    outPointToSpend = coin.Outpoint;
                }
            }
            if (outPointToSpend == null)
            {
                throw new Exception("エラー：どのトランザクションアウトプットも送ったコインのScriptPubKeyを持ってない！");
            }

            // outpointをこれから発行するトランザクションのTxInにセットする
            var transaction = new Transaction();
            transaction.Inputs.Add(new TxIn()
            {
                PrevOut = outPointToSpend
            });

            // 送付コイン用のトランザクションアウトプットを作成する
            TxOut FromTxOut = new TxOut()
            {
                Value = new Money((decimal)SendBtc, MoneyUnit.BTC),
                ScriptPubKey = fromPub.ScriptPubKey
            };
            TxOut DestTxOut = new TxOut()
            {
                Value = new Money((decimal)SendBtc, MoneyUnit.BTC),
                ScriptPubKey = destPub.ScriptPubKey
            };
            var txInAmount = receivedCoins[(int)outPointToSpend.N].TxOut.Value;
            TxOut changeBackTxOut = new TxOut()
            {
                Value = new Money(txInAmount.ToDecimal(MoneyUnit.BTC) - (decimal)SendBtcFee, MoneyUnit.BTC),
                ScriptPubKey = saPub.ScriptPubKey
            };
            transaction.Outputs.Add(FromTxOut);
            transaction.Outputs.Add(DestTxOut);
            transaction.Outputs.Add(changeBackTxOut);

            // OP_RETURNへのメッセージ書き込み
            var bytes = Encoding.UTF8.GetBytes(message);
            transaction.Outputs.Add(new TxOut()
            {
                Value = Money.Zero,
                ScriptPubKey = TxNullDataTemplate.Instance.GenerateScriptPubKey(bytes)
            });

            // 署名
            transaction.Inputs[0].ScriptSig = saPub.ScriptPubKey;
            transaction.Sign(bitcoinPrivateKey, false);

            // トランザクション全体を表示 debug用
            Console.WriteLine(transaction);
            writeToFile(transaction.ToString());

            // broadcast
            var broadcastResponse = client.Broadcast(transaction).Result;
            if (!broadcastResponse.Success)
            {
                result = "Error! ErrorCode=" + broadcastResponse.Error.ErrorCode + " ErrorMsg=" + broadcastResponse.Error.Reason;
            }
            else
            {
                Console.WriteLine("Success! You can check out the hash of the transaciton in any block explorer:");
                Console.WriteLine(transaction.GetHash());
                result = "Success! TransactionID=" + transaction.GetHash();
            }
            writeToFile(result);

            // トランザクションのブロックチェーンへの反映待ち(SendMoney直後のgetTransactionでSendMoneyしたTransactionが取得できない)
            WaitTransactionToComplete(transaction);

            return result;
        }
        public static byte[] FromHexString(string str)
        {
            int length = str.Length / 2;
            byte[] bytes = new byte[length];
            int j = 0;
            for (int i = 0; i < length; i++)
            {
                bytes[i] = Convert.ToByte(str.Substring(j, 2), 16);
                j += 2;
            }
            return bytes;
        }
        public static void writeToFile(string str)
        {
            // ファイルにテキストを書き出し。
            using (StreamWriter w = new StreamWriter(logFileName, true))
            {
                w.WriteLine("-----------{0}-----------", System.DateTime.Now.ToString());
                w.WriteLine(str);
            }
        }

        private static dynamic CalculateBalance(long balance, long payment)
        {
            return new
            {
                AfterBalance = balance > payment ? balance - payment : 0,
                AfterPayment = balance > payment ? 0 : payment - balance
            };
        }

        public static Boolean inTargetArea(string place)
        {
            return place == "〇";
        }

        /// <summary>
        /// トランザクション発生時刻順（旧→新）でOperationをソートする
        /// </summary>
        /// <param name="operations">Models.BalanceModelから取得できるOperations</param>
        /// <returns>Operations内のOperationを、内部のTransactionの発生日時でソートしたもの</returns>
        public static List<BalanceOperation> SortByIP024OperationOrder(List<QBitNinja.Client.Models.BalanceOperation> operations)
        {

            SortedDictionary<DateTimeOffset, BalanceOperation> tempDic = new SortedDictionary<DateTimeOffset, BalanceOperation>();

            foreach (var operation in Enumerable.Reverse(operations))
            {

                QBitNinjaClient client = new QBitNinjaClient(Network.TestNet);
                var transactionId = operation.TransactionId;
                var transaction = client.GetTransaction(transactionId).Result;
                tempDic.Add(transaction.FirstSeen, operation);
            }

            return new List<BalanceOperation>(tempDic.Values);
        }

        static void WaitTransactionToComplete(Transaction transaction)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            QBitNinjaClient client = new QBitNinjaClient(Network.TestNet);
            Task task = client.GetTransaction(transaction.GetHash());
            task.Wait();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            writeToFile("トランザクション反映待ち時間 : " + elapsedTime);


        }

    }
}
