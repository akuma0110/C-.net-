using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DangMNNSE130367_Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool validateInput()
        {
            string name = txtName.Text;
            string age = txtAge.Text;
            string adress = txtAdress.Text;
            string yoe = txtYoE.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            bool bError = true;
            if (name.Length == 0)
            {
                errorProvider1.SetError(txtName, "Please enter your name!");
                bError = false;
            }
            if (age.Length == 0)
            {
                errorProvider1.SetError(txtName, "Please enter your age!");
                bError = false;
            }
            if (adress.Length == 0)
            {
                errorProvider1.SetError(txtName, "Please enter your adress!");
                bError = false;
            }
            //
            if (yoe.Length == 0)
            {
                errorProvider1.SetError(txtName, "Please enter your Years of Experience !");
                bError = false;
            }
            //check nhap so
            if (phone.Length == 0)
            {
                errorProvider1.SetError(txtName, "Please enter your phone!");
                bError = false;
            }
            if (email.Length == 0)
            {
                errorProvider1.SetError(txtName, "Please enter your email!");
                bError = false;
            }
            DateTime currDate = DateTime.Now;
            int currYear = currDate.Year;
            DateTime DateofBirth = dTPDOB.Value;
            int birthYear = DateofBirth.Year;
            if (currYear - birthYear < 18)
            {
                //MessageBox.Show("Age must be greater than or equal to 18");
                errorProvider1.SetError(dTPDOB,
                    "Age must be greater than or equal to 18");
                bError = false;
                //return false;
            }
            if (radMale.Checked == false && radFemale.Checked == false)
            {
                errorProvider1.SetError(groupBox1, "Please select gender!");
                bError = false;
            }
            if (mtxtPhone.MaskCompleted == false)
            {
                errorProvider1.SetError(mtxtPhone,
                    "please enter required digit!");
                bError = false;
            }
            if (bError == false)
            {
                return false;
            }
            else
                errorProvider1.Clear();
            return true;
        }
    }
}
