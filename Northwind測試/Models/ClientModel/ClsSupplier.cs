namespace NorthwindControl.Models.ClientModel
{
    /// <summary>供應商</summary>
    public class ClsSupplier
    {
        /// <summary>ID</summary>
        public int id { get; set; }
        /// <summary>名稱</summary>
        public string Name { get; set; } = null!;
        /// <summary>聯絡人姓名</summary>
        public string? ContactName { get; set; }
        /// <summary>聯絡人職稱</summary>
        public string? ContactTitle { get; set; }
        /// <summary>地址</summary>
        public string? Address { get; set; }
        /// <summary>城市</summary>
        public string? City { get; set; }
        /// <summary>區域</summary>
        public string? Region { get; set; }
        /// <summary>郵遞區號</summary>
        public string? PostalCode { get; set; }
        /// <summary>國籍</summary>
        public string? Country { get; set; }
        /// <summary>電話號碼</summary>
        public string? Phone { get; set; }
        /// <summary>傳真</summary>
        public string? Fax { get; set; }
        /// <summary>首頁</summary>
        public string? Homepage { get; set; }
    }
}
