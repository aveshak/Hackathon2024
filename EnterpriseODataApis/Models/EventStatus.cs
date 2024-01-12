using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseODataApis.Models
{
    [Serializable]
    [Table("EventStatus")]
    public class EventStatus
    {
        [Key]
        [Column("evt_status_srl_id")]
        public int Id { get; set; }
        [Column("tenant_id")]
        public int TenantId { get; set; }
        [Column("evt_status_description")]
        public string Description { get; set; }
        [Column("evt_status_event_scope")]
        public string? EventScope { get; set; }
        [Column("evt_status_job_scope")]
        public string? JobScope { get; set; }
        [Column("evt_status_abbreviated_code")]
        public string? AbbreviatedCode { get; set; }
        [Column("evt_status_abbreviated_description")]
        public string? AbbreviatedDescription { get; set; }
        [Column("evt_status_assignable_by_marketing")]
        public int? AssignableByMarketing { get; set; }
        [Column("evt_status_background_color")]
        public int? BackgroundColor { get; set; }
        [Column("evt_status_text_color")]
        public string? TextColor { get; set; }
        [Column("evt_status_status_group")]
        public string? StatusGroup { get; set; }
        [Column("evt_status_pattern")]
        public string? Pattern { get; set; }
        [Column("evt_status_lost_flag")]
        public string? LostFlag { get; set; }
    }
}
