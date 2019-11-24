using System;
using System.Windows.Forms;

namespace BankSystem
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            InPass.PasswordChar = '*';
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (  CharsChecker(InFName.Text) && CharsChecker(InLName.Text) &&
                  NumsChecker(InCard.Text) && NumsChecker(InPhone.Text) &&
                  InEmail.Text.Length > 0 && InPass.Text.Length > 0 && 
                  InCountry.SelectedIndex != -1 && InAge.SelectedIndex != -1)
            {
                if (ClientsData.Registered(InEmail.Text.ToLower()))
                {
                    Client newUser = new Client(InEmail.Text, InPass.Text, InFName.Text, InLName.Text, InCountry.Text,
                                                InAge.Text, InCard.Text, InPhone.Text,VipCheck.Checked);
                    ClientsData.AddUser(newUser);
                    MessageBox.Show("You Have Been Registered Successfully You Can Login Now!", "Congratulations");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You Have Already Registered An Account!", "Error");
                }
            }
            else
            {
                MessageBox.Show("Please Correct Your Info And Try Again!","Error");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool CharsChecker(string x)
        {
            if (x.Length < 1) return false;
            for (int i = 0; i < x.Length; ++i)
            {
                if ( !(x[i] >= 'A' && x[i] <= 'Z') && !(x[i] >= 'a' && x[i] <= 'z') ) return false;
            }
            return true;
        }
        private bool NumsChecker(string x)
        {
            if (x.Length < 1) return false;
            for (int i = 0; i < x.Length; ++i)
            {
                if (  x[i] < '0' || x[i] > '9' ) return false;
            }
            return true;
        }
    }
}
