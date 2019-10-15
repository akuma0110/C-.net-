using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DangMNNSE13067_Lab4
{
    public partial class Form1 : Form
    {
        EmployeesEntities employeeDBE = new EmployeesEntities();
        public Form1()
        {
            InitializeComponent();
            btnDelete.Enabled = false;
            loadData();
        }
        bool validate()
        {
            bool check = true;
            string name = txtName.Text;
            string id = txtID.Text;
            string age = txtAge.Text;
            string address = txtAdress.Text;
            string yoe = txtYOE.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string date = txtDate.Value.ToString();
            //check ID
            if(id.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtID,"Please enter ID.");
            }
            else
            {
                Regex r = new Regex("^SE[0-9]{2,2}");
                if (!r.IsMatch(id))
                {
                    check = false;
                    errorProvider1.SetError(txtID, "Must be in the form SE** !!");
                }
                else
                {
                    var tmp = employeeDBE.Employees.FirstOrDefault(a => a.ID.Equals(txtID.Text));
                    if(tmp != null)
                    {
                        check = false;
                        errorProvider1.SetError(txtID, "Duplicate ID");
                    }
                }
            }
            //check Name
            if (name.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtName, "Please enter Name.");
            }
            //check Age
            if (age.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtAge, "Please enter Age.");
            }
            else
            {
                Regex r1 = new Regex("[0-9]");
                if (!r1.IsMatch(age))
                {
                    check = false;
                    errorProvider1.SetError(txtAge, "Age must be number.");
                }
                else
                {
                    int checkage = int.Parse(age);
                    if (checkage < 17)
                    {
                        check = false;
                        errorProvider1.SetError(txtAge, "Age must be greater than 17.");
                    }
                }
            }
            //check address
            if(address.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtAdress,"Please enter address!!!");
            }
            //check YOE
            if (yoe.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtYOE, "Please enter address!!!");
            }
            else
            {
                Regex r1 = new Regex("[0-9]");
                if (!r1.IsMatch(yoe))
                {
                    check = false;
                    errorProvider1.SetError(txtYOE, "Must be number");
                }
                else
                {
                    int checkrank = int.Parse(yoe);
                    if(checkrank > 2 || checkrank < 0)
                    {
                        check = false;
                        errorProvider1.SetError(txtYOE, "Limit it up to 0-2 years");
                    }
                }
            }
            //check phone
            if(phone.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtPhone, "Please enter phone number!!!");
            }
            //check email
            if (email.Length == 0)
            {
                errorProvider1.SetError(txtEmail, "Please enter your email!");
                check = false;
            }
            else
            {
                try
                {
                    var mail = new System.Net.Mail.MailAddress(email);
                    check = true;
                }
                catch
                {
                    errorProvider1.SetError(txtEmail, "Incorrect Email!!!!");
                    check = false;
                }
            }
            //check date
            if(date.Length == 0)
            {
                check = false;
                errorProvider1.SetError(txtDate, "Please enter date of joining");
            }

            if (check == false)
            {
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            return true;
        }
        void loadData()
        {
            tblData.Rows.Clear();
            foreach (Employee x in employeeDBE.Employees)
            {
                tblData.Rows.Add(x.ID, x.Name, x.Age, x.Address, x.Years_of_Experience, x.Phone, x.Email, x.Date_of_Joining);
            }
        }

        void addnew()
        {
                Employee em = new Employee();
                em.ID = txtID.Text;
                em.Name = txtName.Text;
                em.Age = int.Parse(txtAge.Text);
                em.Address = txtAdress.Text;
                em.Years_of_Experience = int.Parse(txtYOE.Text);
                em.Phone = txtPhone.Text;
                em.Email = txtEmail.Text;
                em.Date_of_Joining = txtDate.Value;
                employeeDBE.Employees.Add(em);
                employeeDBE.SaveChanges();
                loadData();
        }

        void delete()
        {
            if(tblData.SelectedRows.Count > 0)
            {
                try
                {
                    Employee em = new Employee();
                    DataGridViewRow tbl = tblData.SelectedRows[0];
                    string id = tbl.Cells["colID"].Value.ToString();
                    employeeDBE.Employees.Remove(employeeDBE.Employees.Find(id));
                    loadData();
                    MessageBox.Show("Delete Completed");
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        void update()
        {
            Employee em = new Employee();
            DataGridViewRow tbl = tblData.SelectedRows[0];
            string id =  tbl.Cells["colID"].Value.ToString();
            Employee tmp = employeeDBE.Employees.SingleOrDefault(g => g.ID.Equals(id));
            if(tmp != null)
            {
            tmp.ID = txtID.Text;
            tmp.Name = txtName.Text;
            tmp.Age = int.Parse(txtAge.Text);
            tmp.Address = txtAdress.Text;
            tmp.Years_of_Experience = int.Parse(txtYOE.Text);
            tmp.Phone = txtPhone.Text;
            tmp.Email = txtEmail.Text;
            tmp.Date_of_Joining = txtDate.Value;
            employeeDBE.SaveChanges();
            }
            else
            {
                MessageBox.Show("Not Found!!!");
            }
        }

        void search()
        {
            tblData.Rows.Clear();
            string name = txtSearch.Text;
            var tmp = (from g in employeeDBE.Employees where g.Name.Contains(name) select g);
            foreach (Employee x in tmp)
            {
                tblData.Rows.Add(x.ID, x.Name, x.Age, x.Address, x.Years_of_Experience, x.Phone, x.Email, x.Date_of_Joining);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (validate() == false)
            {
                return;

            }
            try
            {

                addnew();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (validate() == false)
            {
                return;

            }
            try
            {

                update();
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Are you sure to delete?",
                               "Confirm", MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
                delete();
        }

        private void TblData_MouseClick(object sender, MouseEventArgs e)
        {
            btnDelete.Enabled = true;
            txtID.Enabled = false;
            DataGridViewRow tbl = tblData.SelectedRows[0];
            string id = tbl.Cells["colID"].Value.ToString();
            Employee tmp = employeeDBE.Employees.SingleOrDefault(g => g.ID.Equals(id));
            if (tmp != null)
            {
                txtID.Text = tmp.ID;
                txtName.Text = tmp.Name;
                txtAge.Text = tmp.Age.ToString();
                txtAdress.Text = tmp.Address;
                txtYOE.Text = tmp.Years_of_Experience.ToString();
                txtPhone.Text = tmp.Phone.ToString();
                txtEmail.Text = tmp.Email.ToString();
                txtDate.Value = tmp.Date_of_Joining.Value;
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtAge.Text = "";
            txtAdress.Text = "";
            txtYOE.Text = "";
            txtPhone.Text = "";
            txtEmail.Text ="";
            txtDate.Value = DateTime.Now;
            tblData.ClearSelection();
            btnDelete.Enabled = false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                search();
            }catch(DbUpdateException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TblData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
