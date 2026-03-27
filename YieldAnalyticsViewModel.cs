namespace FarmManagement.Web.Models.ViewModels
{
    public class YieldAnalyticsViewModels
    {
        public int FieldId { get; set; }
        public string FieldName { get; set; } = string.Empty;

        public double AreaSize { get; set; }

        // ✅ Use decimal to match HarvestedQuantity
        public decimal TotalYield { get; set; }

        public decimal AverageYield
        {
            get
            {
                return AreaSize == 0 ? 0 : TotalYield / (decimal)AreaSize;
            }
        }
    }
}
