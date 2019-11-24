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
    public partial class MyAccount : Form
    {
        public MyAccount()
        {
            InitializeComponent();
            tableLayoutPanel2.BackColor = Color.FromArgb(0, 88, 44, 55);
            tableLayoutPanel1.BackColor = Color.FromArgb(0, 88, 44, 55);
            Email.BackColor = Color.FromArgb(0, 88, 44, 55);
            FirName.BackColor = Color.FromArgb(0, 88, 44, 55);
            
            Email.Text = ClientsData.Current.EM;
            FirName.Text = ClientsData.Current.FName + " " + ClientsData.Current.LName;
            Age.Text = ClientsData.Current.Ag;
            Country.Text = ClientsData.Current.Ctry;
            Phon.Text = ClientsData.Current.Phone;
            Cardn.Text = ClientsData.Current.Visa;
            Amount.Text = (ClientsData.Current.Am).ToString() + "$";
            TableIntial();
        }
        public void TableIntial()
        {
            ClientsLogs.GetLogs(dataGridView1);   
        }
        private void Deposit_Click(object sender, EventArgs e)
        {
            (new PayMent("Deposit")).ShowDialog();
            string Temp = (ClientsData.Current.Am).ToString() + "$";
            if ( Temp!= Amount.Text)
            {
                dataGridView1.Rows.Add("Deposit To The Account : ",PayMent.Value.ToString()+"$");
                ClientsLogs.AddLog("Deposit To The Account : ", PayMent.Value.ToString() + "$");
                Amount.Text = Temp;
                ClientsData.UpdateAccount();
            }
        }

        private void Withdrawal_Click(object sender, EventArgs e)
        {
            (new PayMent("Withdrawal")).ShowDialog();
            string Temp = (ClientsData.Current.Am).ToString() + "$";
            if (Temp != Amount.Text)
            {
                dataGridView1.Rows.Add("Withdrawal From The Account : ", PayMent.Value.ToString() + "$");
                ClientsLogs.AddLog("Withdrawal From The Account : ", PayMent.Value.ToString() + "$");
                Amount.Text = Temp;
                ClientsData.UpdateAccount();
            }
        }

        private void Transfer_Click(object sender, EventArgs e)
        {
            (new PayMent("Transfer")).ShowDialog();
            string Temp = (ClientsData.Current.Am).ToString() + "$";
            if (Temp != Amount.Text)
            {
                dataGridView1.Rows.Add("Transfer To Another The Account : ", PayMent.Value.ToString() + "$");
                ClientsLogs.AddLog("Transfer To Another The Account : ", PayMent.Value.ToString() + "$");
                Amount.Text = Temp;
                ClientsData.UpdateAccount();
            }
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logged out successfully..", "Info");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Delete Your Account ?!", "Confirmation",
                           MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ClientsData.DeleteAccount();
                this.Close();
            }
        }
    }
}
