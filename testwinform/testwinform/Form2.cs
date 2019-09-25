using System.Windows.Forms;

namespace testwinform
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Label1_MouseHover(object sender, System.EventArgs e)
        {
            label1.Text = "Fuck you";
        }

        private void Label1_MouseLeave(object sender, System.EventArgs e)
        {
            label1.Text = "label1";
        }

      
    }
}
