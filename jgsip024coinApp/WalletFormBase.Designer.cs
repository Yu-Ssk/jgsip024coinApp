namespace jgsip024coinApp
{
    partial class WalletFormBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WalletFormBase));
            this.label1 = new System.Windows.Forms.Label();
            this.textYourAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textDestinationAddress = new System.Windows.Forms.TextBox();
            this.buttonPay = new System.Windows.Forms.Button();
            this.textInfo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBalance = new System.Windows.Forms.TextBox();
            this.buttonGeneratePrivateKeyAndAddress = new System.Windows.Forms.Button();
            this.textReturnAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textPlace = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textPlaceJudge = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonPS = new System.Windows.Forms.RadioButton();
            this.radioButtonPB = new System.Windows.Forms.RadioButton();
            this.radioButtonV = new System.Windows.Forms.RadioButton();
            this.radioButtonI = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.textPayAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBoxNowLoading = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textTotalByAct = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNowLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your Adress";
            // 
            // textYourAddress
            // 
            this.textYourAddress.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textYourAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textYourAddress.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textYourAddress.Location = new System.Drawing.Point(119, 6);
            this.textYourAddress.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textYourAddress.Name = "textYourAddress";
            this.textYourAddress.ReadOnly = true;
            this.textYourAddress.Size = new System.Drawing.Size(449, 26);
            this.textYourAddress.TabIndex = 1;
            this.textYourAddress.TabStop = false;
            this.textYourAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Destination address";
            // 
            // textDestinationAddress
            // 
            this.textDestinationAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textDestinationAddress.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textDestinationAddress.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textDestinationAddress.Location = new System.Drawing.Point(119, 192);
            this.textDestinationAddress.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textDestinationAddress.Name = "textDestinationAddress";
            this.textDestinationAddress.Size = new System.Drawing.Size(448, 26);
            this.textDestinationAddress.TabIndex = 3;
            this.textDestinationAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonPay
            // 
            this.buttonPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.buttonPay.FlatAppearance.BorderColor = System.Drawing.Color.DarkSlateBlue;
            this.buttonPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPay.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonPay.Location = new System.Drawing.Point(158, 84);
            this.buttonPay.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(194, 30);
            this.buttonPay.TabIndex = 4;
            this.buttonPay.Text = "Pay";
            this.buttonPay.UseVisualStyleBackColor = false;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // textInfo
            // 
            this.textInfo.BackColor = System.Drawing.Color.LightCyan;
            this.textInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textInfo.Location = new System.Drawing.Point(105, 123);
            this.textInfo.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textInfo.Multiline = true;
            this.textInfo.Name = "textInfo";
            this.textInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textInfo.Size = new System.Drawing.Size(448, 47);
            this.textInfo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 128);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Balance";
            // 
            // textBalance
            // 
            this.textBalance.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBalance.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBalance.Location = new System.Drawing.Point(119, 107);
            this.textBalance.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textBalance.Multiline = true;
            this.textBalance.Name = "textBalance";
            this.textBalance.ReadOnly = true;
            this.textBalance.Size = new System.Drawing.Size(296, 55);
            this.textBalance.TabIndex = 7;
            this.textBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // buttonGeneratePrivateKeyAndAddress
            // 
            this.buttonGeneratePrivateKeyAndAddress.BackColor = System.Drawing.Color.AliceBlue;
            this.buttonGeneratePrivateKeyAndAddress.Location = new System.Drawing.Point(13, 358);
            this.buttonGeneratePrivateKeyAndAddress.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.buttonGeneratePrivateKeyAndAddress.Name = "buttonGeneratePrivateKeyAndAddress";
            this.buttonGeneratePrivateKeyAndAddress.Size = new System.Drawing.Size(227, 20);
            this.buttonGeneratePrivateKeyAndAddress.TabIndex = 8;
            this.buttonGeneratePrivateKeyAndAddress.Text = "Generate Address";
            this.buttonGeneratePrivateKeyAndAddress.UseVisualStyleBackColor = false;
            this.buttonGeneratePrivateKeyAndAddress.Click += new System.EventHandler(this.buttonGeneratePrivateKeyAndAddress_Click);
            // 
            // textReturnAddress
            // 
            this.textReturnAddress.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textReturnAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textReturnAddress.Location = new System.Drawing.Point(13, 382);
            this.textReturnAddress.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textReturnAddress.Multiline = true;
            this.textReturnAddress.Name = "textReturnAddress";
            this.textReturnAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textReturnAddress.Size = new System.Drawing.Size(550, 52);
            this.textReturnAddress.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 46);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Your Location";
            // 
            // textPlace
            // 
            this.textPlace.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textPlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPlace.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textPlace.Location = new System.Drawing.Point(119, 38);
            this.textPlace.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textPlace.Name = "textPlace";
            this.textPlace.ReadOnly = true;
            this.textPlace.Size = new System.Drawing.Size(449, 26);
            this.textPlace.TabIndex = 12;
            this.textPlace.TabStop = false;
            this.textPlace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "Target Zone";
            // 
            // textPlaceJudge
            // 
            this.textPlaceJudge.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textPlaceJudge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPlaceJudge.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textPlaceJudge.Location = new System.Drawing.Point(119, 69);
            this.textPlaceJudge.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textPlaceJudge.Name = "textPlaceJudge";
            this.textPlaceJudge.ReadOnly = true;
            this.textPlaceJudge.Size = new System.Drawing.Size(449, 26);
            this.textPlaceJudge.TabIndex = 14;
            this.textPlaceJudge.TabStop = false;
            this.textPlaceJudge.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.radioButtonPS);
            this.panel1.Controls.Add(this.radioButtonPB);
            this.panel1.Controls.Add(this.radioButtonV);
            this.panel1.Controls.Add(this.radioButtonI);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.textPayAmount);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonPay);
            this.panel1.Controls.Add(this.textInfo);
            this.panel1.Location = new System.Drawing.Point(13, 168);
            this.panel1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(571, 185);
            this.panel1.TabIndex = 15;
            // 
            // radioButtonPS
            // 
            this.radioButtonPS.AutoSize = true;
            this.radioButtonPS.Checked = true;
            this.radioButtonPS.Location = new System.Drawing.Point(366, 84);
            this.radioButtonPS.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.radioButtonPS.Name = "radioButtonPS";
            this.radioButtonPS.Size = new System.Drawing.Size(75, 16);
            this.radioButtonPS.TabIndex = 20;
            this.radioButtonPS.TabStop = true;
            this.radioButtonPS.Text = "Pay(Send)";
            this.radioButtonPS.UseVisualStyleBackColor = true;
            // 
            // radioButtonPB
            // 
            this.radioButtonPB.AutoSize = true;
            this.radioButtonPB.Location = new System.Drawing.Point(366, 104);
            this.radioButtonPB.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.radioButtonPB.Name = "radioButtonPB";
            this.radioButtonPB.Size = new System.Drawing.Size(70, 16);
            this.radioButtonPB.TabIndex = 19;
            this.radioButtonPB.Text = "Pay(Buy)";
            this.radioButtonPB.UseVisualStyleBackColor = true;
            // 
            // radioButtonV
            // 
            this.radioButtonV.AutoSize = true;
            this.radioButtonV.Location = new System.Drawing.Point(481, 104);
            this.radioButtonV.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.radioButtonV.Name = "radioButtonV";
            this.radioButtonV.Size = new System.Drawing.Size(72, 16);
            this.radioButtonV.TabIndex = 18;
            this.radioButtonV.Text = "Volunteer";
            this.radioButtonV.UseVisualStyleBackColor = true;
            // 
            // radioButtonI
            // 
            this.radioButtonI.AutoSize = true;
            this.radioButtonI.Location = new System.Drawing.Point(481, 84);
            this.radioButtonI.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.radioButtonI.Name = "radioButtonI";
            this.radioButtonI.Size = new System.Drawing.Size(50, 16);
            this.radioButtonI.TabIndex = 18;
            this.radioButtonI.Text = "Issue";
            this.radioButtonI.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 61);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "Payment(IPCoin)";
            // 
            // textPayAmount
            // 
            this.textPayAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textPayAmount.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textPayAmount.Font = new System.Drawing.Font("MS UI Gothic", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textPayAmount.Location = new System.Drawing.Point(105, 54);
            this.textPayAmount.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textPayAmount.Name = "textPayAmount";
            this.textPayAmount.Size = new System.Drawing.Size(448, 26);
            this.textPayAmount.TabIndex = 16;
            this.textPayAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textPayAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textPayAmount_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 5);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "Payment Information";
            // 
            // pictureBoxNowLoading
            // 
            this.pictureBoxNowLoading.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNowLoading.Image")));
            this.pictureBoxNowLoading.Location = new System.Drawing.Point(47, -22);
            this.pictureBoxNowLoading.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.pictureBoxNowLoading.Name = "pictureBoxNowLoading";
            this.pictureBoxNowLoading.Size = new System.Drawing.Size(489, 427);
            this.pictureBoxNowLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNowLoading.TabIndex = 16;
            this.pictureBoxNowLoading.TabStop = false;
            this.pictureBoxNowLoading.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(429, 128);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 12);
            this.label8.TabIndex = 17;
            this.label8.Text = "TotalByAction";
            // 
            // textTotalByAct
            // 
            this.textTotalByAct.BackColor = System.Drawing.Color.LightSteelBlue;
            this.textTotalByAct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTotalByAct.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textTotalByAct.Location = new System.Drawing.Point(431, 140);
            this.textTotalByAct.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.textTotalByAct.Multiline = true;
            this.textTotalByAct.Name = "textTotalByAct";
            this.textTotalByAct.ReadOnly = true;
            this.textTotalByAct.Size = new System.Drawing.Size(136, 22);
            this.textTotalByAct.TabIndex = 18;
            this.textTotalByAct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(434, 97);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(132, 24);
            this.label9.TabIndex = 19;
            this.label9.Text = "Send Only\r\n(outside target zone)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.Visible = false;
            // 
            // WalletFormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(601, 376);
            this.Controls.Add(this.pictureBoxNowLoading);
            this.Controls.Add(this.textTotalByAct);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textPlaceJudge);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textPlace);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textReturnAddress);
            this.Controls.Add(this.buttonGeneratePrivateKeyAndAddress);
            this.Controls.Add(this.textBalance);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textDestinationAddress);
            this.Controls.Add(this.textYourAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "WalletFormBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WalletFormBase";
            this.Shown += new System.EventHandler(this.WalletFormBase_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNowLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textYourAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textDestinationAddress;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.TextBox textInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBalance;
        private System.Windows.Forms.Button buttonGeneratePrivateKeyAndAddress;
        private System.Windows.Forms.TextBox textReturnAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textPlace;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textPlaceJudge;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textPayAmount;
        private System.Windows.Forms.RadioButton radioButtonV;
        private System.Windows.Forms.RadioButton radioButtonI;
        private System.Windows.Forms.RadioButton radioButtonPB;
        private System.Windows.Forms.RadioButton radioButtonPS;
        private System.Windows.Forms.PictureBox pictureBoxNowLoading;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textTotalByAct;
        private System.Windows.Forms.Label label9;
    }
}