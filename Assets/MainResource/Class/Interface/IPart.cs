using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//零件功能接口
public interface IPart
{
    Order GenOrder();                   //根据玩家输入和条件生成指令
    void RunOrder( Order order );       //执行指令
    void UseSkill();                    //使用零件技能
}
