using DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    public class ShoppingMoqContext
    {
        public List<LetterMenu> LetterMenu { get; set; } 
        public List<Product> Products { get; set; }
        public List<Category> Categorys { get; set; }
        public List<Waiter> Waiters { get; set; }
        public List<Order> Orders { get; set; }
        public List<Table> Tables { get; set; }
        public ShoppingMoqContext()
        {
            Initilized();
        }
        private void Initilized()
        {
            Letter();
            Categority();
            Product();
            Waiter();
            Table();

            LetterMenu[0].Categorys = Categorys;
            foreach (var item in Categorys)
            {
                item.Products = new List<Product>();
                item.Products.AddRange(Products);
            }
            foreach (var item in Waiters)
            {
                item.Tablets = Tables;
            }

        }
        private void Letter()
        {
            LetterMenu response = new LetterMenu() { Id = GetId()};
            LetterMenu = new List<LetterMenu>() { response};
        }
        private void Product()
        {
            Products = new List<Product>(){
                        new Product(){ Id = GetId(),Name="Asado", Price=100 },
                        new Product(){Id = GetId(),Name="Morzilla", Price=50},
                         new Product(){Id = GetId(),Name="Ravioles", Price=150},
                          new Product(){Id = GetId(),Name="Tallarines", Price=98},
                          new Product(){Id = 0,Name="Mixta", Price=100},
                         new Product(){Id = 1,Name="Rusa", Price=50},
                         new Product(){Id = 0,Name="Helado", Price=150},
                         new Product(){Id = 1,Name="Crema", Price=98}
            };
        }
        private void Categority()
        {
            Categorys = new List<Category>(){
                        new Category(){Name="Carnes",Description="Carnes",Id = GetId()},
                        new Category(){Name="Pastas",Description="Pastas",Id = GetId()},
                        new Category(){Name="Ensaladas",Description="Ensaladas",Id = GetId()},
                        new Category(){Name="Postres",Description="Postres",Id = GetId()},

            };
        }
        private void Table()
        {
            Tables = new List<Table>(){
                new Table() { Number=1,State= "Libre"},
                 new Table() { Number=2,State= "Libre"},
                  new Table() { Number=3,State= "Libre"},
                   new Table() { Number=4,State= "Libre"},
                    new Table() { Number=5,State= "Libre"},
                   new Table() { Number=6,State= "Libre"}
            };
        }
        public void Waiter()
        {
            Waiters = new List<Waiter>()
            {
                new Waiter(){Password="geocom",UserName="psilva",Id= Guid.NewGuid()}
            };
        }
        static int i = -1;
        int GetId()
        {
            i++;
            return i;
        }
    }
}
