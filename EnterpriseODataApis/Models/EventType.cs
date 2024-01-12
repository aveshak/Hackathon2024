using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseODataApis.Models
{
    [Serializable]
    [Table("event_type")]
    public class EventType
    {
        [Key]
        [Column("evt_type_srl_id")]
        public long? Id { get; set; }
        [Column("tenant_id")]
        public int? TenantId { get; set; }
        [Column("org_srl_id")]
        public string? Organization { get; set; }

        
        [Column("evt_type_code")]
        
        public string? Code { get; set; }
        [Column("evt_type_description")]
        public string? Description { get; set; }
        [Column("evt_type_scope")]
        public string? Scope { get; set; }
        [Column("evt_type_background_color")]
        public int? BackgroundColor { get; set; }
        [Column("evt_type_sequence")]
        public string? Sequence { get; set; }

        public List<Event>? Events { get; set; }
    }
}
