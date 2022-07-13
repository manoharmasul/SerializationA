using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text.Json;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        FileStream fs;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Employee Emp = new Employee();
                Emp.Id = Convert.ToInt32(txtId.Text);
                Emp.Name = txtName.Text;
                Emp.Salary = Convert.ToInt32(txtSalary.Text);
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\Employee",FileMode.Create,FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, Emp);
                MessageBox.Show("File Created");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }

        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee Emp = new Employee();
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\Employee", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                Emp = (Employee)bf.Deserialize(fs);
                txtId.Text = Emp.Id.ToString();
                txtName.Text = Emp.Name;
                txtSalary.Text = Emp.Salary.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void btnXmlWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Employee Emp = new Employee();
                Emp.Id = Convert.ToInt32(txtId.Text);
                Emp.Name = txtName.Text;
                Emp.Salary = Convert.ToInt32(txtId.Text);
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\EmployeeXml", FileMode.Create, FileAccess.Write);
                XmlSerializer xf = new XmlSerializer(typeof(Employee));
                xf.Serialize(fs, Emp);
                MessageBox.Show("xml File created");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }

        }

        private void btnXmlRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee Emp = new Employee();
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\EmployeeXml",
                    FileMode.Open, FileAccess.Read);
                XmlSerializer xf = new XmlSerializer(typeof(Employee));
                Emp = (Employee)xf.Deserialize(fs);
                txtId.Text = Emp.Id.ToString();
                txtName.Text = Emp.Name;
                txtSalary.Text = Emp.Salary.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }

        }

        private void btnSoapWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Employee Emp = new Employee();
                Emp.Id = Convert.ToInt32(txtId.Text);
                Emp.Name = txtName.Text;
                Emp.Salary = Convert.ToInt32(txtSalary.Text);
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\EmployeeSoap",
                    FileMode.Create, FileAccess.Write);
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, Emp);
                MessageBox.Show("Soap file created");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();

            }

        }

        private void btnSoapRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee Emp = new Employee();
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\EmployeeSoan", FileMode.Open, FileAccess.Read);
                SoapFormatter sf = new SoapFormatter();
                Emp = (Employee)sf.Deserialize(fs);
                txtId.Text = Emp.Id.ToString();
                txtName.Text = Emp.Name;
                txtSalary.Text = Emp.Salary.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        
        private void btnJsonWrite_Click(object sender, EventArgs e)
        {
            try
            {


                Employee Emp = new Employee();
                Emp.Id = Convert.ToInt32(txtId.Text);
                Emp.Name = txtName.Text;
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\EmployeeJson", FileMode.Create, FileAccess.Write);
                Emp.Salary = Convert.ToInt32(txtSalary.Text);

                JsonSerializer.Serialize(fs, Emp);
                MessageBox.Show("Json file is created");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        private void btnJsonRead_Click(object sender, EventArgs e)
        {
            try
            {
                Employee Emp = new Employee();
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\EmployeeJson", FileMode.Open, FileAccess.Read);
                Emp = JsonSerializer.Deserialize<Employee>(fs);


                txtId.Text = Emp.Id.ToString();
                txtName.Text = Emp.Name;
                txtSalary.Text = Emp.Salary.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }

    }
}

