using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏信息管理器
/// 1、当前赛车信息
/// 2、所有零件信息
/// 3、所有零件属性
/// </summary>
public class PlayerInfoManager : MonoBehaviour {

    public CurrentCarPartInfo curPartInfo;                  //当前赛车信息
    public CarPartInfoCollection partInfoCollection;        //所有零件信息
    public PartAttrCollection partAttrCollection;           //所有零件属性

    //通过零件信息找到对应的零件属性
    public WheelAttr FindWheelAttr( string wheelName )
    {
        var attr = partAttrCollection.wheelAttr.Find(( e ) => e.name == wheelName);     //从车轮属性收集中寻找相同名字的车轮
        return attr;
    }

    public void GetWheelPart( WheelOperator wmg, out WheelPart wp )
    {
        PartInfo info = curPartInfo.wheel;                      //从当前赛车零件信息中寻找车轮信息
        WheelAttr attr = FindWheelAttr(info.name);              //根据车轮名字获取属性
        Skill skl = SkillManager.GetSkill(info.sklID);          //根据零件信息获取相应技能
        wp = new WheelPart(info, attr, skl, wmg);               //生成车轮零件实例
    }
}
