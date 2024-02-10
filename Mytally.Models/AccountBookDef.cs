using SqlSugar;

namespace Mytally.Models;

public class AccountBookDef : BaseId
{
    /// <summary>
    /// 账本名称
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar(10)")]
    public string Name { get; set; } = "def";

    /// <summary>
    /// 账本余额，该值是被动变化的
    /// </summary>
    public double Balance { get; set; }

    /// <summary>
    /// 额度，比如说花呗
    /// </summary>
    public double? Quota { get; set; }
}
