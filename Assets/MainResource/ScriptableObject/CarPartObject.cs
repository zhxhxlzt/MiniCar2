using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="partCollection", menuName = "Parts/partCollection")]
public class CarPartInfoCollection : ScriptableObject
{
    public List<PartInfo> wheel;        //车轮信息
    public List<PartInfo> guide;        //导轮信息
    public List<PartInfo> cover;        //车盖信息
    public List<PartInfo> pan;          //底盘信息
    public List<PartInfo> battery;      //电池信息
    public List<PartInfo> motor;        //马达信息
}

[CreateAssetMenu(fileName ="CurPartInfo", menuName = "Parts/CurPartInfo")]
public class CurrentCarPartInfo : ScriptableObject
{
    public PartInfo wheel;              //车轮信息
    public PartInfo guide;              //导轮信息
    public PartInfo cover;              //车盖信息
    public PartInfo pan;                //底盘信息
    public PartInfo battery;            //电池信息
    public PartInfo motor;              //马达信息
}

[CreateAssetMenu(fileName ="PartAttrCollection", menuName = "Parts/PartAttrCollection")]
public class PartAttrCollection : ScriptableObject
{
    public List<WheelAttr> wheelAttr;   //车轮属性
}