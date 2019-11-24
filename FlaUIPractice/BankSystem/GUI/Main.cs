using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class Main : Form
    {
        public Main()
        {
            
            InitializeComponent();
            string Replay = ClientsData.OpenStreams();
            if (Replay != "Opened")
            {
                      MessageBox.Show(Replay, "Can't Open Data File",
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                      this.Dispose();
            }
            Replay = ClientsLogs.OpenStreams();
            if (Replay != "Opened")
            {
                MessageBox.Show(Replay, "Can't Open Data File",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
        }
        private void Main_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.BackColor = Color.FromArgb(0, 88, 44, 55);
            tableLayoutPanel2.BackColor = Color.FromArgb(0, 88, 44, 55);
            label1.BackColor = Color.FromArgb(0, 88, 44, 55);
            label2.BackColor = Color.FromArgb(0, 88, 44, 55);
            EmLog.Text = "admin";
            PassLog.Text = "12345";
            PassLog.PasswordChar = '*';
        }
        private void button1_Click(object sender, EventArgs e)
        {
            (new Registration()).ShowDialog();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show
            ("This Application Has Been Created for testing",
              "About Us");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            (new Contact()).ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Exchange rates can't be accessed at the moment", "Error");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EmLog.Text.Length < 1 || PassLog.Text.Length < 1)
            {
                MessageBox.Show("Please Enter Your Email & Password And Try Again!", "Error");
            }
            else
            {
                if (ClientsData.LogInChecker(EmLog.Text.ToLower(), PassLog.Text))
                {
                    this.Hide();
                    (new MyAccount()).ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Please Correct Your Email & Password And Try Again!", "Error");
                }

            }
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?!", "Exit",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                if (!ClientsData.CloseStreams() || !ClientsLogs.CloseStreams())
                {
                    MessageBox.Show("Data File Can't Be Closed Correctly!", "Error",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
