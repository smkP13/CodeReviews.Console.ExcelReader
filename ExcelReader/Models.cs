namespace ExcelReader;

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

    internal class Athlete
    {
        public int Id { get; set; }
        public string? Year { get; set; }
        public string? Team { get; set; }
        public string? Name { get; set; }
        public string? No { get; set; }
        public string? Pos { get; set; }
        public string? Ht { get; set; }
        public string? Wt { get; set; }
        public string? Age { get; set; }
        public string? Exp { get; set; }
        public string? College { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Ft { get; set; }
        public string? In { get; set; }
        public string? Inches { get; set; }
        public string? NumGrp { get; set; }

        internal string[] ToArray()
        {
            return [Id.ToString(), Year, Team, Name, No, Pos, Ht, Wt, Age, Exp, College, FirstName, LastName, Ft, In, Inches, NumGrp];
        }
        internal string? GetData(int index)
        {
            switch (index)
            {
                case 1:
                    return Year;
                case 2:
                    return Team;
                case 3:
                    return Name;
                case 4:
                    return No;
                case 5:
                    return Pos;
                case 6:
                    return Ht;
                case 7:
                    return Wt;
                case 8:
                    return Age;
                case 9:
                    return Exp;
                case 10:
                    return College;
                case 11:
                    return FirstName;
                case 12:
                    return LastName;
                case 13:
                    return Ft;
                case 14:
                    return In;
                case 15:
                    return Inches;
                case 16:
                    return NumGrp;
                default: return null;
            }
        }

        internal void SetData(string value, int key)
        {
            switch (key)
            {
                case 1:
                    Year = value;
                    break;
                case 2:
                    Team = value;
                    break;
                case 3:
                    Name = value;
                    break;
                case 4:
                    No = value;
                    break;
                case 5:
                    Pos = value;
                    break;
                case 6:
                    Ht = value;
                    break;
                case 7:
                    Wt = value;
                    break;
                case 8:
                    Age = value;
                    break;
                case 9:
                    Exp = value;
                    break;
                case 10:
                    College = value;
                    break;
                case 11:
                    FirstName = value;
                    break;
                case 12:
                    LastName = value;
                    break;
                case 13:
                    Ft = value;
                    break;
                case 14:
                    In = value;
                    break;
                case 15:
                    Inches = value;
                    break;
                case 16:
                    NumGrp = value;
                    break;
                default: break;
            }
        }
    }
}