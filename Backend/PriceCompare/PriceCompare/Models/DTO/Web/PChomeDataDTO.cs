using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceCompare.Models.DTO.Web
{
    public class PChomeDataDTO
    {
        public int QTime { get; set; }
        public string cateName { get; set; }
        public int isMust { get; set; }
        public List<PChomeProductDTO> prods { get; set; }
        public string q { get; set; }
        public PChomeRangeDTO range { get; set; }
        public string subq { get; set; }
        public List<string> token { get; set; }
        public int totalPage { get; set; }
        public int totalRows { get; set; }
    }

    public class PChomeProductDTO
    {
        public string BU { get; set; }
        public string Id { get; set; }
        public string author { get; set; }
        public string brand { get; set; }
        public string cateId { get; set; }
        public List<string> couponActId { get; set; }
        public string describe { get; set; }
        public int isNC17 { get; set; }
        public int isPChome { get; set; }
        public string name { get; set; }
        public int originPrice { get; set; }
        public string picB { get; set; }
        public string picS { get; set; }
        public int price { get; set; }
        public string publishDate { get; set; }
        public string sellerId { get; set; }
    }

    public class PChomeRangeDTO
    {
        public string max { get; set; }
        public string min { get; set; }
    }
}
