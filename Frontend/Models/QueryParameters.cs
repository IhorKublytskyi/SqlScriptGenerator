namespace Frontend.Models
{
    public record QueryParameters
    {
        //Filters
        public int Dialect { get; set; } = -1;
        public int MinQuantity { get; set; } = -1;
        public int MaxQuantity { get; set; } = -1;
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public DateTime? ExactDate { get; set; }

        //Sort
        public bool Descending { get; set; } = false;
        public string SortBy { get; set; } = "RequestedAt";
    }
}
