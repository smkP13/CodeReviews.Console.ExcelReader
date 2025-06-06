using OfficeOpenXml;
using static DynamicExcelReader.Models;

namespace DynamicExcelReader;

class DynamicExcelController
{
    private static string _fileStr => GetFilePath();
    internal static List<Header>? GetHeaders()
    {
        ExcelPackage.License.SetNonCommercialPersonal("MySelf");
        FileInfo file = new(_fileStr);
        if (!file.Exists) file.Create();
        using (ExcelPackage package = new(file, ""))
        {
            ExcelWorksheet? sheet = package.Workbook.Worksheets.FirstOrDefault();
            if (sheet != null)
            {
                List<ExcelRangeColumn> headerRange = sheet.Columns.ToList();
                List<Header> headerList = new();
                foreach (ExcelRangeColumn column in headerRange)
                {
                    if (column.Range.Text != "" && column.Range.Text != null) headerList.Add(new Header(column.Range.Text, column.Range.Start.Column));
                    else return headerList;
                }
                return headerList;
            }
            return null;
        }
    }

    internal static List<DynamicData>? GetData()
    {
        using ExcelPackage package = new(new FileInfo(_fileStr), "");
        {
            List<Header>? headers = GetHeaders();
            ExcelWorksheet? sheet = package.Workbook.Worksheets.FirstOrDefault();
            List<DynamicData> datas = [];
            if (sheet != null && headers != null)
            {
                foreach (ExcelRangeRow row in sheet.Rows)
                {
                    if (row.StartRow != 1)
                    {
                        DynamicData data = new();
                        data.Id = datas.Count() + 1;
                        data.keyValuePairs = [];
                        data.keyValuePairs.TryAdd("Id", data.Id.ToString());
                        int index = 0;
                        while (index < headers.Count())
                        {
                            data.keyValuePairs.TryAdd(headers[index].Text, row.Range.TakeSingleColumn(index).Text);
                            index++;
                        }
                        datas.Add(data);
                    }
                }
                return datas;
            }
            return null;
        }
    }

    private static string GetFilePath()
    {
        string? appFolderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        int pathLength = appFolderPath.Length - 16;
        string dbFolderPath = appFolderPath.Substring(0, pathLength);
        // change filename here
        // AthleteSheet.xlsx
        // SampleData.xlsx
        return $"{dbFolderPath}sampledatafoodsales.xlsx";
    }
}

class DBController
{
    internal static List<DynamicData> GetDataFromDb(DynamicContext context)
    {
        return context.DynamicDatas.ToList();
    }
}