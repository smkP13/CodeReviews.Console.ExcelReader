using System.ComponentModel.DataAnnotations;

namespace DynamicExcelReader;

internal class Models
{
    internal class Header
    {
        internal string Text { get; set; }
        internal int Index { get; set; }

        internal Header(string text, int index)
        {
            Text = text;
            Index = index;
        }
    }

    internal class DynamicData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Dictionary<string, string>? keyValuePairs { get; set; } = [];
    }
}