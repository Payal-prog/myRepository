using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSWindowsFormsApp1
{
    public partial class PasswordForm : Form
    {
        public string password;
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void PasswordForm_Load(object sender, EventArgs e)
        {

        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            password=passwordTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
