namespace FrontEnd.Data
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int SystemWarehouse { get; set; }
        public string? RowGuid { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedAtUtc { get; set; }
        public string? UpdatedBy { get; set; }
        public string? UpdatedAtUtc { get; set; }
        public int IsNotDeleted { get; set; }
    }
}