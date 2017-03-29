using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository
    {
        #region Product
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProducts(Category cat);
        Product GetProduct(int id);
        Product GetProduct(string name, int category);
        int AddProduct(Product product);
        int RemuveProduct(Product product);
        int UpdateProduct(Product product);
        #endregion
        #region User
        Waiter GetUserWithTable(string nameUser);
        Waiter GetUser(Guid id);
        Waiter GetUser(string userName);
        Waiter GetUser(string username, string password);
        bool AddUser(Waiter user);
        int UpdateUser(Waiter user);
        int RemoveUser(Waiter user);
        #endregion
        #region Order
        int AddOrder(Order order);
        #endregion
        #region Letter
        int AddLetterMenu(LetterMenu letter);
        int UpdateLetter(LetterMenu letter);
        int RemoveLetter(LetterMenu letter);
        List<LetterMenu> GetLettersMenu();
        LetterMenu GetLetterMenu(string name);
        LetterMenu GetLetterMenuComplete(string name);

        #endregion
        #region Categoriry
        int AddCategority(Category category, int letter);
        int UpdateCategority(Category category);
        int RemoveCategority(Category category);
        Category GetCategory(int idLetter, string nameCategory);
        List<Category> GetCategorys(int idLetter);
        List<Category> GetCategorys();
        #endregion
        #region Table
        bool TableRegister(int count);
        List<Table> GetTables(List<int> numbers);
        #endregion
        #region CloseTable
        int NewCloseTbale(int table);
        int AddOrder(int table, Order order);
        int CloseTable(int table);
        CloseTable GetCurrenClose(int table);
        #endregion

    }
}
