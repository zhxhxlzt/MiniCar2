using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    [SerializeField] public string type;    //配件类型
}
