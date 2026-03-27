using FarmManagement.Web.Data;
using FarmManagement.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace FarmManagement.Web.Services
{
    public class ReportService
    {
        private readonly FarmDbContext _context;

        public ReportService(FarmDbContext context)
        {
            _context = context;
        }

        public List<YieldAnalyticsViewModels> GetFieldWiseYieldReport()
        {
            var result =
                from field in _context.Fields
                join harvest in _context.Harvests
                    on field.FieldId equals harvest.FieldId
                group harvest by new
        
                {
                    field.FieldId,
                    field.FieldName,
                    field.AreaSize
                }
                into g
                select new YieldAnalyticsViewModels
                {
                    FieldId = g.Key.FieldId,
                    FieldName = g.Key.FieldName,
                    AreaSize = g.Key.AreaSize,
                    TotalYield = g.Sum(h => h.HarvestedQuantity) // ✅ decimal → decimal
                };

            return result.ToList();
        }
    }
}
