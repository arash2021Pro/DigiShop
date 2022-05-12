using System;

namespace DigiShop.CoreBussiness.EfCoreDomains.Stores
{
    public static class ConvertStoreStatus
    {
        public static string ConvertStatus(this Enum enu, StoreStatus status)
        {
            switch (status)
            {
                case StoreStatus.Confirmed:
                    return "تایید شده";
                case StoreStatus.Rejected:
                    return "رد شده";
                default:
                    return "درحال برسی";
            }
        }
    }
}