using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainService
{
    public partial class PositionObject
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
        public PositionType PositionType { get; set; }
        public float PositionValue { get; set; }
        public string PositionCurrency { get; set; }
        public float PositionPrice { get; set; }
        public float PriceCurrency { get; set; }
    }
    public enum PositionType
    {
        Production = 0,
        Service = 1,
        Bonus = 2
    }
}