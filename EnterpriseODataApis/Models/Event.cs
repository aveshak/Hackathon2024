namespace EnterpriseODataApis.Models
{
    [Serializable]
    [Table("Account")]
    public class Event
    {
        [Key]
        [Column("evt_srl_id")]
        public int Id { get; set; }

        [Column("org_srl_id")]
        public string Organization { get; set; }
        [Column("evt_start_date")]
        public DateTime StartDate { get; set; }
        [Column("evt_end_date")]
        public DateTime EndDate { get; set; }
        [Column("evt_desc")]
        public string Description { get; set; }
        [Column("evt_designation")]
        public string Designation { get; set; }
        //todo: object
        [Column("evt_class")]
        public string Class { get; set; }
        //todo: object
        [Column("evt_category")]
        public string Category { get; set; }
        //todo: object
        [Column("evt_status")]
        public string Status { get; set; }
        [Column("evt_legal_name")]
        public string LegalName { get; set; }
        [Column("evt_in_date")]
        public string InDate { get; set; }
        [Column("evt_out_date")]
        public string OutDate { get; set; }
        //todo: object
        [Column("evt_coordinator")]
        public string Coordinator { get; set; }
        [Column("evt_sales_person")]
        public string Salesperson { get; set; }
        [Column("evt_entered_by")]
        public string EnteredBy { get; set; }
        [Column("evt_entered_on")]
        public DateTime EnteredOn { get; set; }
        [Column("evt_sensitivity")]
        public string Sensitivity { get; set; }
        //todo: object
        [Column("evt_note")]
        public string Note { get; set; }
        [Column("evt_actual_cost")]
        public int ActualCost { get; set; }
        [Column("evt_forecast_attend")]
        public int ForecastAttendance { get; set; }
        [Column("ForecastCost")]
        public int evt_forecast_cost { get; set; }
        [Column("evt_ord_attend")]
        public int OrderedAttendance { get; set; }
        [Column("evt_actual_attend")]
        public int ActualAttendance { get; set; }

        [Column("evt_type")]
        public string EventType { get; set; }
        [Column("evt_on_site_office")]
        public string OnSiteOffice { get; set; }
        [Column("evt_on_site_phone")]
        public string OnSitePhone { get; set; }
        [Column("evt_cust_number")]
        //todo: object
        public Customer Customer { get; set; }
        [Column("evt_bill_to")]
        public string BillTo { get; set; }
        [Column("evt_web_address")]
        public string WebAddress { get; set; }
        [Column("evt_parent_srl_id")]
        public int ParentEvent { get; set; }
        [Column("evt_previous_srl_id")]
        public int PreviousEvent { get; set; }
        [Column("evt_actual_revenue")]
        public int ActualRevenue { get; set; }
        [Column("evt_ord_revenue")]
        public int OrderedRevenue { get; set; }
        [Column("evt_forecast_revenue")]
        public int ForecastRevenue { get; set; }
        [Column("evt_days")]
        public int EventDays { get; set; }
    }
}
