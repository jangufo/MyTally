﻿using SqlSugar;

namespace MyTally.Models;

public class BaseId
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }
}
