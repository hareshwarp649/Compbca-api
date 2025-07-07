using OfficeOpenXml;

class Program
{
    static void Main()
    {
        var filePath = @"D:\Techvant\Projects\ReportApplication_Visionindia\rest-api\bca.api\Content\Bulk_Insert_Data\LocationsAndFBCs.xlsx";
        var duplicates = FindDuplicates(filePath);

        Console.WriteLine("Duplicate Records:"+duplicates.Count);
        foreach (var record in duplicates)
        {
            Console.WriteLine(record);
        }
    }

    static List<string> FindDuplicates(string filePath)
    {
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

        var seen = new HashSet<string>();
        var duplicates = new List<string>();

        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets[0];
            int rows = worksheet.Dimension.End.Row;

            for (int row = 2; row <= rows; row++) // assuming first row is header
            {
                string rowKey = worksheet.Cells[row, 10].Value?.ToString();

                if (!seen.Add(rowKey))
                {
                    duplicates.Add(rowKey);
                }
            }
        }

        return duplicates;
    }
}
