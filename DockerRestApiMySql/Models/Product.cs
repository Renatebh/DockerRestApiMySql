using System.ComponentModel.DataAnnotations;


namespace DockerRestApiMySql.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public int Price { get; set; }

    }
}
