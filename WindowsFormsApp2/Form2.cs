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
    public partial class Form2 : Form
    {
        FileStream fs;
        public Form2()
        {
            InitializeComponent();
        }

        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Course cs = new Course();
                cs.Id = Convert.ToInt32(txtId.Text);
                cs.Name = txtName.Text;
                cs.Fees = Convert.ToInt32(txtFess.Text);
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\Course", FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, cs);
                MessageBox.Show("B file created");
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
        

        private void BtnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            { 
            Course cs = new Course();
            fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\Course", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            cs = (Course)bf.Deserialize(fs);
            txtId.Text = cs.Id.ToString();
            txtName.Text = cs.Name;
            txtFess.Text = cs.Fees.ToString();
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

        private void btnXMLWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Course cs = new Course();
                cs.Id = Convert.ToInt32(txtId.Text);
                cs.Name = txtName.Text;
                cs.Fees = Convert.ToInt32(txtFess.Text);
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\CourseXml", FileMode.Create, FileAccess.Write);
                XmlSerializer xs = new XmlSerializer(typeof(Course));
                xs.Serialize(fs, cs);
                MessageBox.Show("Xml file is created");
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

        private void btnXMLRead_Click(object sender, EventArgs e)
        {
            try
            {
                Course cs = new Course();
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\CourseXml", FileMode.Open, FileAccess.Read);
                XmlSerializer xs = new XmlSerializer(typeof(Course));
                cs = (Course)xs.Deserialize(fs);
                txtId.Text = cs.Id.ToString();
                txtName.Text = cs.Name;
                txtFess.Text = cs.Fees.ToString();
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

        private void btnSOAPWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Course cs = new Course();
                cs.Id = Convert.ToInt32(txtId.Text);
                cs.Name = txtName.Text;
                cs.Fees = Convert.ToInt32(txtFess.Text);
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\CoursSoap", FileMode.Create, FileAccess.Write);
                SoapFormatter sf = new SoapFormatter();
                sf.Serialize(fs, cs);
                MessageBox.Show("soap file is created");
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

        private void btnSOAPRead_Click(object sender, EventArgs e)
     
        {
            try
            {
                Course cs = new Course();
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\CoursSoap", FileMode.Open, FileAccess.Read);
                SoapFormatter sf = new SoapFormatter();
                cs = (Course)sf.Deserialize(fs);
                txtId.Text = cs.Id.ToString();
                txtName.Text = cs.Name;
                txtFess.Text = cs.Fees.ToString();
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

        private void btnJSONWrite_Click(object sender, EventArgs e)
        {
            try
            {
                Course cs = new Course();
                cs.Id = Convert.ToInt32(txtFess.Text);
                cs.Name = txtName.Text;
                cs.Fees = Convert.ToInt32(txtFess.Text);
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\CoarseJson", FileMode.Create, FileAccess.Write);
                JsonSerializer.Serialize(fs, cs);
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

        private void btnJSONRead_Click(object sender, EventArgs e)
        {
            try
            {
                Course cs = new Course();
                fs = new FileStream(@"C:\Users\DELL\Documents\Serialization\CoarseJson", FileMode.Open, FileAccess.Read);
                cs = JsonSerializer.Deserialize<Course>(fs);
                txtId.Text = cs.Id.ToString();
                txtName.Text = cs.Name;
                txtFess.Text = cs.Fees.ToString();
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
    }
}
