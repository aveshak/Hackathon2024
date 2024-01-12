using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseODataApis.Models
{
    [Serializable]
    [Table("event_status")]
    public class EventStatus
    {
        [Key]
        [Column("evt_status_srl_id")]
        public long? Id { get; set; }
        [Column("tenant_id")]
        public int? TenantId { get; set; }
        
        
        [Column("evt_status_code")]
        public string? Code { get; set; }
        [Column("evt_status_description")]
        public string? Description { get; set; }
        [Column("evt_status_event_scope")]
        public string? EventScope { get; set; }
        [Column("evt_status_job_scope")]
        public string? JobScope { get; set; }
        [Column("evt_status_abbreviated_code")]
        public string? AbbreviatedCode { get; set; }
        [Column("evt_status_abbreviated_description")]
        public string? AbbreviatedDescription { get; set; }
        [Column("evt_status_assignable_by_marketing")]
        public string? AssignableByMarketing { get; set; }
        [Column("evt_status_background_color")]
        public int? BackgroundColor { get; set; }
        [Column("evt_status_text_color")]
        public int? TextColor { get; set; }

        public List<Event>? Events { get; set; }
    }
}
