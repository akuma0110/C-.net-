using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Linq;

namespace testwinform
{
    public partial class Form1 : Form
    {
        EmployeeDBEntities1 employeeDBE = new EmployeeDBEntities1();

        public Form1()
        {
            InitializeComponent();
            loadData();
        }
        void addnew()
        {
            Employee ex = new Employee();


            if (rdMale.Checked)
                ex.Gender = "M";
            else ex.Gender = "F";

            ex.FullName = txtFullName.Text;
            ex.DateOfBirth = txtDOB.Value;
            ex.Address = txtAddress.Text;
            ex.National = txtNational.Text;
            ex.Phone = txtPhone.Text;
            ex.Qualification = txtQuantification.Text;
            ex.Salary = int.Parse(txtSalary.Text);
            employeeDBE.Employees.Add(ex);
            employeeDBE.SaveChanges();
            loadData();
        }
        void loadData()
        {
            tbldata.Rows.Clear();
            foreach (Employee x in employeeDBE.Employees)
            {
                tbldata.Rows.Add(x.ID, x.FullName, x.DateOfBirth, x.Gender, x.National, x.Phone, x.Address, x.Qualification, x.Salary);
                

            }
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
        /*
        void LoadEmployeeInfo()
        {
            //Create an open connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"server=.\sqlexpress;database=EmployeeDB;uid=sa;pwd=1";
            //@"server=.\sqlexpress;database=EmployeeDB;uid=sa;pwd=123456";
            con.Open();

            //Create a SQL Command object
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            //Use a SQL string
            cmd.CommandText = "SELECT * FROM   Employees";

            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();
            tbldata.Rows.Clear();
            while (dr.Read())
            {
                ///dr.GetDateTime(2).ToShortDateString();
                tbldata.Rows.Add(dr.GetInt32(0), dr[1].ToString(),
                    DateTime.Parse(dr[2].ToString()).ToShortDateString(),
                    dr[3].ToString(), dr[4].ToString(),
                    dr[5].ToString(), dr[6].ToString(), dr[7].ToString(),
                    double.Parse(dr[8].ToString()));
            }
            dr.Close();
            con.Close();
        }
       
        /*
        void addNewEmployee()
        {
            string gender = "";
            if (rdMale.Checked)
                gender = "M";
            else gender = "F";

            // Create an open a connection.
            SqlConnection con = new SqlConnection();
            con.ConnectionString =
           @"server=.\sqlexpress;database=EmployeeDB;uid=sa;pwd=1";
            con.Open();

            // Create a SQL command object
            SqlCommand cmd = new SqlCommand();

            // Create a SQL string

            cmd.commandtype = commandtype.text;
            string salary = "";
            if (txtsalary.text.length == 0)
                salary = "null";
            else salary = txtsalary.text;
            string sql = string.format("insert into employees (fullname,dateofbirth,"
                        + "gender,[national],phone,address,qualification,salary) "
                        + "values('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7})",
                        txtfullname.text, dtpdob.value.toshortdatestring(), gender,
                        cbnational.text, mtxtphone.text, txtaddress.text,
                        cbqualification.text, salary);

            // Use a SQL stored procedure
            /* 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertEmployee";

            SqlParameter param = new SqlParameter("@FullName", SqlDbType.VarChar, 50);
            param.Value = txtFullName.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@DOB", SqlDbType.DateTime);
            param.Value = dTPDOB.Value.ToShortDateString();
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Gender", SqlDbType.Char, 1);
            param.Value = gender;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@National", SqlDbType.VarChar, 50);
            param.Value = cbNational.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Phone", SqlDbType.VarChar, 50);
            param.Value = mtxtPhone.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Address", SqlDbType.VarChar, 50);
            param.Value = txtAddress.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Qualification", SqlDbType.VarChar, 50);
            param.Value = cbQualification.Text;
            cmd.Parameters.Add(param);

            param = new SqlParameter("@Salary", SqlDbType.Money);
            if (txtSalary.Text.Length == 0)
                param.Value = DBNull.Value;
            else
                param.Value = txtSalary.Text;
            cmd.Parameters.Add(param);

            // Execute using our connection
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
    */
        /*
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
        */
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
        void delete()
        {
            if (tbldata.SelectedRows.Count > 0)
            {
                try
                {
                
                    
                    Employee e = new Employee();
                    DataGridViewRow r = tbldata.SelectedRows[0];
                    int id = int.Parse(r.Cells["txtId"].Value.ToString());

                    employeeDBE.Employees.Remove(employeeDBE.Employees.Find(id));
                    employeeDBE.SaveChanges();
                    loadData();
                    MessageBox.Show("Deleting completed!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void search()
        {
            tbldata.Rows.Clear();
            string name = txtSearchName.Text;
            var tmp = (from g in employeeDBE.Employees where g.FullName.Contains(name) select g);
            foreach(Employee x in tmp)
            {
                tbldata.Rows.Add(x.ID, x.FullName, x.DateOfBirth, x.Gender, x.National, x.Phone, x.Address, x.Qualification, x.Salary);
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
                //addNewEmployee();
                addnew();
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
                delete();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchName.Text.Length == 0 )
            {
                errorProvider1.SetError(txtSearchName, "Search must be Null");
            }
            else
            {
                search();
            }
        }

        private void BtnSearchAll_Click(object sender, EventArgs e)
        {
            tbldata.Rows.Clear();
            loadData();
        }
    }
}
