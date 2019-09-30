using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace DangMNNSE13067_Lab4
{
    public partial class Form1 : Form
    {
        EmployeesEntities employeeDBE = new EmployeesEntities();
        public Form1()
        {
            InitializeComponent();
            loadData();
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
            try
            {
                Employee em = new Employee();
                em.ID = txtID.Text;
                em.Age = int.Parse(txtAge.Text);
                em.Address = txtAdress.Text;
                em.Years_of_Experience = int.Parse(txtYOE.Text);
                em.Phone = int.Parse(txtPhone.Text);
                em.Email = txtEmail.Text;
                em.Date_of_Joining = txtDate.Value;
                employeeDBE.Employees.Add(em);
                employeeDBE.SaveChanges();
                loadData();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void delete()
        {
            if(tblData.SelectedRows.Count > 0)
            {
                try
                {
                    Employee em = new Employee();
                    DataGridViewRow tbl = tblData.SelectedRows[0];
                    int id = int.Parse(tbl.Cells["colID"].Value.ToString());
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
            try
            {
                Employee em = new Employee();
                DataGridViewRow tbl = tblData.SelectedRows[0];
                string id =  tbl.Cells["colID"].Value.ToString();
                Employee tmp = (from g in employeeDBE.Employees where g.ID.Equals(id) select g).FirstOrDefault();
                tmp.ID = txtID.Text;
                tmp.Name = txtName.Text;
                tmp.Age = int.Parse(txtAge.Text);
                tmp.Address = txtAdress.Text;
                tmp.Years_of_Experience = int.Parse(txtYOE.Text);
                tmp.Phone = int.Parse(txtPhone.Text);
                tmp.Email = txtEmail.Text;
                tmp.Date_of_Joining = txtDate.Value;
                employeeDBE.SaveChanges();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
