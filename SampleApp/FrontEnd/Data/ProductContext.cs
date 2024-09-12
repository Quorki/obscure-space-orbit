using OfficeOpenXml;

namespace FrontEnd.Data
{
    public class ProductContext
    {
            public List<Product> ReadProducts() {
                List<Product> products = new List<Product>();
                string filePath = "./ExcelFiles/Product.xlsx";
                FileInfo file = new FileInfo(filePath);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using(ExcelPackage package = new ExcelPackage(file)) //this loads in the excel file from the provided path
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    int row = worksheet.Dimension.End.Row;
                    for(int i = 2; i <= row; i++) {
                        Product product = new();
                        product.Id = Convert.ToInt32(worksheet.Cells[i, 1].Value);
                        product.Name = worksheet.Cells[i, 2].Value.ToString();
                        product.Number = worksheet.Cells[i, 3].Value.ToString();
                        product.Description = worksheet.Cells[i, 4].Value.ToString();
                        product.UnitPrice = Convert.ToInt32(worksheet.Cells[i, 5].Value);
                        product.Physical = Convert.ToInt32(worksheet.Cells[i, 6].Value);
                        product.UnitMeasureId = Convert.ToInt32(worksheet.Cells[i, 7].Value);
                        product.UnitGroupId= Convert.ToInt32(worksheet.Cells[i, 8].Value);
                        product.RowGuid = worksheet.Cells[i, 9].Value.ToString();
                        product.CreatedByUserId = worksheet.Cells[i, 10].Value.ToString();
                        product.CreatedAtUtc = worksheet.Cells[i, 11].Value.ToString();
                        product.UpdatedByUserId = worksheet.Cells[i, 12].Value.ToString();
                        product.UpdatedAtUtc = worksheet.Cells[i, 13].Value.ToString();
                        product.IsNotDeleted = Convert.ToInt32(worksheet.Cells[i, 14].Value);
                        products.Add(product); //goes through excel sheet, creates product object, fills out attributes, then adds to the list
                    }
                }
                return products;
            }
            public void AddProduct(string name, string number, string description, string unitPrice, string physical, string unitMeasure, string productGroup, string rowGuid, string empId) {
                string filePath = "./ExcelFiles/Product.xlsx";
                FileInfo file = new FileInfo(filePath);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using(ExcelPackage package = new ExcelPackage(file)) {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    int row = worksheet.Dimension.End.Row;
                    worksheet.Cells[row+1, 1].Value = row;
                    worksheet.Cells[row +1, 2].Value = name;
                    worksheet.Cells[row + 1, 3].Value = number;
                    worksheet.Cells[row + 1, 4].Value = description;
                    worksheet.Cells[row + 1, 5].Value = unitPrice;
                    worksheet.Cells[row + 1, 6].Value = physical;
                    worksheet.Cells[row + 1, 7].Value = unitMeasure;
                    worksheet.Cells[row + 1, 8].Value = productGroup;
                    worksheet.Cells[row + 1, 9].Value = rowGuid;
                    worksheet.Cells[row + 1, 10].Value = empId;
                    worksheet.Cells[row + 1, 11].Value = DateTime.Now.ToString();
                    worksheet.Cells[row + 1, 12].Value = "NULL";
                    worksheet.Cells[row + 1, 13].Value = "NULL";
                    worksheet.Cells[row + 1, 14].Value = 1;

                    package.Save();
                }  
            }
            public void DeleteProduct(int id) {
                string filePath = "./ExcelFiles/Product.xlsx";
                FileInfo file = new FileInfo(filePath);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using(ExcelPackage package = new ExcelPackage(file)) {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    worksheet.Cells[id + 1, 14].Value = 0;

                    package.Save();
                }
            }
                        public void EditProduct(int id, string name, string number, string description, string unitPrice, string physical, string unitMeasure, string productGroup, string rowGuid, string empId) {
                string filePath = "./ExcelFiles/Product.xlsx";
                FileInfo file = new FileInfo(filePath);
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using(ExcelPackage package = new ExcelPackage(file)) {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    int row = id;
                    worksheet.Cells[row +1, 2].Value = name;
                    worksheet.Cells[row + 1, 3].Value = number;
                    worksheet.Cells[row + 1, 4].Value = description;
                    worksheet.Cells[row + 1, 5].Value = unitPrice;
                    worksheet.Cells[row + 1, 6].Value = physical;
                    worksheet.Cells[row + 1, 7].Value = unitMeasure;
                    worksheet.Cells[row + 1, 8].Value = productGroup;
                    worksheet.Cells[row + 1, 9].Value = rowGuid;
                    worksheet.Cells[row + 1, 12].Value = empId;
                    worksheet.Cells[row + 1, 13].Value = DateTime.Now.ToString();

                    package.Save();
                }  
            }
    }
}