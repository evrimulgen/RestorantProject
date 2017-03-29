using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataModel;
using Moq;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;
using DataStore;
using Repository;

namespace UnitTest
{
    [TestClass]
    public class TestData
    {
        #region Letter
        [TestMethod]
        public void AddLetter()
        {
            using (var db = new ShoppingContext())
            {
                LetterMenu c = new LetterMenu();
                c.Name = "Principal";
                var service = new Repository.Repository(db);
                var query = service.AddLetterMenu(c);
                Assert.IsTrue(query > 0);
            }
        }
        [TestMethod]
        public void UpdateLetter()
        {
            LetterMenu letter;
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                letter = service.GetLetterMenu("Principal");
            }
            using (var db = new ShoppingContext())
            {
                letter.Name = "Vinos";
                var service = new Repository.Repository(db);
                int i = service.UpdateLetter(letter);

                Assert.IsTrue(i > 0);
            }
        }
        [TestMethod]
        public void RemuveLetter()
        {
            LetterMenu letter;
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                letter = service.GetLetterMenu("Principal");
            }
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                int i = service.RemoveLetter(letter);

                Assert.IsTrue(i > 0);
            }
        }
        [TestMethod]
        public void GetLetterComplete()
        {
            LetterMenu letter;
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                letter = service.GetLetterMenuComplete("Principal");
            }
            Assert.IsTrue(letter.Categorys[0].Products.Count > 0);
            
        }
        #endregion
        #region Categority
        [TestMethod]
        public void AddCategory()
        {
            using (var db = new ShoppingContext())
            {
                Category c = new Category();
                c.Description = "Todas las pastas";
                c.Name = "Pastas";
                var service = new Repository.Repository(db);
                var query = service.AddCategority(c,1);

                Assert.IsTrue(query > 0);
            } 
        }
         [TestMethod]
        public void UpdateCategory()
        {
            Category category;
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                category = service.GetCategory(1, "Pastas");
            }
            using (var db = new ShoppingContext())
            {
                category.Name = "Carnes";
                var service = new Repository.Repository(db);
                int i = service.UpdateCategority(category);

                Assert.IsTrue(i > 0);
            }
        }
         [TestMethod]
         public void RemuveCategory()
         {
             Category category;
             using (var db = new ShoppingContext())
             {
                 var service = new Repository.Repository(db);
                 category = service.GetCategory(1, "Carnes");
             }
             using (var db = new ShoppingContext())
             {
                 var service = new Repository.Repository(db);
                 int i = service.RemoveCategority(category);

                 Assert.IsTrue(i > 0);
             }
         }
        #endregion
        #region Product
        [TestMethod]
        public void AddProduct()
        {
            using (var db = new ShoppingContext())
            {
                var product = new Product
                {
                    Name = "Ravioles",
                    Code = "123456",
                    Description = "Ravioles",
                    Price = 200
                };
                var service = new Repository.Repository(db);
                product.CategorityId = service.GetCategory(1,"Pastas").Id;
                int i = service.AddProduct(product);

                Assert.IsTrue(i > 0);
            }
        }
        [TestMethod]
        public void UpdateProduct()
        {
            Product product;
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                product = service.GetProduct(1);
            }
            using (var db = new ShoppingContext())
            {
                product.Name = "Ravioles";
                var service = new Repository.Repository(db);
                int i = service.UpdateProduct(product);

                Assert.IsTrue(i > 0);
            }
        }
        [TestMethod]
        public void RemuveProduct()
        {
            Product product;
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                product = service.GetProduct(1);
            }
            if (product != null)
            {
                using (var db = new ShoppingContext())
                {
                    var service = new Repository.Repository(db);
                    int i = service.RemuveProduct(product);

                    Assert.IsTrue(i > 0);
                }
            }
            else
                Assert.Fail("Product id: "+1+" not exist");
        }
        [TestMethod]
        public void GetProduct()
        {
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                var products = service.GetProducts();
                Assert.IsTrue(products != null);
            }
        }
        #endregion
        #region Waiters
        [TestMethod]
        public void AddWaiter()
        {
            using (var db = new ShoppingContext())
            {
                var product = new Waiter
                {
                   UserName = "gcorrea",
                   Password = "blanquillo0640"
                };
                var service = new Repository.Repository(db);
                bool i = service.AddUser(product);

                Assert.IsTrue(i);
            }
        }
        [TestMethod]
        public void UpdateWaiter()
        {
            Waiter product;
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                product = service.GetUser("psilva");
            }
            using (var db = new ShoppingContext())
            {
                product.Password = "Ravioles";
                var service = new Repository.Repository(db);
                int i = service.UpdateUser(product);

                Assert.IsTrue(i > 0);
            }
        }
        [TestMethod]
        public void RemuveWaiter()
        {
            Waiter product;
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                product = service.GetUser("psilva");
            }
            if (product != null)
            {
                using (var db = new ShoppingContext())
                {
                    var service = new Repository.Repository(db);
                    int i = service.RemoveUser(product);

                    Assert.IsTrue(i > 0);
                }
            }
            else
                Assert.Fail("Product id: " + 1 + " not exist");
        }
        [TestMethod]
        public void GetWaiter()
        {
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                var products = service.GetProducts();
                Assert.IsTrue(products != null);
            }
        }
        #endregion
        #region Table
        [TestMethod]
        public void AddTables()
        {
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                bool i = service.TableRegister(20);

                Assert.IsTrue(i);
            }
        }
        #endregion

        #region Auxiliary
        [TestMethod]
        public void AssignTableUser()
        {
            int i = 0;
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                var user = service.GetUserWithTable("gcorrea");
                if (user == null)
                    Assert.Fail("User not exist");
                else {
                    if (user.Tablets == null)
                        user.Tablets = new List<Table>();
                    user.Tablets.Clear();
                    user.Tablets.AddRange(service.GetTables(new List<int>() { 1,2,3}));
                    i = service.UpdateUser(user);
                }
                Assert.IsTrue(i > 0);
            }
        }
        [TestMethod]
        public void ListTableforUser()
        {
            int i = 0;
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                var user = service.GetUserWithTable("gcorrea");
                if (user == null)
                    Assert.Fail("User not exist");
                
                Assert.IsTrue(user.Tablets.Count > 0);
            }
        }
        [TestMethod]
        public void NewCloseTable()
        {
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                int i = service.NewCloseTbale(1);

                Assert.IsTrue(i > 0);
            }
        }
        [TestMethod]
        public void AddNewOrder()
        {
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                Order or = new Order();
                or.Items = new List<ItemOrder>();
                ItemOrder item = new ItemOrder();
                var products = service.GetProducts();
                item.Prduct = products.ToList()[0];
                item.Count = 2;
                or.Items.Add(item);
                or.Date = DateTime.Now;
                int i = service.AddOrder(1,or);

                Assert.IsTrue(i > 0);
            }
        }
        [TestMethod]
        public void CloseTable()
        {
            using (var db = new ShoppingContext())
            {
                var service = new Repository.Repository(db);
                int i = service.CloseTable(1);

                Assert.IsTrue(i > 0);
            }
        }
        #endregion
    }
}
