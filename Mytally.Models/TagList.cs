using SqlSugar;

namespace Mytally.Models;

public class TagList : BaseId
{
    [SugarColumn(ColumnDataType = "nvarchar(10)")]
    public string Name { get; set; } = "def";
    public int BillId { get; set; }
}
