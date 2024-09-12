using OfficeOpenXml;

namespace FrontEnd.Data 
{

    public class VendorContext
    {
        public List<Vendor> ReadVendors()
        {
            List<Vendor> vendors = new List<Vendor>();
            string filePath = "./ExcelFiles/Vendor.xlsx";
            FileInfo file = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using(ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                int row = worksheet.Dimension.End.Row;
                for(int i = 2; i <= row; i++) {
                    Vendor vendor = new();
                    vendor.Id = Convert.ToInt32(worksheet.Cells[i, 1].Value);
                    vendor.Name = worksheet.Cells[i, 2].Value.ToString();
                    vendor.Number = worksheet.Cells[i, 3].Value.ToString();
                    vendor.City = worksheet.Cells[i, 6].Value.ToString();
                    vendor.VendorGroupId = Convert.ToInt32(worksheet.Cells[i, 20].Value);
                    vendor.IsNotDeleted = Convert.ToInt32(worksheet.Cells[i, 27].Value);
                    vendors.Add(vendor);
                }
            }
            return vendors;
        }

        public void AddVendor(string name, string number, string city, string vendorGroupId)
        {
            string filePath = "./ExcelFiles/Vendor.xlsx";
                FileInfo file = new FileInfo(filePath);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using(ExcelPackage package = new ExcelPackage(file)) {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    int row = worksheet.Dimension.End.Row;
                    worksheet.Cells[row+1, 1].Value = row;
                    worksheet.Cells[row +1, 2].Value = name;
                    worksheet.Cells[row + 1, 3].Value = number;
                    worksheet.Cells[row + 1, 6].Value = city;
                    worksheet.Cells[row + 1, 20].Value = vendorGroupId;
                    worksheet.Cells[row + 1, 27].Value = 1;
                    package.Save();
                }
        }

        public void EditVendor(int id, string name, string number, string city, string vendorGroupId) {
                string filePath = "./ExcelFiles/Vendor.xlsx";
                FileInfo file = new FileInfo(filePath);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using(ExcelPackage package = new ExcelPackage(file)) {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    int row = id;
                    worksheet.Cells[row+1, 1].Value = row;
                    worksheet.Cells[row +1, 2].Value = name;
                    worksheet.Cells[row + 1, 3].Value = number;
                    worksheet.Cells[row + 1, 6].Value = city;
                    worksheet.Cells[row + 1, 20].Value = vendorGroupId;
                    worksheet.Cells[row + 1, 27].Value = 1;
                    package.Save();
                }
        }

        public void DeleteVendor(int id) {
                string filePath = "./ExcelFiles/Vendor.xlsx";
                FileInfo file = new FileInfo(filePath);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using(ExcelPackage package = new ExcelPackage(file)) {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    worksheet.Cells[id + 1, 27].Value = 0;

                    package.Save();
                }
            }
    }
}
