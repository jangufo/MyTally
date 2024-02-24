namespace MyTally.Models;

public class ImageList : BaseId
{
    [SqlSugar.SugarColumn(ColumnDataType = "varchar(100)")]
    public required string ImageUri { get; set; }
    public int BillId { get; set; }
}
