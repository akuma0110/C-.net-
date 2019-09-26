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

        bool validateInput()
        {
            string name = txtFullName.Text;
            bool bError = true;
            if (name.Length == 0)
            {
                //MessageBox.Show("Please enter your name!");
                //error += "Please enter your name!";
                errorProvider1.SetError(txtFullName, "Please enter your name!");
                bError = false;
                //return false;
            }
            DateTime currDate = DateTime.Now;
            int currYear = currDate.Year;
            DateTime DateofBirth = txtDOB.Value;
            int birthYear = DateofBirth.Year;
            if (currYear - birthYear < 18)
            {
                //MessageBox.Show("Age must be greater than or equal to 18");
                errorProvider1.SetError(txtDOB,
                    "Age must be greater than or equal to 18");
                bError = false;
                //return false;
            }
            if (rdMale.Checked == false && rdFemale.Checked == false)
            {
                errorProvider1.SetError(groupBox1, "Please select gender!");
                bError = false;
            }
            if (txtPhone.MaskCompleted == false)
            {
                errorProvider1.SetError(txtPhone,
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

        private void addNewEmployee()
        {
            string gender;
            if (rdMale.Checked)
                gender = "Male";
            else gender = "Female";

            //tbldata.Rows.Add(txtFullName.Text,
            //    txtDOB.Value.ToShortDateString(),
            //    gender, txtNational.Text, txtPhone.Text, txtAddress.Text,
            //    txtQuantification.Text, txtSalary.Text);

            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(tbldata);
            r.SetValues("", txtFullName.Text,
                txtDOB.Value.ToShortDateString(),
                gender, txtNational.Text, txtPhone.Text, txtAddress.Text,
                txtQuantification.Text, txtSalary.Text);
            tbldata.Rows.Add(r);
        }

        private void updateEmployee()
        {
            if (tbldata.SelectedRows.Count > 0)
            {
                DataGridViewRow r = tbldata.SelectedRows[0];
                //r.Cells["clFullName"].Value = txtFullName.Text;
                //r.Cells["clDateofBirth"].Value = txtDOB.Value.ToShortDateString();
                string gender;
                if (rdMale.Checked)
                    gender = "M";
                else gender = "F";
                r.SetValues("",txtFullName.Text,
                txtDOB.Value.ToShortDateString(),
               gender, txtNational.Text, txtPhone.Text, txtAddress.Text,
                txtQuantification.Text, txtSalary.Text);
            }

        }
        private void deleteEmployee()
        {

            if (tbldata.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow r = tbldata.SelectedRows[0];

                    tbldata.Rows.Remove(r);
                    MessageBox.Show("Deleting completed!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (validateInput() == false)
                return;

            try
            {
                addNewEmployee();
                MessageBox.Show("Adding successful!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (!validateInput())
                return;
            updateEmployee();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are you sure to delete?",
                               "Confirm", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
                deleteEmployee();
        }
    }
}
