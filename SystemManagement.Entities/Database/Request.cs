using System;

namespace SystemManagement.Entities.Database
{
    public class Request
    {

        public decimal reqID { get; set; }
        public Nullable<int> req_product { get; set; }
        public Nullable<int> req_channel { get; set; }
        public Nullable<int> req_businessId { get; set; }
        public Nullable<decimal> req_amount { get; set; }
        public string req_rate { get; set; }
        public Nullable<decimal> req_term { get; set; }
        public Nullable<decimal> req_endorsement { get; set; }
        public Nullable<decimal> req_percentageCompletion { get; set; }
        public Nullable<decimal> req_quota { get; set; }
        public string req_paydayLimit { get; set; }
        public string req_adviserCoreId { get; set; }
        public Nullable<int> req_adviserTypeId { get; set; }
        public string req_adviserId { get; set; }
        public Nullable<int> req_economicDestination { get; set; }
        public string req_status { get; set; }

    }
}
