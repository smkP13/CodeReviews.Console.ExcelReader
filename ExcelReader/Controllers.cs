using OfficeOpenXml;
using static ExcelReader.Models;

namespace ExcelReader;

class ExcelController
{
    private static string _fileStr => GetFilePath();
    internal static List<Header> GetHeaders()
    {
        ExcelPackage.License.SetNonCommercialPersonal("MySelf");
        FileInfo file = new(_fileStr);
        if (!file.Exists) file.Create();
        using (ExcelPackage package = new(file, ""))
        {
            ExcelWorksheet sheet = package.Workbook.Worksheets.FirstOrDefault();
            List<ExcelRangeColumn> headerRange = sheet.Columns.ToList();
            List<Header> headerList = new();
            foreach (ExcelRangeColumn column in headerRange)
            {
                if (column.Range.Text != "") headerList.Add(new Header(column.Range.Text, column.Range.Start.Column));
                else break;
            }
            return headerList;
        }
    }

    internal static List<Athlete> GetAllAthletes()
    {
        using (ExcelPackage athletePackage = new(new FileInfo(_fileStr), ""))
        {
            ExcelWorksheet athleteSheet = athletePackage.Workbook.Worksheets.FirstOrDefault();
            List<Athlete> athleteList = new();
            foreach (ExcelRangeRow item in athleteSheet.Rows)
            {
                if (item.StartRow != 1)
                {
                    Athlete dto = new();
                    int index = 0;
                    while (index < 16)
                    {
                        dto.SetData(item.Range.TakeSingleColumn(index).Text, index + 1);
                        dto.Id = athleteList.Count() + 1;
                        index++;
                    }
                    athleteList.Add(dto);
                }
            }
            return athleteList;
        }
    }

    private static string GetFilePath()
    {
        string? appFolderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        int pathLength = appFolderPath.Length - 16;
        string dbFolderPath = appFolderPath.Substring(0, pathLength);
        //return $"{dbFolderPath}/OfficeSalesSampleData.xlsx";
        return $"{dbFolderPath}AthleteSheet.xlsx";
    }
}

class DBController
{

    internal static List<Athlete> GetAtheltes(AthleteContext context)
    {
        return context.Athletes.ToList();
    }
}