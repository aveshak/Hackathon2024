using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseODataApis.Models
{
    [Serializable]
    [Table("event_category")]
    public class EventCategory
    {
        [Key]
        [Column("category_srl_id")]
        public long? Id { get; set; }
        [Column("tenant_id")]
        public int? TenantId { get; set; }

        
        [Column("category_code")]
        
        public string? Code { get; set; }
        [Column("org_srl_id")]
        public string? Organization { get; set; }
        [Column("category_desc")]
        public string? Description { get; set; }
        [Column("category_scope")]
        public string? Scope { get; set; }
        [Column("category_sequence")]
        public string? Sequence { get; set; }
        [Column("category_retire")]
        public string? Retire { get; set; }

        public List<Event>? Events { get; set; }
    }
}
