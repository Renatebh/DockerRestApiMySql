using DockerRestApiMySql.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DockerRestApiMySql.Data
{
    public class SqlProductRepo : IProductRepo
    {
        private readonly ProductContext _context;


        public SqlProductRepo(ProductContext context)
        {
            _context = context;
        }

        // Create
        public void CreateProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Feil oppstod under lagring av produkt", ex);
            }
            ArgumentNullException.ThrowIfNull(product);
        }

        //Get all
        public IEnumerable<Product> GetAllProducts() => _context.Products.ToList();

        // Get 1
        public Product GetProductById(int id) => _context.Products.FirstOrDefault(p => p.Id == id)!;

        // Updste
        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;

                _context.Products.Update(existingProduct);
                SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Produkt med ID {product.Id} finnes ikke");
            }
        }

        // Delete
        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product == null)
            {
                throw new ArgumentException($"Produkt med ID {id} finnes ikke.");
            }

            _context.Products.Remove(product);
            SaveChanges();
        }

        // Save
        public bool SaveChanges() => (_context.SaveChanges() >= 0);
    }
}
