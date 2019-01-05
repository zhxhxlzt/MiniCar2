using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//驾驶命令参数
public struct DriveInfo
{
    public float _accel;    //加速
    public float _steer;    //转向
    public float _brake;    //刹车

    public DriveInfo( float accel = 0, float steer = 0, float brake = 0 )
    {
        _accel = accel;
        _steer = steer;
        _brake = brake;
    }
}

public class Order
{
    public virtual void Apply() { }
}

/// <summary>
/// 赛车命令类，用于实现命令模式
/// </summary>
public class DriveOrder : Order {
    private DriveInfo _driveInfo;   //驾驶信息
    private WheelPart _wp;          //车轮控制
    
    public DriveOrder( DriveInfo order, WheelPart wp )
    {
        _driveInfo = order;
        _wp = wp;
    }
    
    //设置车轮零件参数
    public override void Apply()
    {
        _wp.Accel = _driveInfo._accel;
        _wp.Steer = _driveInfo._steer;
        _wp.Brake = _driveInfo._brake;
        _wp.Apply();
    }
}


