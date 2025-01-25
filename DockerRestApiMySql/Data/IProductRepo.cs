using DockerRestApiMySql.Models;

namespace DockerRestApiMySql.Data
{
    public interface IProductRepo
    {
        public IEnumerable<Product> GetAllProducts();

        public Product GetProductById(int id);

        public void CreateProduct(Product product);

        public void UpdateProduct(Product product);

        public void DeleteProduct(int id);

        public bool SaveChanges();
    }
}
