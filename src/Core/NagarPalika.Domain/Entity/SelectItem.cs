namespace NagarPalika.Domain.Entity
{
    public class SelectItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
    public static class RecieptType
    {
        public const string BillingMaster = "BLM";
        public const string WaterMaster = "WTM";
        public const string TradeAndLicence = "TAL";
        public const string AdvertisementTax = "ADT";
        public const string RentAndLease = "RAL";
    }
}
