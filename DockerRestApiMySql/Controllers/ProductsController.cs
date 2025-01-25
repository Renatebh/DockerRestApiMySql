using DockerRestApiMySql.Data;
using DockerRestApiMySql.Models;
using Microsoft.AspNetCore.Mvc;

[Route("/product")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepo _repo;


    public ProductsController(IProductRepo repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAllProducts()
    {
        var products = _repo.GetAllProducts();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> GetProductById(int id)
    {
        var product = _repo.GetProductById(id);
        if (product != null)
        {
            return Ok(product);
        }
        return NotFound();
    }

    [HttpPost]
    public ActionResult<Product> CreateProduct(Product product)
    {
        try
        {
            _repo.CreateProduct(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Intern serverfeil: " + ex.Message);
        }
    }


    [HttpPut("{id}")]
    public ActionResult UpdateProduct(int id, Product updatedProduct)
    {
        if (updatedProduct == null)
        {
            return BadRequest("Produktdata er ugyldig eller ID-er stemmer ikke overens.");
        }

        var existingProduct = _repo.GetProductById(id);

        if (existingProduct == null)
        {
            return NotFound($"Produkt med ID {id} finnes ikke.");
        }

        _repo.UpdateProduct(updatedProduct);
        _repo.SaveChanges();

        return NoContent(); 
    }



    [HttpDelete("{id}")]
    public ActionResult DeleteProduct(int id)
    {
        var product = _repo.GetProductById(id);

        if (product == null)
        {
            return NotFound();
        }

        _repo.DeleteProduct(id);
        _repo.SaveChanges();

        return NoContent();
    }
}


