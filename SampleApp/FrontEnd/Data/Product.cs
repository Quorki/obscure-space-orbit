namespace FrontEnd.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Number { get; set; }
        public string? Description { get; set; }
        public int UnitPrice { get; set;}
        public int Physical { get; set; }
        public int UnitMeasureId { get; set; }
        public int UnitGroupId { get; set; }
        public string? RowGuid { get; set; }
        public string? CreatedByUserId { get; set; }
        public string? CreatedAtUtc { get; set; }
        public string? UpdatedByUserId { get; set; }
        public string? UpdatedAtUtc { get; set; }
        public int IsNotDeleted { get; set; }
    }
}