using System;

namespace DigiShop.CoreBussiness.EfCoreDomains.Documents
{
    public static class ConvertDocStatus
    {
        public static string ConvertStatus(this Enum auth, AuthStatus status)
        {
            switch (status)
            {
                case AuthStatus.Accepted:
                    return "قبول";
                case AuthStatus.Rejected:
                    return "رد شده";
                default:
                    return "درحال برسی";
            }
        }
    }
}