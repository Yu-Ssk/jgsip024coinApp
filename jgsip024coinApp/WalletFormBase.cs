
/// <summary>
/// IP024Coinウォレットアプリケーションフォーム
/// </summary>
/// <author>
/// Yu Sasaki, Jiei Kimura
/// </author>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace jgsip024coinApp
{
    public partial class WalletFormBase : Form
    {
        private int formMode;
        private string filename = "YourInfo.txt";
        private List<string> list = new List<string> ();

        public WalletFormBase(int n)
        {
            InitializeComponent();
            formMode = n;
        }

        private void buttonGeneratePrivateKeyAndAddress_Click(object sender, EventArgs e)
        {
            string[] result = jgsip024coinClass.GeneratePrivateKeyAndAddress();
            textReturnAddress.Lines = result;
        } 

        private void WalletFormBase_Shown(object sender, EventArgs e)
        {
            pictureBoxNowLoading.Visible = true;
            if (formMode == 0)
            {
                // Asset Management Walletとしての起動なら秘密鍵の作成ボタンやPAYボタン横のラジオボタンは表示とする
                buttonGeneratePrivateKeyAndAddress.Visible = true;
                textReturnAddress.Visible = true;
                radioButtonI.Visible = true;
                radioButtonV.Visible = true;
                radioButtonPS.Visible = true;
                radioButtonPB.Visible = false;

            }
            else
            {
                // Client Walletとしての起動なら秘密鍵の作成ボタンやPAYボタン横のラジオボタンは非表示とする
                buttonGeneratePrivateKeyAndAddress.Visible = false;
                textReturnAddress.Visible = false;
                radioButtonI.Visible = false;
                radioButtonV.Visible = false;
                radioButtonPS.Visible = true;
                radioButtonPB.Visible = true;

            }

            // ファイルから自分のビットコインアドレスを取得して表示する
            // 1行目：コイン発行者の秘密鍵（変更不可）
            // 2行目：割り当てられた自分のアドレス（コイン発行者は1行目に対応する公開鍵から生成したアドレス。
            //        それ以外の配布先ウォレットは配布されたアドレス）
            // 3行目：居場所
            // 4行目：居場所判定結果（本当はウォレットにGPS機能を持たせたい）
            using (StreamReader file = new StreamReader(filename, Encoding.Default))
            {
                string line = "";
                while ((line = file.ReadLine()) != null)
                {
                    list.Add(line);
                }
                textYourAddress.Text = list[1];
                textPlace.Text = list[2];
                textPlaceJudge.Text = list[3];
            }

            if (!jgsip024coinClass.inTargetArea(textPlaceJudge.Text.ToString()))
            {
                radioButtonPB.Enabled = false;
                label9.Visible = formMode != 0;

            }


            // 残高を表示する
            jgsip024coinClass.writeToFile("- - -残高- - -");
            string[] result = jgsip024coinClass.GetBalance(list[1], textPlaceJudge.Text.ToString());
            int idx = 0;
            foreach (var res in result)
            {
                String fres = String.Format("{0, 8}", res);
                if (idx == 0)
                {
                    textBalance.Clear();
                    textBalance.AppendText("IPCoin(I):" + fres + " IPC\r\n");
                    jgsip024coinClass.writeToFile("IPCoin(I)残高： " + res + " IPC\r\n");

                }
                if (idx == 1)
                {
                    textBalance.AppendText("IPCoin(P):" + fres + " IPC\r\n");
                    jgsip024coinClass.writeToFile("IPCoin(P)残高： " + res + " IPC\r\n");

                }
                if (idx == 2)
                {
                    textBalance.AppendText("IPCoin(V):" + fres + " IPC");
                    jgsip024coinClass.writeToFile("IPCoin(V)残高： " + res + " IPC\r\n");
                }
                if (idx == 3)
                {
                    textTotalByAct.Clear();
                    textTotalByAct.AppendText(res + " IPCAction");
                    jgsip024coinClass.writeToFile("　行動価値： " + res + " IPCAction");
                }
                idx++;
            }
            pictureBoxNowLoading.Visible = false;
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            // validation
            if (textDestinationAddress.Text.ToString() == "")
            {
                MessageBox.Show("送付先アドレスを入力してください。");
                return;
            }
            if (textPayAmount.Text.ToString() == "")
            {
                MessageBox.Show("支払額(IPCoin)を入力してください。");
                return;
            }

            // 本当に送っていいか？メッセージを出す
            if (DialogResult.Yes == MessageBox.Show("あなたのアドレスから送付先アドレスに" + textPayAmount.Text.ToString() + "IPCoinを送ります。", "確認", MessageBoxButtons.YesNo))
            {
                // OP_RETURN メッセージ加工
                string message = "JGSIP024";
                if (formMode == 0)
                {
                    // managerとしてのフォーム起動の場合
                    // 行動価値を相手に与えるメッセージを作成する
                    // ex. JGSIP024F50T50_V
                    if (radioButtonV.Checked == true)
                    {
                        message += "F";
                        message += "0";
                        message += "T";
                        message += textPayAmount.Text.ToString();
                        message += "_V";
                        jgsip024coinClass.writeToFile("-------------管理者として実行-------------");
                        jgsip024coinClass.writeToFile("OP_RETURN = " + message);
                    }
                    // 支払いの時に相手に与えるメッセージを作成する
                    // ex. JGSIP024F50T50_P
                    if (radioButtonPS.Checked == true)
                    {
                        message += "F";
                        message += textPayAmount.Text.ToString();
                        message += "T";
                        message += textPayAmount.Text.ToString();
                        message += "_P";
                        jgsip024coinClass.writeToFile("-------------管理者として実行-------------");
                        jgsip024coinClass.writeToFile("OP_RETURN = " + message);
                    }
                    // 通貨を発行し相手に与えるメッセージを作成する
                    // ex. JGSIP024F50T50_V
                    if (radioButtonI.Checked == true)
                    {
                        message += "F";
                        message += "0";
                        message += "T";
                        message += textPayAmount.Text.ToString();
                        message += "_I";
                        jgsip024coinClass.writeToFile("-------------管理者として実行-------------");
                        jgsip024coinClass.writeToFile("OP_RETURN = " + message);
                    }
                }
                else
                {
                    // clientとしてのフォーム起動の場合、支払い用メッセージを作成する
                    // ex. JGSIP024F50T50_P
                    message += "F";
                    message += textPayAmount.Text.ToString();
                    message += "T";
                    message += textPayAmount.Text.ToString();
                    message += "_P";

                    jgsip024coinClass.writeToFile("-------------クライアントとして実行-------------");
                    jgsip024coinClass.writeToFile("OP_RETURN = " + message);
                }

                pictureBoxNowLoading.Visible = true;
				// TargetAreaかどうかを追加
				message += jgsip024coinClass.inTargetArea(textPlaceJudge.Text.ToString()) ? "1" : "0";

                // 支払実行
                string result = jgsip024coinClass.SendMoney(list[0], list[1], textDestinationAddress.Text.ToString(), 0, 0.0005, message);
                
                // 結果メッセージの表示＆ログ出力
                textInfo.Text = result;                

                // 残高の再表示
                string[] results = jgsip024coinClass.GetBalance(list[1], textPlaceJudge.Text.ToString());
                int idx = 0;
                foreach (var res in results)
                {
                    String fres = String.Format("{0, 8}", res);
                    if (idx == 0)
                    {
                        textBalance.Clear();
                        textBalance.AppendText("IPCoin(I):" + fres + " IPC\r\n");
                        jgsip024coinClass.writeToFile("IPCoin(I)残高： " + res + " IPC\r\n");

                    }
                    if (idx == 1)
                    {
                        textBalance.AppendText("IPCoin(P):" + fres + " IPC\r\n");
                        jgsip024coinClass.writeToFile("IPCoin(P)残高： " + res + " IPC\r\n");
                    }
                    if (idx == 2)
                    {
                        textBalance.AppendText("IPCoin(V):" + fres + " IPC");
                        jgsip024coinClass.writeToFile("IPCoin(V)残高： " + res + " IPC\r\n");
                    }
                    if (idx == 3)
                    {
                        textTotalByAct.Clear();
                        textTotalByAct.AppendText(res + " IPCAction");
                        jgsip024coinClass.writeToFile("　行動価値： " + res + " IPCAction");
                    }
                    idx++;
                }

                pictureBoxNowLoading.Visible = false;
            }

        }

        private void textPayAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            //0～9と、バックスペース以外の時は、イベントをキャンセルする
            if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }
        }
    }
}
