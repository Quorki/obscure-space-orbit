using OfficeOpenXml;

namespace FrontEnd.Data
{
    public class WarehouseContext
    {
        public List<Warehouse> ReadWarehouses() {
                List<Warehouse> warehouses = new List<Warehouse>();
                string filePath = "./ExcelFiles/Warehouse.xlsx";
                FileInfo file = new FileInfo(filePath);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using(ExcelPackage package = new ExcelPackage(file)) //this loads in the excel file from the provided path
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    int row = worksheet.Dimension.End.Row;
                    for(int i = 2; i <= row; i++) {
                        Warehouse warehouse = new();
                        warehouse.Id = Convert.ToInt32(worksheet.Cells[i, 1].Value);
                        warehouse.Name = worksheet.Cells[i, 2].Value.ToString();
                        warehouse.Description = worksheet.Cells[i, 3].Value.ToString();
                        warehouse.SystemWarehouse = Convert.ToInt32(worksheet.Cells[i, 4].Value);
                        warehouse.RowGuid = worksheet.Cells[i, 5].Value.ToString();
                        warehouse.CreatedBy = worksheet.Cells[i, 6].Value.ToString();
                        warehouse.CreatedAtUtc = worksheet.Cells[i, 7].Value.ToString();
                        warehouse.UpdatedBy = worksheet.Cells[i, 8].Value.ToString();
                        warehouse.UpdatedAtUtc = worksheet.Cells[i, 9].Value.ToString();
                        warehouse.IsNotDeleted = Convert.ToInt32(worksheet.Cells[i, 10].Value);
                        warehouses.Add(warehouse);
                    }
                }
                return warehouses;
        }

        public void AddWarehouse(string name, string description, string systemWarehouse, string rowGuid, string createdBy) {
            List<Warehouse> warehouses = new List<Warehouse>();
                string filePath = "./ExcelFiles/Warehouse.xlsx";
                FileInfo file = new FileInfo(filePath);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using(ExcelPackage package = new ExcelPackage(file)) //this loads in the excel file from the provided path
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    int row = worksheet.Dimension.End.Row;
                    worksheet.Cells[row + 1, 1].Value = row;
                    worksheet.Cells[row + 1, 2].Value = name;
                    worksheet.Cells[row + 1, 3].Value = description;
                    worksheet.Cells[row + 1, 4].Value = systemWarehouse;
                    worksheet.Cells[row + 1, 5].Value = rowGuid;
                    worksheet.Cells[row + 1, 6].Value = createdBy;
                    worksheet.Cells[row + 1, 7].Value = DateTime.Now.ToString();
                    worksheet.Cells[row + 1, 8].Value = "NULL";
                    worksheet.Cells[row + 1, 9].Value = "NULL";
                    worksheet.Cells[row + 1, 10].Value = 1;

                    package.Save();
                }
        }

        public void DeleteWarehouse(int id) {
                string filePath = "./ExcelFiles/Warehouse.xlsx";
                FileInfo file = new FileInfo(filePath);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using(ExcelPackage package = new ExcelPackage(file)) {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    worksheet.Cells[id + 1, 10].Value = 0;

                    package.Save();
                }
            }

            public void EditWarehouse(int id, string name, string description, string systemWarehouse, string rowGuid, string updatedBy) {
            List<Warehouse> warehouses = new List<Warehouse>();
                string filePath = "./ExcelFiles/Warehouse.xlsx";
                FileInfo file = new FileInfo(filePath);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using(ExcelPackage package = new ExcelPackage(file)) //this loads in the excel file from the provided path
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    int row = id;
                    worksheet.Cells[row + 1, 1].Value = row;
                    worksheet.Cells[row + 1, 2].Value = name;
                    worksheet.Cells[row + 1, 3].Value = description;
                    worksheet.Cells[row + 1, 4].Value = systemWarehouse;
                    worksheet.Cells[row + 1, 5].Value = rowGuid;
                    worksheet.Cells[row + 1, 8].Value = updatedBy;
                    worksheet.Cells[row + 1, 9].Value = DateTime.Now.ToString();
                    worksheet.Cells[row + 1, 10].Value = 1;

                    package.Save();
                }
        }
    }
}