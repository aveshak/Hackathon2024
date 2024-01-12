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
        public int Id { get; set; }
        [Column("tenant_id")]
        public int TenantId { get; set; }
        [Column("org_srl_id")]
        public string? Organization { get; set; }
        [Column("evt_type_description")]
        public string? Description { get; set; }
        [Column("evt_type_scope")]
        public string? Scope { get; set; }
        [Column("evt_type_background_color")]
        public int? evt_type_sequence { get; set; }
        [Column("Sequence")]
        public string? evt_type_retire { get; set; }
        [Column("Retire")]
        public int? evt_type_entered_on { get; set; }
        [Column("EnteredOn")]
        public int? evt_type_entered_by_code { get; set; }
        [Column("EnteredByCode")]
        public string? evt_type_changed_on { get; set; }
        [Column("evt_type_changed_by")]
        public string? ChangedByCode { get; set; }
        [Column("evt_type_altr_desc1")]
        public string? AlternateDescription1 { get; set; }
        [Column("evt_type_altr_desc2")]
        public string? AlternateDescription2 { get; set; }
        [Column("evt_type_altr_desc3")]
        public string? AlternateDescription3 { get; set; }
        [Column("evt_type_altr_desc4")]
        public string? AlternateDescription4 { get; set; }
        [Column("evt_type_altr_desc5")]
        public string? AlternateDescription5 { get; set; }
    }
}
