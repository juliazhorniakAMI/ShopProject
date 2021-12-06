using CursovaApp.BLL.Services.Abstract;
using CursovaApp.Models;
using PZProject.BLL.Services;
using PZProject.BLL.Services.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class RegisterForm : Form
    {
        private LoginForm form;
        bool isAuthorized;
        IServiceWrapper _serviceWrapper;
        Form1 mainForm;
        public RegisterForm(LoginForm _form,  Form1 _mainForm, IServiceWrapper serviceWrapper)
        {
            _serviceWrapper = serviceWrapper;
             mainForm = _mainForm;
            form = _form;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                RoleDTO role = _serviceWrapper.roleService.GetRole("buyer");
                Guid salt = Guid.NewGuid();
                CustomerDTO customer = new CustomerDTO()
                {
                    Id = 0,
                    RoleId = role.Id,
                    FirstName = firstName.Text,
                    LastName = lastName.Text,
                    Mail = mail.Text,
                    Salt = salt,
                    Pass = _serviceWrapper.custService.GetHashStringSHA256(pass.Text, salt.ToString())
                };
                _serviceWrapper.custService.AddCustomer(customer);
                LoginForm form = new LoginForm(mainForm, _serviceWrapper) { StartPosition = FormStartPosition.CenterScreen };
                form.Show();
                this.Dispose();
            }
            catch
            {
                RegisterForm frm = new RegisterForm(form, mainForm, _serviceWrapper) { StartPosition = FormStartPosition.CenterScreen };
                frm.Show();
                this.Dispose();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            form.Show();
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm.tabControl1.SelectedIndex = 0;
            mainForm.Show();
        }

    }
    }

