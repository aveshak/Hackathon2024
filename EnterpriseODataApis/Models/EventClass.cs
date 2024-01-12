using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseODataApis.Models
{
    [Serializable]
    [Table("event_class")]
    public class EventClass
    {
        [Key]
        [Column("class_srl_id")]
        public long Id { get; set; }
        [Column("tenant_id")]
        public int? TenantId { get; set; }
        [Column("class_srl_code")]
        public string? Code { get; set; }
        [Column("org_srl_id")]
        public string? Organization { get; set; }
        [Column("class_desc")]
        public string? Description { get; set; }
        [Column("class_scope")]
        public string? Scope { get; set; }
        [Column("class_sequence")]
        public string? Sequence { get; set; }
        [Column("class_retire")]
        public string? Retire { get; set; }

        public List<Event>? Events { get; set; }
    }
}
