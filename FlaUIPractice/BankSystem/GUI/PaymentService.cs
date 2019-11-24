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
    public partial class PaymentService : Form
    {
        public PaymentService()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==-1)
            {
                MessageBox.Show("Please Select A Service", "Error");
            }
            else
            {
                (new PayMent(comboBox1.Text)).ShowDialog();
                this.Close();
            }
        }
    }
}
