using System;
namespace DellyShopApp {
    public static class Global {
        static public string Username { get; set; }
        static public string WebApiUrl { get; set; } = $"https://pos2.dndaims.net";
        static public string Host { get; set; } = $"pos2.dndaims.net";
        static public long LoggedInUserId { get; set; }
        static public long GroupId { get; set; }
        static public string token { get; set; }
        static public string ParentName { get; set; }
        static public long ParentId { get; set; }
        static public DateTime SummaryStart { get; set; }
        static public DateTime SummaryEnd { get; set; }
        static public string CashTransDetail { get; set; }

        static public bool DebugMode { get; set; } = false;
        public static long MaxPhotoSize { get; } = 1048576L;
    }
}
