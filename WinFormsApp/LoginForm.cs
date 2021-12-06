using CursovaApp.BLL.Services.Abstract;
using CursovaApp.Models;
using PZProject.BLL.Services;
using PZProject.BLL.Services.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class LoginForm : Form
    {

        IServiceWrapper _serviceWrapper;
        Form1 form;
        public LoginForm( Form1 _form, IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
            InitializeComponent();
             form = _form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            form.tabControl1.SelectedIndex = 0;
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string loginCustomer = textBox1.Text;
            string passCustomer = textBox2.Text;

            if (_serviceWrapper.custService.CheckIfCustomerExists(loginCustomer, passCustomer))
            {
               
                CustomerDTO c = _serviceWrapper.custService.FindCustomer(loginCustomer, passCustomer);
                if (c.Role.FullName == "buyer")
                {
                    this.Hide();
                    form.Hide();
                    Form1 newForm = new Form1(c,_serviceWrapper) { StartPosition = FormStartPosition.CenterScreen };
                    newForm.Show();
                   
                }

            }
            else {

                MessageBox.Show("Incorect login or pass");
            }

        }
   
        private void button3_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            RegisterForm register = new RegisterForm(this,form, _serviceWrapper) { StartPosition = FormStartPosition.CenterScreen };
            register.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
