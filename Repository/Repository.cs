using DataModel;
using DataStore;
using MyLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Repository : IRepository
    {
        private ShoppingContext _context = null;
        public Repository(ShoppingContext context)
        {
            _context = context;
            _context.Database.Log = logInfo => Logger.Log(logInfo);
        }
        public Repository()
        {
            _context = new ShoppingContext();
        } 
        #region Product
        public Product GetProduct(string name, int category)
        {
            return _context.Products.FirstOrDefault(x => x.Name == name && x.CategorityId == category);
        }
        public IEnumerable<Product> GetProducts(Category cat)
        {
            return _context.Products.Where(x => x.CategorityId == cat.Id).ToList();
        }
        public int RemuveProduct(Product product)
        {
            _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
            var p = _context.Products.Remove(product);
            return _context.SaveChanges();
        }
        public Product GetProduct(int id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        public int AddProduct(Product product)
        {
            var c = _context.Products.FirstOrDefault(x => x.Name == product.Name);
            if (c == null)
            {
                _context.Products.Add(product);
                return _context.SaveChanges();
            }
            else
                return 0;
        }

        public int UpdateProduct(Product product)
        {
            int i = 0;
            var c = _context.Products.FirstOrDefault(x => x.Name == product.Name);
            if (c == null)
            {
                _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
               i = _context.SaveChanges();
            }

            return i;
        }
   

        #endregion

        #region Waiter
        public Waiter GetUser(Guid id)
        {
            return _context.Waiters.SingleOrDefault(x => x.Id == id);
        }
        public Waiter GetUser(string userName)
        {
            throw new NotImplementedException();
        }
        public Waiter GetUser(string username, string password)
        {
            return _context.Waiters.FirstOrDefault(x => x.UserName == username && x.Password == password);
        }
        public bool AddUser(Waiter user)
        {
            var c = _context.Waiters.FirstOrDefault(x => x.UserName == user.UserName);
            if (c == null)
            {
                user.Id = Guid.NewGuid();
                _context.Waiters.Add(user);
                return _context.SaveChanges() > 0;
            }
            else
                return false;
        }
        public int UpdateUser(Waiter user)
        {
            int i = 0;
            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            i = _context.SaveChanges();

            return i;
        }
        public int RemoveUser(Waiter user)
        {
            _context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            var p = _context.Waiters.Remove(user);
            return _context.SaveChanges();
        }
        #endregion

        #region Order
        public int AddOrder(Order order)
        {
          //  _context.Tables.fir..Orders.Add(order);
            return _context.SaveChanges();
        }

        #endregion

        #region Letter
        public int AddLetterMenu(LetterMenu letter)
        {
            try
            {
                var l = _context.LetterMenu.FirstOrDefault(x => x.Name == letter.Name);
                if (l == null)
                    _context.LetterMenu.Add(letter);
                else
                    return 100;

                return _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int UpdateLetter(LetterMenu letter)
        {
            int i = 0;
            var c = _context.LetterMenu.FirstOrDefault(x => x.Name == letter.Name);
            if (c == null)
            {
                _context.Entry(letter).State = System.Data.Entity.EntityState.Modified;
                i = _context.SaveChanges();
            }

            return i;
        }

        public int RemoveLetter(LetterMenu letter)
        {
            _context.Entry(letter).State = System.Data.Entity.EntityState.Modified;
            var c = _context.LetterMenu.Remove(letter);
            return _context.SaveChanges();
        }
        public List<LetterMenu> GetLettersMenu()
        {
            return _context.LetterMenu.ToList();
        }
        public LetterMenu GetLetterMenu(string name)
        {
            return _context.LetterMenu.FirstOrDefault(x => x.Name == name);
        }
        public LetterMenu GetLetterMenuComplete(string name)
        {
            var res = _context.LetterMenu.FirstOrDefault(x => x.Name == name);
            res.Categorys = _context.Categorys.Include("Products").Where(x => x.LetterMenuId == res.Id).ToList();

            return res;
        }
        #endregion

        #region Categoriry
        public List<Category> GetCategorys()
        {
            return _context.Categorys.ToList();
        }
        public List<Category> GetCategorys(int idLetter)
        {
            return _context.Categorys.Where(x => x.LetterMenuId == idLetter).ToList();
        }
        public int AddCategority(Category category, int letter)
        {
            try
            {
                var let = _context.LetterMenu.Include("Categorys").FirstOrDefault(x => x.Id == letter);
                if (let.Categorys == null)
                {
                    let.Categorys = new List<Category>();
                }
                var c = let.Categorys.FirstOrDefault(x => x.Name.ToUpper() == category.Name.ToUpper());
                if (c == null)
                {
                    let.Categorys.Add(category);
                    return _context.SaveChanges();
                }
                else
                    return 100;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public int UpdateCategority(Category category)
        {
            int i = 0;
            var c = _context.Categorys.FirstOrDefault(x => x.Name == category.Name);
            if (c == null)
            {
                _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                i = _context.SaveChanges();
            }

            return i;
        }
        public int RemoveCategority(Category category)
        {
            _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            var c = _context.Categorys.Remove(category);
            return _context.SaveChanges();
        }
        public Category GetCategory(int idLetter, string nameCategory)
        {
            try
            {
                return _context.Categorys.FirstOrDefault(x => x.LetterMenuId == idLetter && x.Name == nameCategory);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
     
        #endregion

        #region Table
        public bool TableRegister(int count)
        {
            List<Table> list = new List<Table>();
            while (count > 0)
            {
                list.Add(new Table() {Number = count});
                count--;
            }
            _context.Tables.AddRange(list);
            _context.SaveChanges();
            return true;
        }
        public List<Table> GetTables(List<int> numbers)
        {
            if (numbers.Count == 0)
                return _context.Tables.ToList();
            else
                return _context.Tables.ToList().Where(x => numbers.Exists(k => k == x.Number)).ToList();
        }
        #endregion

        #region Auxiliary
        public Waiter GetUserWithTable(string nameUser)
        {
            return _context.Waiters.Include("Tablets").FirstOrDefault(x => x.UserName == nameUser);
        }

        #endregion
        #region CloseTable
        public int NewCloseTbale(int table)
        {
            CloseTable c = new CloseTable();
            c.TableNumber = table;
            c.StartDate = DateTime.Now;
            _context.CloseTable.Add(c);
            return _context.SaveChanges();
        }
        public int CloseTable(int table)
        {
            var close = _context.CloseTable.FirstOrDefault(x => x.EndDate == null);
            close.EndDate = DateTime.Now;
            return _context.SaveChanges();
        }
        public CloseTable GetCurrenClose(int table)
        {
            return _context.CloseTable.FirstOrDefault(x => x.TableNumber == table && x.EndDate == null);
        }
        public int AddOrder(int table, Order order)
        {
            CloseTable close = _context.CloseTable.FirstOrDefault(x => x.TableNumber == table && x.EndDate == null);
            if (close == null)
            {
                close = new CloseTable();
                close.StartDate = DateTime.Now;
                close.TableNumber = table;
                _context.CloseTable.Add(close);
            }
            if (close.Orders == null)
                close.Orders = new List<Order>();

            close.Orders.Add(order);

            return _context.SaveChanges();
        }
        #endregion



    }
    //public class ProductMoqRepository : IRepository
    //{
    //    private static ShoppingMoqContext _context = null;
    //    public ProductMoqRepository() 
    //    {
    //        if (_context == null)
    //            _context = new ShoppingMoqContext(); 
    //    } 
    //    public IEnumerable<Product> GetProducts()
    //    {

    //        return _context.Products;
    //    }
    //    public int AddProduct(Product product)
    //    {
    //         _context.Products.Add(product);
    //         return 1;
    //    }
    //    public Waiter GetUser(Guid id)
    //    {
    //        return _context.Waiters.FirstOrDefault(x => x.Id == id);
    //    }
    //    public Waiter GetUser(string username, string password)
    //    {
    //        return _context.Waiters.FirstOrDefault(x => x.UserName == username && x.Password == password);
    //    }
    //    public int AddOrder(Order order)
    //    {
    //        _context.Orders.Add(order);
    //        return 1;
    //    }


    //    public LetterMenu GetLetterMenu()
    //    {
           
    //        return _context.LetterMenu[0];

    //    }


    //    public Waiter GetUser(string userName)
    //    {
    //        return _context.Waiters.FirstOrDefault(x => x.UserName == userName);
    //    }


    //    public LetterMenu GetLetterMenu(int numberTable)
    //    {
    //        try
    //        {
    //            if (_context.Tables.FirstOrDefault(x => x.Number == numberTable).
    //           Closes.Exists(x => x.EndDate == null))
    //            {
    //                var closes = _context.Tables.FirstOrDefault(x => x.Number == numberTable).
    //           Closes.FindAll(x => x.EndDate == null);

    //                foreach (var close in closes)
    //                {
    //                    foreach (var order in close.Orders)
    //                    {
    //                        foreach (var pro in order.Product)
    //                        {
    //                            int i = 0;
    //                            while (i < _context.LetterMenu[0].Categorys.Count)
    //                            {
    //                                var cat = _context.LetterMenu[0].Categorys[i];
    //                                var prod = cat.Products.FirstOrDefault(x => x.Id == pro.Id);
    //                                if (prod == null)
    //                                    i++;
    //                                else
    //                                {
    //                                    prod.Count += pro.Count;
    //                                    prod.SendDate = order.Date;
    //                                    i = _context.LetterMenu[0].Categorys.Count;
    //                                }

    //                            }
    //                        }
    //                    }
    //                }

    //            }

    //            return _context.LetterMenu[0];

    //        }
    //        catch (Exception)
    //        {
    //            return null;
    //        }
           
    //    }


    //    public int RemuveProduct(Product product)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int UpdateProduct(Product product)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int AddCategoity(Category category)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int UpdateCategoity(string name)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public Category GetCategory(string name)
    //    {
    //        throw new NotImplementedException();
    //    }


    //    public int RemuveProduct(string name)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    bool IRepository.AddCategority(Category category)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public int UpdateCategority(Category category)
    //    {
    //        throw new NotImplementedException();
    //    }


    //    public int RemoveCategority(string name)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
