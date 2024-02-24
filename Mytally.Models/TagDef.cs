using SqlSugar;

namespace MyTally.Models;

public class TagDef : BaseId
{
    [SugarColumn(ColumnDataType = "nvarchar(10)")]
    public string Name { get; set; } = "def";
}
