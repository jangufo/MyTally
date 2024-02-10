using SqlSugar;

namespace Mytally.Models;

public class Bill : BaseId
{
    /// <summary>
    /// 账单创建时间
    /// </summary>
    public DateTime CreatDataTime { get; set; }

    /// <summary>
    /// 账单金额
    /// </summary>
    public double BillAmount { get; set; }

    /// <summary>
    /// 账单对应账本表的 id 需导航查询到账本表  AccountBookDef
    /// </summary>
    public int AccountBookId { get; set; }

    /// <summary>
    /// 账单类型，1：支出  2：收入  3：转账
    /// </summary>
    public int Type { get; set; }

    /// <summary>
    /// 是否报销
    /// </summary>
    public bool IsReimburse { get; set; }

    /// <summary>
    /// 报销比例 (可空，二者选其一)
    /// </summary>
    public double? ReimbursementRatio { get; set; }

    /// <summary>
    /// 报销金额 (可空，二者选其一)
    /// </summary>
    public double? ReimbursementAmount { get; set; }

    /// <summary>
    /// 父类型id  需导航查询到类型表
    /// </summary>
    public int FatherTypeId { get; set; }

    /// <summary>
    /// 子类型id  需导航查询到类型表 TypeInfoDef
    /// </summary>
    public int ChildenTypeId { get; set; }

    /// <summary>
    /// 账单是否被删除
    /// </summary>
    public bool IsDelete { get; set; }

    /// <summary>
    /// 账单是否不计入收支 (比如说别人请客，我只是做个记录，则不记录收支，默认为false)
    /// </summary>
    public bool IsNotIncludedInIncomeAndExpenditure { get; set; }

    /// <summary>
    /// 备注信息
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar(100)")]
    public string? RecordInfo { get; set; }

    #region 关联查询出的内容

    /// <summary>
    /// 账本信息
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public AccountBookDef? AccountBookDef { get; set; }

    /// <summary>
    /// 从 TagList 表查出内容的映射，自身不存数据库中
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public List<TagList>? BillTagList { get; set; }

    /// <summary>
    /// 从 ImageList 表查出内容的映射，自身不存数据库中
    /// </summary>
    [SugarColumn(IsIgnore = true)]
    public List<ImageList>? BillImageUrlList { get; set; }

    #endregion
}
