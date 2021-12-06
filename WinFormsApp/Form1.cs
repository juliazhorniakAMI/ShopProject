using CursovaApp.BLL.Services.Abstract;
using CursovaApp.Models;
using PZProject.BLL.Services;
using PZProject.BLL.Services.Abstract;
using PZProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinFormsApp.ViewModel;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        private IServiceWrapper _servicewrapper;
        List<CartViewModel> cartList;
        double totalSum = 0;
        CustomerDTO customer;
        public string category;
        BindingSource bindingSource = new BindingSource();
        public Form1(CustomerDTO _customer, IServiceWrapper serviceWrapper)
        {
            customer = _customer;
            _servicewrapper = serviceWrapper;
             cartList = new List<CartViewModel>();
            InitializeComponent();
            category = "Daily products";
            dataGridView1.DataSource = _servicewrapper.prodService.GetAllProductsByCategory(_servicewrapper.catService.GetCategory(category));
              
        }
        private void button2_Click(object sender, EventArgs e)
        {
            category = "Fruits";
            dataGridView1.DataSource = _servicewrapper.prodService.GetAllProductsByCategory(_servicewrapper.catService.GetCategory(category));
      
        }
        private void button3_Click(object sender, EventArgs e)
        {
            category = "Vegetables";
            dataGridView1.DataSource = _servicewrapper.prodService.GetAllProductsByCategory(_servicewrapper.catService.GetCategory(category));   
        }
       private void button1_Click(object sender, EventArgs e)
        {
            category = "Daily products";
            dataGridView1.DataSource = _servicewrapper.prodService.GetAllProductsByCategory(_servicewrapper.catService.GetCategory(category));
          
        }    
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 0) {

                if (customer.Id != 0)
                {              
                    button6.Text = "Logout";
                    label6.Text = customer.FirstName;
                    label7.Text = customer.LastName;
                    label8.Text = customer.Role.FullName;                 
                    var list = _servicewrapper.orderDetailsService.GetAllOrdersDetailsByCustomerId(customer.Id).Select(x => new
                    {
                        OrderId = x.OrderId,
                        Category= _servicewrapper.catService.GetCategoryById(x.Product.CategoryId).FullName,
                        Product = x.Product.FullName,
                        Price = x.Product.Price,
                        Quantity = x.Quantity,
                        TotalSum = x.TotalSum,
                        DateOfCreation = x.Order.DateOfCreation

                    }).ToList();
                    dataGridView2.DataSource = list;       
                }
                else
                {
                    LoginForm loginForm = new LoginForm( this, _servicewrapper) { StartPosition = FormStartPosition.CenterScreen };
                    loginForm.Show();
                }
            }
           
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "Logout")
            {
            
                button6.Text = "Login";
                customer.Id=0;
                dataGridView2.DataSource = "";
             
                this.tabControl1.SelectedIndex = 0;
             
            }
            else {
                LoginForm loginForm = new LoginForm(this, _servicewrapper) { StartPosition = FormStartPosition.CenterScreen };
                loginForm.Show();

            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
           int quantity;
            string product = textBox2.Text;
            ProductDTO prod = _servicewrapper.prodService.GetProduct(product);
            double price = prod.Price;
            quantity = int.Parse(textBox3.Text);
            cartList.Add(new CartViewModel { product = prod, quantity = quantity });
            totalSum += price * quantity;
            textBox4.Text = $"{totalSum}";
            dataGridView3.DataSource = cartList.Select(x => new { Product=x.product.FullName,Price=x.product.Price,Quantity=x.quantity}).ToList();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            int rowindex = dataGridView3.CurrentCell.RowIndex;
            CartViewModel model = cartList[rowindex];
            totalSum -= model.product.Price * model.quantity;
            textBox4.Text = $"{totalSum}";
            cartList.RemoveAt(rowindex);
            dataGridView3.DataSource = cartList.Select(x => new { Product = x.product.FullName, Price = x.product.Price, Quantity = x.quantity }).ToList();

        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (cartList.Count > 0)
            {
                OrderDTO order = new OrderDTO() {CustomerId = customer.Id, DateOfCreation = DateTime.Now };
             
                 _servicewrapper.orderService.AddOrder(order);
                OrderDTO newOrder = _servicewrapper.orderService.GetOrderByDate(order.DateOfCreation);
                foreach (var obj in cartList)
                {

                    OrderDetailDTO orderdetail = new OrderDetailDTO()
                    {  ProductId = obj.product.Id, OrderId = newOrder.Id, Quantity = obj.quantity, TotalSum = totalSum };
                    _servicewrapper.orderDetailsService.AddOrderDetail(orderdetail);
                }
                MessageBox.Show("Your order has been added to cart");
                totalSum = 0;
                textBox4.Text = "";
                textBox3.Text = "";
                textBox2.Text = "";
                cartList = new List<CartViewModel>();
                dataGridView3.DataSource = cartList;

            }
            else {

                MessageBox.Show("you haven't added anything to cart");
            }
          
        }
        private void tb_search_KeyPress(object sender, EventArgs e)
        {
            bindingSource.DataSource = _servicewrapper.prodService.GetAllProductsByCategory(_servicewrapper.catService.GetCategory(category));
            dataGridView1.DataSource = bindingSource;
            List<ProductDTO> products = (List<ProductDTO>)bindingSource.DataSource;
            if (textBox1.Text != "")
            {
                dataGridView1.DataSource = _servicewrapper.prodService.FilterProducts(products, textBox1.Text);

            }
            else if (textBox1.Text == "")
            {

                dataGridView1.Refresh();
                dataGridView1.DataSource = products;
            }
        }
        private void tb_Sort(object sender, EventArgs e)
        {
            bindingSource.DataSource = dataGridView1.DataSource;
            dataGridView1.DataSource = bindingSource;
            List<ProductDTO> products = (List<ProductDTO>)bindingSource.DataSource;
            dataGridView1.DataSource = _servicewrapper.prodService.SortProducts(products);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
