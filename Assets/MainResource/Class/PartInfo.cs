using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PartType { wheel, guide, cover, pan, battery, motor }

/// <summary>
/// 零件信息：
/// 用途：标识一个零件由哪个类型的配件与技能组成
/// </summary>
[System.Serializable]
public struct PartInfo
{
    [SerializeField] public uint id;        //配件ID
    [SerializeField] public uint sklID;     //技能ID
    [SerializeField] public string name;    //配件名称
    [SerializeField] public PartType type;    //配件类型

    public PartInfo( uint id_, uint sklID_, string name_, PartType type_ )
    {
        id = id_;
        sklID = sklID_;
        name = name_;
        type = type_;
    }
    
    public PartInfo( PartInfo info )
    {
        id = info.id;
        sklID = info.sklID;
        name = info.name;
        type = info.type;
    }
}
