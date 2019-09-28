using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DangMNNSE130367_Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loaddata();
        }
        void loaddata()
        {
            StreamReader sr = new StreamReader("Data.txt");
            string line = sr.ReadLine();
            while((line != null) && (line != " "))
            {
                string[] tmp = line.Split(',');
                tblDate.Rows.Add(tmp);
                line = sr.ReadLine();
            }
            sr.Close();
        }
        bool validateInput()
        {
            Regex r = new Regex("[1-9]");
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
                errorProvider1.SetError(txtAge, "Please enter your age!");
                bError = false;
            }
            else
            {
                if (!r.IsMatch(age))
                {
                    errorProvider1.SetError(txtAge, "Must be number!!!!");
                    bError = false;
                }
            }
            
            if (adress.Length == 0)
            {
                errorProvider1.SetError(txtAdress, "Please enter your adress!");
                bError = false;
            }
            //limit it up to 0 - 2 years 
            if (yoe.Length == 0)
            {
                errorProvider1.SetError(txtYoE, "Please enter your Years of Experience !");
                bError = false;
            }
            else
            {
                if (!r.IsMatch(yoe))
                {
                    errorProvider1.SetError(txtYoE, "Must be number!!!!");
                    bError = false;
                }
                else
                {
                    int check = int.Parse(txtYoE.Text);
                    if (check < 0)
                    {
                        errorProvider1.SetError(txtYoE, "Limit it up to 0-2 years!!!");
                        bError = false;
                    }
                }
            }
            
           
                if (phone.Length == 0)
            {
                errorProvider1.SetError(txtPhone, "Please enter your phone!");
                bError = false;
            }
            if (email.Length == 0)
            {
                errorProvider1.SetError(txtEmail, "Please enter your email!");
                bError = false;
            }
            else
            {
                try
                {
                    var mail = new System.Net.Mail.MailAddress(email);
                    bError = true;
                }
                catch
                {
                    errorProvider1.SetError(txtEmail, "Incorrect Email!!!!");
                    bError = false;
                }
            }
           
            if (bError == false)
            {
                return false;
            }
            else
                errorProvider1.Clear();
            return true;
        }

        void addNewEmployee()
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(tblDate);
            char whitespace = ' ' ;
            string[] dates = dtpDate.Value.ToString().Split(whitespace);
            r.SetValues(txtName.Text, txtAge.Text,txtAdress.Text, txtYoE.Text, txtPhone.Text,txtEmail.Text, dates[0]);
            tblDate.Rows.Add(r);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (validateInput() == false)
            {
                return;
            }
                

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
        void updateEmployee()
        {
            if (tblDate.SelectedRows.Count > 0)
            {
                DataGridViewRow r = tblDate.SelectedRows[0];
                r.SetValues(txtName.Text, txtAge.Text, txtAdress.Text, txtYoE.Text, txtPhone.Text, txtEmail.Text, dtpDate.Value);
            }
        }
        private void BtnUpdate_Click(object sender, EventArgs e)
        {

            if (!validateInput())
                return;
            updateEmployee();
        }

        void deleteEmployee()
        {

            if (tblDate.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow r = tblDate.SelectedRows[0];

                    tblDate.Rows.Remove(r);
                    MessageBox.Show("Deleting completed!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are you sure to delete?",
                               "Confirm", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
                deleteEmployee();
        }

        void save()
        {
            StreamWriter sw = new StreamWriter("Data.txt",true);
            for (int i = 0; i < tblDate.Rows.Count - 1; i++)
            {
                if(i == tblDate.NewRowIndex)
                {
                    break;
                }
                String line = "";
                for(int j = 0; j < tblDate.Columns.Count; j++)
                {
                    line += tblDate[j, i].Value + ",";
                }
                sw.WriteLine(line);
            }
            MessageBox.Show("Save Successfull");
            sw.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Are you sure to save?",
                              "Confirm", MessageBoxButtons.YesNo,
                              MessageBoxIcon.Question);
                if (rs == DialogResult.Yes)
                    save();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
