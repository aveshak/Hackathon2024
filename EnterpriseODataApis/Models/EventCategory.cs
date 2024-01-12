using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseODataApis.Models
{
    [Serializable]
    [Table("EventCategory")]
    public class EventCategory
    {
        [Key]
        [Column("category_srl_id")]
        public int Id { get; set; }
        [Column("tenant_id")]
        public int TenantId { get; set; }
        [Column("category_code")]
        public int Code { get; set; }
        [Column("org_srl_id")]
        public string? OrganizationCode { get; set; }
        [Column("category_desc")]
        public string? Description { get; set; }
        [Column("category_scope")]
        public int? Scope { get; set; }
        [Column("category_sequence")]
        public string? Sequence { get; set; }
        [Column("category_entered_on")]
        public DateTime? EnteredOn { get; set; }
        [Column("category_entered_by")]
        public int? EnteredByCode { get; set; }
        [Column("category_retire")]
        public string? Retire { get; set; }
        [Column("category_changed_on")]
        public DateTime? ChangedOn { get; set; }
        [Column("category_changed_by")]
        public string? ChangedByCode { get; set; }
        [Column("category_desc_alt1")]
        public string? AlternateDescription1 { get; set; }
        [Column("category_desc_alt2")]
        public string? AlternateDescription2 { get; set; }
        [Column("category_desc_alt3")]
        public string? AlternateDescription3 { get; set; }
        [Column("category_desc_alt4")]
        public string? AlternateDescription4 { get; set; }
        [Column("category_desc_alt5")]
        public string? AlternateDescription5 { get; set; }
    }
}
