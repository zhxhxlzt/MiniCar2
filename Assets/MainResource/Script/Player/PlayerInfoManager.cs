using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 游戏信息管理器
/// 1、当前赛车信息
/// 2、所有零件信息
/// 3、所有零件属性
/// 4、根据当前零件信息生成零件类
/// *************************************
/// 1、增加/减少/获取玩家拥有的零件
/// 2、改变当前赛车的零件
/// </summary>
public class PlayerInfoManager : MonoBehaviour {

    public CurrentCarPartInfo curPartInfo;                  //当前赛车信息
    public CarPartInfoCollection partInfoCollection;        //所有零件信息
    public CarPartInfoCollection player;                    //玩家拥有的零件
    public PartAttrCollection partAttrCollection;           //所有零件属性
    

    //通过零件信息找到对应的零件属性
    public WheelAttr FindWheelAttr( string wheelName )
    {
        var attr = partAttrCollection.wheelAttr.Find(( e ) => e.name == wheelName);     //从车轮属性收集中寻找相同名字的车轮
        return attr;
    }
    //生成车轮零件
    public void GetWheelPart( WheelOperator wmg, out WheelPart wp )
    {
        PartInfo info = curPartInfo.wheel;                      //从当前赛车零件信息中寻找车轮信息
        WheelAttr attr = FindWheelAttr(info.name);              //根据车轮名字获取属性
        Skill skl = SkillManager.GetSkill(info.sklID);          //根据零件信息获取相应技能
        wp = new WheelPart(info, attr, skl, wmg);               //生成车轮零件实例
    }
    //获取当前赛车零件
    public PartInfo GetCurrentCarPart(PartType type)
    {
        return curPartInfo.GetPartInfo(type);
    }
    //设置当前赛车零件
    public void SetCurrentCarPart(PartInfo info)
    {
        curPartInfo.SetPartInfo(info);
    }
    //给玩家添加零件
    public void AddPlayerPart( string name, PartType type )
    {
        PartInfo info = partInfoCollection.FindPart(name, type);
        player.AddPartInfo(info);
    }
    //给玩家删除零件
    public void DelPlayerPart( string name, PartType type )
    {
        PartInfo info = partInfoCollection.FindPart(name, type);
        player.DelPartInfo(info);
    }
    //返回玩家零件列表
    public List<PartInfo> GetPlayerPartList( PartType type )
    {
        return player.FindPartList(type);
    }
}
