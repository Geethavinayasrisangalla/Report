using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmManagement.Web.Models.Entities
{
    public class YieldReport
    {
        [Key]
        public int YieldReportId { get; set; }

        [Required]
        public int FieldId { get; set; }

        [ForeignKey(nameof(FieldId))]
        public Field? Field { get; set; }   // ✅ nullable navigation property

        [Column(TypeName = "decimal(10,2)")]
        public decimal CalculatedEfficiency { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal TotalCostIncurred { get; set; }

        public DateTime GeneratedOn { get; set; } = DateTime.UtcNow;
    }
}
