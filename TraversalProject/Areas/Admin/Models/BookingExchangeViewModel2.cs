namespace TraversalProject.Areas.Admin.Models
{
    public class BookingExchangeViewModel2
    {

        public Datum[] data { get; set; }
        public string message { get; set; }
        public bool status { get; set; }


        public class Datum
        {
            public string __typename { get; set; }
            public string code { get; set; }
            public string encodedSymbol { get; set; }
            public string name { get; set; }
            public string symbol { get; set; }
        }

    }
}
