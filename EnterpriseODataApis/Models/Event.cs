using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseODataApis.Models
{
    [Serializable]
    [Table("Events")]
    public class Event
    {
        [Key]
        [Column("evt_srl_id")]
        public long Id { get; set; }
        [Column("tenant_id")]
        public int? TenantId { get; set; }
        
        [Column("org_srl_id")]
        public string? Organization { get; set; }
        [Column("evt_start_date")]
        public DateTime? StartDate { get; set; }
        [Column("evt_end_date")]
        public DateTime? EndDate { get; set; }
        [Column("evt_desc")]
        public string? Description { get; set; }
        [Column("evt_designation")]
        public string? Designation { get; set; }

        [ForeignKey("evt_class_srl_id")]
        public EventClass? EventClass { get; set; }

        [ForeignKey("evt_category_srl_id")]
        public EventCategory? Category { get; set; }
        [ForeignKey("evt_status_srl_id")]
        public EventStatus? Status { get; set; }
        [Column("evt_legal_name")]
        public string? LegalName { get; set; }
        [Column("evt_in_date")]
        public DateTime? InDate { get; set; }
        [Column("evt_out_date")]
        public DateTime? OutDate { get; set; }
        [ForeignKey("evt_coordinator_srl_id")]
        public Account? Coordinator { get; set; }

        [ForeignKey("evt_salesperson_srl_id")]
        public Account? Salesperson { get; set; }
        [Column("evt_entered_by")]
        public string? EnteredBy { get; set; }
        [Column("evt_entered_on")]
        public DateTime EnteredOn { get; set; }
        [Column("evt_sensitivity")]
        public string? Sensitivity { get; set; }
        //todo: object
        [Column("evt_note")]
        public string? Note { get; set; }
        //[Column("evt_actual_cost")]
        //public long? ActualCost { get; set; }
        //[Column("evt_forecast_attend")]
        //public long? ForecastAttendance { get; set; }
        //[Column("evt_forecast_cost")]
        //public long? ForecastCost { get; set; }
        //[Column("evt_ord_attend")]
        //public long? OrderedAttendance { get; set; }
        //[Column("evt_actual_attend")]
        //public long? ActualAttendance { get; set; }
        [ForeignKey("evt_type_srl_id")]
        public EventType? EventType { get; set; }
        [Column("evt_on_site_office")]
        public string? OnSiteOffice { get; set; }
        [Column("evt_on_site_phone")]
        public string? OnSitePhone { get; set; }
        [ForeignKey("evt_cust_number_srl_id")]
        public Account? Customer { get; set; }
        [ForeignKey("evt_bill_to_srl_id")]
        public Account? BillTo { get; set; }
        [Column("evt_web_address")]
        public string? WebAddress { get; set; }
        [Column("evt_parent_srl_id")]
        public long? ParentEvent { get; set; }
        [Column("evt_previous_srl_id")]
        public long? PreviousEvent { get; set; }
        //[Column("evt_actual_revenue")]
        //public long? ActualRevenue { get; set; }
        //[Column("evt_ord_revenue")]
        //public long? OrderedRevenue { get; set; }
        //[Column("evt_forecast_revenue")]
        //public long? ForecastRevenue { get; set; }
        //[Column("evt_days")]
        //public decimal? EventDays { get; set; }
    }
}
