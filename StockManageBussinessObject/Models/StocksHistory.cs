using System;
using System.Collections.Generic;

namespace StockManageBussinessObject.Models
{
    public partial class StocksHistory
    {
        public int Id { get; set; }
        public DateTime? ExchangeDate { get; set; }
        public int? Price { get; set; }
        public int? OpenPrice { get; set; }
        public int? ClosePrice { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinPrice { get; set; }
        public int? Volume { get; set; }
        public string? StockCode { get; set; }

        public virtual Stock? StockCodeNavigation { get; set; }
    }
}
