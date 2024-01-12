using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseODataApis.Models
{
    [Serializable]
    [Table("Account")]
    public class Account
    {
        [Key]
        [Column("company_id")]
        public int Id { get; set; }
        [Column("org_srl_id")]
        public string? Organization { get; set; }
        [Column("acc_first_name")]
        public string? FirstName { get; set; }
        [Column("acc_last_name")]
        public string? LastName { get; set; }
        [Column("acc_name")]
        public string? Name { get; set; }
        [Column("acc_saluation")]
        public string? Salutation { get; set; }
        [Column("acc_title")]
        public string? Title { get; set; }
        [Column("acc_address_l1")]
        public string? Address1 { get; set; }
        [Column("acc_address_l2")]
        public string? Address2 { get; set; }
        [Column("acc_address_l3")]
        public string? Address3 { get; set; }
        [Column("acc_address_l4")]
        public string? MiddleInitial { get; set; }
        [Column("acc_address_l5")]
        public string? Address5 { get; set; }
        [Column("acc_address_l6")]
        public string? Address6 { get; set; }
        [Column("acc_city")]
        public string? City { get; set; }
        [Column("acc_state")]
        public string? State { get; set; }
        [Column("acc_postal_code")]
        public string? PostalCode { get; set; }
        [Column("acc_country")]
        public string? Country { get; set; }
        [Column("acc_region")]
        public string? Region { get; set; }
        [Column("acc_keyword")]
        public string? Keyword { get; set; }
        [Column("acc_phone")]
        public string? Phone { get; set; }
        [Column("acc_mobile")]
        public string? Mobile { get; set; }
        [Column("acc_fax")]
        public string? Fax { get; set; }
        [Column("acc_email_address")]
        public string? Email { get; set; }
        [Column("acc_website_address")]
        public string? Website { get; set; }
        [Column("acc_primary_account")]
        public string? PrimaryAccount { get; set; }
        [Column("acc_entered_on")]
        public DateTime? EnteredOn { get; set; }
        [Column("acc_changed_on")]
        public DateTime? ChangedOn { get; set; }
    }
}
