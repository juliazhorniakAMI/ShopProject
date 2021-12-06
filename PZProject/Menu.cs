//using CursovaApp.BLL.Services.Abstract;
//using CursovaApp.DAL.Repositories;
//using CursovaApp.Models;
//using CursovaApp.Repositories;
//using PZProject.BLL.Services.Abstract;
//using PZProject.BLL.Services.Impl;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using PZProject.DAL.Models;
//namespace PZProject
//{
//    public class Menu
//    //{
//    //    public static IProductService _prodService = new ProductService(new ProductRepository(new ShopPZContext()));
//    //    public static IOrderDetailsService _OrderDetailsService = new OrderDetailsService(new OrderDetailRepository(new ShopPZContext()));
//    //    public static ICustomerService _custService = new CustomerService(new CustomerRepository(new ShopPZContext()));
//    //    public static ICategoryService _categService = new CategoryService(new CategoryRep(new ShopPZContext()));
//    //    public static IOrderService _OrderService = new OrderService(new OrderRepository(new ShopPZContext()));
//    //    public static IRoleService _roleService = new RoleService(new RoleRepository(new ShopPZContext()));


//        public Menu()
//        {
//            Show();
//        }
//        public static void RegisterCustomer()
//        {

//            string name;
//            string surname;
//            string mail;
//            string pass;
//            RoleDTO role = _roleService.GetRole("buyer");

//            Console.WriteLine("Register:");
//            Console.WriteLine("Enter first name:");
//            name = Console.ReadLine();
//            Console.WriteLine("Enter last name:");
//            surname = Console.ReadLine();
//            Console.WriteLine("Enter mail :");
//            mail = Console.ReadLine();
//            Console.WriteLine("Enter pass :");
//            pass = Console.ReadLine();
//            CustomerDTO customer = new CustomerDTO()
//            {
//                Id = 0,
//                RoleId = role.Id,
//                FirstName = name,
//                LastName = surname,
//                Mail = mail,
//                Pass = _custService.GetHashStringSHA256(pass)
//            };
//            _custService.AddCustomer(customer);

//        }

//        public static void PrintProductsByCategories(string cat, List<CategoryDTO> currCat, ref bool m)
//        {
//            foreach (var x in currCat)
//            {
//                if (x.FullName == cat)
//                {
//                    foreach (var obj in _prodService
//                        .GetAllProductsByCategory(x))
//                    {
//                        Console.Write($"Name: {obj.FullName} Price: {obj.Price}\n");
//                    }

//                    break;
//                }


//            }
//        }

//        public static void FilterSort(List<ProductDTO> list)
//        {
//            while (true)
//            {

//                Console.WriteLine("\n\nSort products (1)");
//                Console.WriteLine("Search products (2)");
//                Console.WriteLine("Pick products (3)");
//                int x = Convert.ToInt32(Console.ReadLine());
//                if (x == 1)
//                {

//                    foreach (var o in _prodService.SortProducts(list))
//                    {
//                        Console.Write($"Name: {o.FullName} Price: {o.Price}\n");
//                    }
//                }
//                else if (x == 2)
//                {
//                    Console.Write("Search: ");
//                    string tmp = Console.ReadLine();
//                    foreach (var o in _prodService.FilterProducts(list, tmp))
//                    {
//                        Console.Write($"Name: {o.FullName} Price: {o.Price}\n");
//                    }

//                }
//                else
//                {

//                    break;
//                }

//            }

//        }

//        public static void AdminSettings(int tmp)
//        {

//            switch (tmp)
//            {
//                case 4:
//                    Console.WriteLine("a.Add category");
//                    Console.WriteLine("b.Edit category");
//                    Console.WriteLine("c.Delete category");
//                    string str = Console.ReadLine();
//                    switch (str)
//                    {
//                        case "a":

//                            Console.WriteLine("Enter category:");
//                            string catName = Console.ReadLine();
//                            _categService.AddCategory(new CategoryDTO() { Id = _categService.GetAllCategories().Count + 1, FullName = catName });
//                            CategoryDTO cat3 = _categService.GetCategory(catName);
//                            while (true)
//                            {
//                                Console.WriteLine("Enter product:");
//                                string catName2 = Console.ReadLine();



//                                Console.WriteLine("Enter price for the product:");
//                                int price = Convert.ToInt32(Console.ReadLine());
//                                _prodService.AddProduct(new ProductDTO() { Id = 0, FullName = catName2, CategoryId = cat3.Id, Price = price });
//                                Console.WriteLine("More products:Yes/No");
//                                string s = Console.ReadLine();
//                                if (s != "Yes")
//                                {
//                                    break;
//                                }

//                            }

//                            break;
//                        case "b":
//                            Console.WriteLine("Enter category:");
//                            string cat = Console.ReadLine();
//                            Console.WriteLine("Change it's name:");
//                            string cat2 = Console.ReadLine();
//                            CategoryDTO C = _categService.GetCategory(cat);
//                            C.FullName = cat2;
//                            _categService.UpdateCategory(C);


//                            break;
//                        case "c":
//                            Console.WriteLine("Enter category:");
//                            string deleteCat = Console.ReadLine();

//                            CategoryDTO C2 = _categService.GetCategory(deleteCat);
//                            List<ProductDTO> prods = _prodService.GetAllProductsByCategory(C2);
//                            foreach (var x in prods)
//                            {
//                                _prodService.DeleteProduct(x.Id);

//                            }
//                            _categService.DeleteCategory(C2.Id);


//                            break;



//                    }
//                    break;
//                case 5:
//                    Console.WriteLine("a.Add product");
//                    Console.WriteLine("b.Edit product");
//                    Console.WriteLine("c.Delete product");
//                    string strProd = Console.ReadLine();
//                    switch (strProd)
//                    {
//                        case "a":
//                            Console.WriteLine("Enter product:");
//                            string Name = Console.ReadLine();
//                            Console.WriteLine("Enter category for the product:");
//                            string catName = Console.ReadLine();
//                            CategoryDTO category = _categService.GetCategory(catName);
//                            Console.WriteLine("Enter price for the product:");
//                            int price = Convert.ToInt32(Console.ReadLine());
//                            _prodService.AddProduct(new ProductDTO() { Id = 0, FullName = Name, CategoryId = category.Id, Price = price });


//                            break;
//                        case "b":
//                            Console.WriteLine("Enter product:");
//                            string cat = Console.ReadLine();
//                            ProductDTO P = _prodService.GetProduct(cat);
//                            Console.WriteLine("Change it's price:");
//                            int price2 = Convert.ToInt32(Console.ReadLine());
//                            P.Price = price2;
//                            _prodService.UpdateProduct(P);


//                            break;
//                        case "c":
//                            Console.WriteLine("Enter product:");
//                            string prodName = Console.ReadLine();

//                            ProductDTO P2 = _prodService.GetProduct(prodName);

//                            _prodService.DeleteProduct(P2.Id);


//                            break;



//                    }
//                    break;
//                case 6:
//                    Console.WriteLine("a.Show all orders");
//                    Console.WriteLine("b.Delete order");
//                    string strOrder = Console.ReadLine();
//                    switch (strOrder)
//                    {
//                        case "a":
//                            foreach (var x in _OrderDetailsService.GetAllOrdersDetails())
//                            {
//                                OrderDTO r = _OrderService.GetOrderById(x.Order.Id);
//                                CustomerDTO C = _custService.GetCustomerById(r.CustomerId);
//                                ProductDTO Product = _prodService.GetProductById(x.ProductId);

//                                Console.Write($"OrderId :{r.Id} Customer: {C.FirstName} {C.LastName} Product: {Product.FullName} Quantity: {x.Quantity} Price: {Product.Price} Date: {r.DateOfCreation} Total Sum: {x.TotalSum}\n");
//                            }
//                            break;
//                        case "b":
//                            Console.WriteLine("Enter id of the order:");
//                            int id = Convert.ToInt32(Console.ReadLine());
//                            foreach (var x in _OrderDetailsService.GetAllOrdersDetailsByOrderId(id))
//                            {
//                                _OrderDetailsService.DeleteOrderItemById(x.Id);

//                            }





//                            break;


//                    }
//                    break;
//            }





//        }


//        public static void Show()
//        {


//        Start:
//            Console.WriteLine("login (1) | Register (2)");
//            var input = Console.ReadLine();
//            bool successfull = false;
//            while (!successfull)
//            {
//                if (input == "1")
//                {
//                    Console.Write("Login:");
//                    var email = Console.ReadLine();
//                    Console.Write("Password:");
//                    var password = Console.ReadLine();

//                    if (_custService.CheckIfCustomerExists(email, password))
//                    {
//                        CustomerDTO c = _custService.FindCustomer(email, password);

//                        successfull = true;
//                        while (true)
//                        {
//                        Options:
//                            Console.WriteLine("\n                        Choose an option: \n\n\n");

//                            Console.WriteLine("1. Show your role");
//                            Console.WriteLine("2. Show categories");
//                            Console.WriteLine("3. Log out");
//                            if (c.Role.FullName == "admin")
//                            {

//                                Console.WriteLine("4.Settings for categories");
//                                Console.WriteLine("5.Settings for products");
//                                Console.WriteLine("6.Settings for orders");

//                            }
//                            int tmp = Convert.ToInt32(Console.ReadLine());
//                            bool m = true;
//                            bool b = true;
//                            string product;
//                            List<ProductDTO> prodList = new List<ProductDTO>();
//                            double sum = 0;
//                            if (tmp == 4 || tmp == 5 || tmp == 6)
//                            {
//                                AdminSettings(tmp);
//                                goto Options;
//                            }

//                            switch (tmp)
//                            {
//                                case 1:
//                                    Console.WriteLine("Info of the customer:\n");
//                                    Console.Write($"First Name: {c.FirstName} Last Name: {c.LastName} Role: {c.Role.FullName}\n");
//                                    break;
//                                case 2:
//                                Category:

//                                    Console.WriteLine("Pick Category:\n");
//                                    foreach (var x in _categService.GetAllCategories())
//                                    {
//                                        Console.WriteLine(x.FullName);
//                                    }
//                                    string cat = Console.ReadLine();
//                                    CategoryDTO currCat = _categService.GetCategory(cat);
//                                    PrintProductsByCategories(cat, _categService.GetAllCategories(), ref m);

//                                    if (!m)
//                                    {
//                                        goto Start;

//                                    }
//                                    FilterSort(_prodService
//                                        .GetAllProductsByCategory(currCat));
//                                    Console.WriteLine("Enter a product:");
//                                    product = Console.ReadLine();
//                                    prodList.Add(_prodService.GetProduct(product));
//                               -------     sum = prodList.Sum(x => x.Price);
//                                    Console.WriteLine("Anything else?Yes/No");

//                                    string check = Console.ReadLine();
//                                    if (check == "Yes")
//                                    {
//                                        goto Category;

//                                    }
//                                    Console.WriteLine("Add to cart?Yes/No");
//                                    string check2 = Console.ReadLine();
//                                    if (check2 != "Yes")
//                                    {
//                                        break;
//                                    }
//                                    else
//                                    {
//                                        OrderDTO order = new OrderDTO() { CustomerId = c.Id, DateOfCreation = DateTime.Now };
//                                        _OrderService.AddOrder(order);
//                                        OrderDTO newOrder = _OrderService.GetOrderByDate(order.DateOfCreation);
//                                        newOrder.Customer = c;

//                                        List<OrderDetailDTO> detailsList = new List<OrderDetailDTO>();
//                                        OrderDetailDTO orderdetail = null;

//                                        foreach (var obj in prodList)
//                                        {
//                                            orderdetail = null;
//                                            orderdetail = new OrderDetailDTO()
//                                            { Id = 0, ProductId = obj.Id, OrderId = newOrder.Id, Quantity = 1, TotalSum = sum };
//                                            _OrderDetailsService.AddOrderDetail(orderdetail);
//                                            orderdetail.Order = newOrder;
//                                            orderdetail.Product = obj;
//                                            detailsList.Add(orderdetail);
//                                        }
//                                        Console.WriteLine("Order details:");
//                                        foreach (var obj in detailsList)
//                                        {
//                                            Console.Write($"Customer:{obj.Order.Customer.FirstName} {obj.Order.Customer.LastName} Product:{obj.Product.FullName} Quantity:{obj.Quantity} Price:{obj.Product.Price} Date:{obj.Order.DateOfCreation.Date}\n");
//                                        }
//                                        Console.Write($"\n-----Total sum------:{sum}\n");
//                                        Console.WriteLine("Would you like to change quantity of some products?Yes/No");
//                                        string check3 = Console.ReadLine();
//                                        if (check3 != "Yes")
//                                        {
//                                            Console.WriteLine("\nYour order has successfully been added to the cart :)\n");
//                                            break;
//                                        }
//                                        while (true)
//                                        {
//                                            Console.WriteLine("Choose product to change its quantity:");
//                                            string prod = Console.ReadLine();
//                                          ProductDTO pr=  _prodService.GetProduct(prod);
//                                            Console.WriteLine("Quantity:");
//                                            int quantity = Convert.ToInt32(Console.ReadLine());
//                                ------------            sum += pr.Price* quantity;
//                                            List<OrderDetailDTO> arr =
//                                                _OrderDetailsService.GetAllOrdersByCustomerId(c.Id);
//                                            _OrderDetailsService.UpdateTotalSum(arr, sum);
//                                            _OrderDetailsService.UpdateOrderItemByQuantity(c.Id, prod, quantity, sum);
//                                            Console.WriteLine("Anything else to change?Yes/No");
//                                            string check4 = Console.ReadLine();
//                                            if (check4 != "Yes")
//                                            {
//                                                foreach (var obj in detailsList)
//                                                {
//                                                    Console.Write($"Customer: {obj.Order.Customer.FirstName} {obj.Order.Customer.LastName} Product: {obj.Product.FullName} Quantity: {obj.Quantity} Price: {obj.Product.Price} Date: {obj.Order.DateOfCreation}\n");
//                                                }
//                                                Console.Write($"\n------Total sum------:{sum}\n\n");
//                                                Console.WriteLine("\nYour order has successfully been added to the cart :)\n");
//                                                break;
//                                            }
//                                        }
//                                        break;
//                                    }
//                                case 3:
//                                    b = false;
//                                    break;
//                            }
//                            if (!b)
//                            {
//                                break;
//                            }
//                        }
//                        goto Start;

//                    }
//                    if (!successfull)
//                    {
//                        Console.Write("Error The Username or Password you Entered is Incorrect.\n");
//                        goto Start;
//                    }

//                }

//                else if (input == "2")
//                {
//                    RegisterCustomer();
//                    successfull = true;
//                    goto Start;
//                }
//            }

//        }
//    }
//}
