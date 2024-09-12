namespace FrontEnd.Data
{

    public class Vendor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? City { get; set; }
        public int VendorGroupId { get; set; }
        public int IsNotDeleted { get; set; }
    }
}
