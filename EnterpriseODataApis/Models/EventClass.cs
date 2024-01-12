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
        public int Id { get; set; }
        [Column("tenant_id")]
        public int TenantId { get; set; }
        [Column("class_srl_code")]
        public int Code { get; set; }
        [Column("org_srl_id")]
        public string? OrganizationCode { get; set; }
        [Column("class_desc")]
        public string? Description { get; set; }
        [Column("class_scope")]
        public int? Scope { get; set; }
        [Column("class_sequence")]
        public string? Sequence { get; set; }
        [Column("class_retire")]
        public string? Retire { get; set; }
    }
}
