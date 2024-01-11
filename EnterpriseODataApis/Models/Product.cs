using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseODataApis.Models
{
    [Serializable]
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [ForeignKey("company_id")]
        public Company? Company { get; set; }
    }
}
