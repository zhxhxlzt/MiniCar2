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

    private List<PartInfo> __SelectPartListByType( PartType type )
    {
        List<PartInfo> list = default(List<PartInfo>);
        switch(type)
        {
            case PartType.wheel:
                list = wheel;
                break;
            case PartType.guide:
                list = guide;
                break;
            case PartType.cover:
                list = cover;
                break;
            case PartType.pan:
                list = pan;
                break;
            case PartType.battery:
                list = battery;
                break;
            case PartType.motor:
                list = motor;
                break;
        }
        return list;
    }

    //查找partInfo, 返回一个它的副本，避免外界通过它来修改私有成员
    public PartInfo FindPart( string name, PartType type )
    {
        return new PartInfo(__SelectPartListByType(type).Find(( e ) => e.name == name));
    }

    //查找partInfo List, 返回一个它的副本，避免外界通过它来修改私有成员
    public List<PartInfo> FindPartList( PartType type )
    {
        List<PartInfo> list = __SelectPartListByType(type);
        return new List<PartInfo>(list);
    }
    //增加一个partInfo
    public void AddPartInfo( PartInfo info )
    {
        var partList = __SelectPartListByType(info.type);
        if( !partList.Exists((e)=>e.name == info.name) )
        {
            partList.Add(new PartInfo(info));
        }
    }
    //减少一个PartInfo
    public void DelPartInfo( PartInfo info )
    {
        var partList = __SelectPartListByType(info.type);
        partList.Remove(info);
    }
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

    //通过零件类型选择相应PartInfo
    private PartInfo __SelectPartByType( PartType type )
    {
        PartInfo part = default(PartInfo);
        switch( type )
        {
            case PartType.wheel:
                part = wheel;
                break;
            case PartType.guide:
                part = guide;
                break;
            case PartType.cover:
                part = cover;
                break;
            case PartType.pan:
                part = pan;
                break;
            case PartType.battery:
                part = battery;
                break;
            case PartType.motor:
                part = motor;
                break;
        }
        return part;
    }
    //获取当前零件
    public PartInfo GetPartInfo(PartType type)
    {
        return new PartInfo(__SelectPartByType(type));
    }

    //设置当前零件
    public void SetPartInfo( PartInfo info )
    {
        PartInfo target = __SelectPartByType(info.type);
        target = new PartInfo(info);
    }
}

[CreateAssetMenu(fileName ="PartAttrCollection", menuName = "Parts/PartAttrCollection")]
public class PartAttrCollection : ScriptableObject
{
    public List<WheelAttr> wheelAttr;   //车轮属性
}