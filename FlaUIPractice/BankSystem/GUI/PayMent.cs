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
    public partial class PayMent : Form
    {
        static public long Value;
        static public string Pay;
        public PayMent(string Title)
        {
            InitializeComponent();
            this.Text = Title;
            this.TextLabel.Text = "Please Enter Your " + Title + " Value :";
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool CheckInput(string x)
        {
            if (x.Length < 1) return false;
            for (int i = 0; i < x.Length; ++i)
            {
                if (!(x[i] >= '0' && x[i] <= '9')) return false;
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckInput(Input.Text))
            {
                Value = Int64.Parse(Input.Text);
                if (this.Text == "Deposit")
                {
                    ClientsData.Current.Am += Int32.Parse(Input.Text);
                    MessageBox.Show("Your Order Has Been Processed!", "Confirm");
                    this.Close();
                }
                else
                {
                    if (ClientsData.Current.Am < Int32.Parse(Input.Text))
                    {
                        MessageBox.Show("Sorry We Can't Process Your Order!", "Error");
                    }
                    else
                    {
                        if (this.Text == "Withdrawal")
                        {
                            ClientsData.Current.Am -= Int32.Parse(Input.Text);
                            MessageBox.Show("Your Order Has Been Processed!", "Confirm");
                            this.Close();
                        }
                        else if (this.Text == "Transfer")
                        {
                            (new TransferToEmail(Int32.Parse(Input.Text))).ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            Pay = this.Text;
                            ClientsData.Current.Am -= Int32.Parse(Input.Text);
                            MessageBox.Show("Your Order Has Been Processed!", "Confirm");
                            this.Close();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter A Correct Value!", "Error");
            }
        }
    }
}
