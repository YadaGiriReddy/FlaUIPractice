using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class TransferToEmail : Form
    {
        int Transfer;
        public TransferToEmail(int n)
        {
            InitializeComponent();
            Transfer = n;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ClientsData.Transfer(Input.Text, Transfer))
            {
                ClientsData.Current.Am -= Transfer;
                MessageBox.Show("Your Order Has Been Processed!", "Confirm");
                this.Close();
            }
            else
            {
                MessageBox.Show("Sorry We Can't Find This Email!", "Error");
                this.Close();
            }
        }
    }
}
