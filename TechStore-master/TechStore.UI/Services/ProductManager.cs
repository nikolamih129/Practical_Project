using Microsoft.EntityFrameworkCore;
using TechStore.UI.Data;
using TechStore.UI.Interfaces;
using TechStore.UI.Models;

namespace TechStore.UI.Services
{
    public class ProductManager : IProduct
    {
        readonly DataContext _dbContext = new();

        public ProductManager(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        //To Get all product details
        public List<Product> GetProductDetails()
        {
            try
            {
                return _dbContext.Products.ToList();
            }
            catch
            {
                throw new FieldAccessException("Unable to load products from database.");
            }
        }

        //To Add new product record
        public void AddProduct(Product product)
        {
            //if (product.ProductId <= 0) { throw new ArgumentNullException($"Value cannot be null."); }
            if (product.Make is null) { throw new ArgumentNullException($"Value 'Make' cannot be null."); }
            if (product.Model is null) { throw new ArgumentNullException($"Value 'Model' cannot be null."); }
            if (product.Characteristics is null) { throw new ArgumentNullException($"Value 'Characteristics' cannot be null."); }
            if (product.Description is null) { throw new ArgumentNullException($"Value 'Description' cannot be null."); }
            if (product.Price is null) { throw new ArgumentNullException($"Value 'Price' cannot be null."); }

            try
            {
                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar product
        public void UpdateProductDetails(Product product)
        {
            if (product.ProductId <= 0) { throw new ArgumentNullException($"Value cannot be null."); }
            if (product.Make is null) { throw new ArgumentNullException($"Value 'Make' cannot be null."); }
            if (product.Model is null) { throw new ArgumentNullException($"Value 'Model' cannot be null."); }
            if (product.Characteristics is null) { throw new ArgumentNullException($"Value 'Characteristics' cannot be null."); }
            if (product.Description is null) { throw new ArgumentNullException($"Value 'Description' cannot be null."); }
            if (product.Price is null) { throw new ArgumentNullException($"Value 'Price' cannot be null."); }

            try
            {
                _dbContext.Entry(product).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular product
        public Product GetProductData(int id)
        {
            if (id <= 0) { throw new ArgumentNullException($"Value cannot be null."); }

            try
            {
                Product? product = _dbContext.Products.Find(id);
                if (product != null)
                {
                    return product;
                }
                else
                {
                    throw new KeyNotFoundException("Product not found.");
                }
            }
            catch
            {
                throw new FieldAccessException("Unable to load products from database.");
            }
        }

        //To Delete the record of a particular product
        public void DeleteProduct(int id)
        {
            try
            {
                Product? product = _dbContext.Products.Find(id);
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    _dbContext.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

    }
}
