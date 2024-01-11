using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseODataApis.Models
{
    [Serializable]
    [Table("company")]
    public class Company
    {
        [Key]
        [Column("company_id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; }

        [Column("size")]
        public int Size { get; set; }

        public List<Product>? Products { get; set; }
    }
}
