using RegistrationLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistrationFormsApp_ZhilinLin
{
    public partial class RegistrationForm : Form
    {
        //delegate declaration
        public delegate void TxtDataCallBack(string str);
        //delegate variable 
        public TxtDataCallBack TxtDatas;

        //variable registration
        Registration registration;
        
        static FileStream fileStream;

        static StreamWriter streamWriter;

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            this.ClearTextBox();//empty all the text filed
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            this.ClearTextBox();//empty all the text filed
        }

        private void BtnSumbit_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {                
                MessageBox.Show("Invalid input! Please try again!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnReset.PerformClick();
                return;           
            }
            DoRegistration();
            MessageBox.Show(registration.ToString());
            this.ClearTextBox();
        }

 
        // method to clear all the text in the textbox
        private void ClearTextBox()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtCity.Clear();
            txtPostCode.Clear();
            txtCountry.Clear();
            txtPhone.Clear();
        }

        // method using delegate to set all the text value to file
        private void DoRegistration()
        {
            registration = new Registration();
            TxtDataCallBack TxtData1 = new TxtDataCallBack(registration.SetFirstName)+ new TxtDataCallBack(WriteToFile);
            TxtDataCallBack TxtData2 = new TxtDataCallBack(registration.SetLastName) + new TxtDataCallBack(WriteToFile); ;
            TxtDataCallBack TxtData3 = new TxtDataCallBack(registration.SetEmail) + new TxtDataCallBack(WriteToFile); ;
            TxtDataCallBack TxtData4 = new TxtDataCallBack(registration.SetAddress) + new TxtDataCallBack(WriteToFile); ;
            TxtDataCallBack TxtData5 = new TxtDataCallBack(registration.SetCity) + new TxtDataCallBack(WriteToFile); ;
            TxtDataCallBack TxtData6 = new TxtDataCallBack(registration.SetPostCode) + new TxtDataCallBack(WriteToFile); ;
            TxtDataCallBack TxtData7 = new TxtDataCallBack(registration.SetCountry) + new TxtDataCallBack(WriteToFile); ;
            TxtDataCallBack TxtData8 = new TxtDataCallBack(registration.SetPhone) + new TxtDataCallBack(WriteToFile); ;
            TxtData1(txtFirstName.Text);
            TxtData2(txtLastName.Text);
            TxtData3(txtEmail.Text);
            TxtData4(txtAddress.Text);
            TxtData5(txtCity.Text);
            TxtData6(txtPostCode.Text);
            TxtData7(txtCountry.Text);
            TxtData8(txtPhone.Text);
        }

        //Write to file 
        public void WriteToFile(string str)
        {
            using (fileStream = new FileStream("registrationData.txt", FileMode.Append, FileAccess.Write))
            {
                using(streamWriter = new StreamWriter(fileStream))
                {
                    streamWriter.WriteLine(str);
                    streamWriter.Flush();
                    streamWriter.Close();
                    fileStream.Close();
                }
            }
        }
        
        //validation for first name
        private void FirstNameField_validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                e.Cancel = true;
                txtFirstName.Focus();
                errpFirstName.SetError(txtFirstName, "Please enter data");
            }
            else
            {
                e.Cancel = false;
                errpFirstName.SetError(txtFirstName, null);
            }
        }

        //validation for last name
        private void LastNameField_validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                e.Cancel = true;
                txtLastName.Focus();
                errpLastName.SetError(txtLastName, "Please enter data");
            }
            else
            {
                e.Cancel = false;
                errpLastName.SetError(txtFirstName, null);
            }
        }
        //validate for email
        private void EmailField_validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errpEmail.SetError(txtEmail, "Please enter data");
            }
            else
            {
                e.Cancel = false;
                errpEmail.SetError(txtEmail, null);
            }
        }
        //validation for postcode
        private void PostCodeField_validating(object sender, CancelEventArgs e)
        {
            string pattern = "^[ABCEGHJ-NPRSTVXY]{1}[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[ ]?[0-9]{1}[ABCEGHJ-NPRSTV-Z]{1}[0-9]{1}$";
            if (!Regex.Match(txtPostCode.Text,pattern).Success)
            {
                e.Cancel = true;
                txtPostCode.Focus();
                errorPostCode.SetError(txtPostCode, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
               errorPostCode.SetError(txtPostCode, null);
            }
        }
        //validation for phone
        private void PhoneField_validating(object sender, CancelEventArgs e)
        {
            if (Regex.Match(txtPhone.Text, @"^(\+[0-9])$").Success)
            {
                e.Cancel = true;
                txtPhone.Focus();
                errpPhone.SetError(txtPhone, "Please enter valid data");
            }
            else
            {
                e.Cancel = false;
                errpPhone.SetError(txtPhone, null);
            }
        }
    }
}
