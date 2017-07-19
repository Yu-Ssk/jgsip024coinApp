/// <summary>
/// IP024Coinウォレット選択フォーム
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

namespace jgsip024coinApp
{
    public partial class PortalForm : Form
    {
        public PortalForm()
        {
            InitializeComponent();
        }

        private void AssetManagerWallet_Click(object sender, EventArgs e)
        {
            WalletFormBase form = new WalletFormBase(0);
            form.Show();
        }

        private void ClientWallet_Click(object sender, EventArgs e)
        {
            WalletFormBase form = new WalletFormBase(1);
            form.Show();
        }
    }
}
