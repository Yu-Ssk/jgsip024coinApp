namespace jgsip024coinApp
{
    partial class PortalForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.ToAssetManagerWallet = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ToAssetManagerWallet
            // 
            this.ToAssetManagerWallet.Location = new System.Drawing.Point(80, 58);
            this.ToAssetManagerWallet.Name = "ToAssetManagerWallet";
            this.ToAssetManagerWallet.Size = new System.Drawing.Size(618, 94);
            this.ToAssetManagerWallet.TabIndex = 0;
            this.ToAssetManagerWallet.Text = "Asset Manager Wallet";
            this.ToAssetManagerWallet.UseVisualStyleBackColor = true;
            this.ToAssetManagerWallet.Click += new System.EventHandler(this.AssetManagerWallet_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(618, 94);
            this.button1.TabIndex = 0;
            this.button1.Text = "Client Wallet";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClientWallet_Click);
            // 
            // PortalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 350);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ToAssetManagerWallet);
            this.Name = "PortalForm";
            this.Text = "JGS IP024 Coin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ToAssetManagerWallet;
        private System.Windows.Forms.Button button1;
    }
}

