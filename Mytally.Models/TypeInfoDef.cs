using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar;

namespace Mytally.Models;

public class TypeInfoDef : BaseId
{
    /// <summary>
    /// 类型名
    /// </summary>
    [SugarColumn(ColumnDataType = "nvarchar(10)")]
    public string Name { get; set; } = "def";

    /// <summary>
    /// 类型图标路径
    /// </summary>
    [SugarColumn(ColumnDataType = "varchar(100)")]
    public string? Icon { get; set; }

    /// <summary>
    /// 是否为父类型
    /// </summary>
    public bool IsFatherType { get; set; }

    /// <summary>
    /// 父类型id
    /// </summary>
    public int FatherTypeId { get; set; }
}
