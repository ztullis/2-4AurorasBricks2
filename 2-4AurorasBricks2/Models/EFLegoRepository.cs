using Microsoft.EntityFrameworkCore;

namespace _2_4AurorasBricks2.Models
{
    public class EFLegoRepository: ILegoRepository
    {
        private LegoContext _context;
        public EFLegoRepository(LegoContext temp)
        {
            _context = temp;
        }

        public IQueryable<Customer> Customers => _context.Customers;
        public IQueryable<Order> Orders => _context.Orders;
        public IQueryable<LineItem> LineItems => _context.LineItems;
        public IQueryable<Product> Products => _context.Products;

        public void AddProduct(Product product)
        {
            //_context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products ON;");
            _context.Products.Add(product);
            _context.SaveChanges();


            //using (var transaction = _context.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products ON;");
            //        _context.Products.Add(product);
            //        _context.SaveChanges();
            //        transaction.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        transaction.Rollback();
            //        throw;
            //    }
            //    finally
            //    {
            //        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products OFF;");
            //    }
            //}



            //using (var transaction = _context.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        // Ensure IDENTITY_INSERT is ON before inserting
            //        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products ON;");

            //        _context.Products.Add(product);
            //        _context.SaveChanges();

            //        // Commit transaction if no errors occurred
            //        transaction.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        // Rollback transaction if an error occurred
            //        transaction.Rollback();
            //        throw;
            //    }
            //    finally
            //    {
            //        // Ensure IDENTITY_INSERT is OFF after transaction completes
            //        _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT Products OFF;");
            //    }
            //}


        }

        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();

        }

        public void EditProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
    }
}
