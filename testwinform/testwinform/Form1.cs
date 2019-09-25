using System;
using System.Windows.Forms;

namespace testwinform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_MouseMove(object sender, MouseEventArgs e)
        {
            txtname.Text = "FUCK U";
        }

        private void Txtname_MouseLeave(object sender, EventArgs e)
        {
            txtname.Text = "";
        }

        
    }
}
