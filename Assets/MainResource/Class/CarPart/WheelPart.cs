using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 提供控制车轮零件行为方法
/// 1、动力，转向，刹车
/// 2、技能施放
/// </summary>
public class WheelPart : IPart
{
    private PartInfo _info;         //零件信息
    private WheelAttr _attr;        //零件属性
    private Skill _skl;             //持有技能
    private WheelOperator _whl;     //车轮管理器

    private float _acl;             //加速控制 accel
    private float _str;             //转向控制 steer
    private float _brk;             //刹车控制 brake

    #region Public Member 
    //提供参数设置方法
    public float Accel { get { return _acl; } set { _acl = Mathf.Clamp(value, -1, 1); } }
    public float Steer { get { return _str; } set { _str = Mathf.Clamp(value, -1, 1); } }
    public float Brake { get { return _brk; } set { _brk = Mathf.Clamp(value, 0, 1); } }
    #endregion

    //构造函数
    public WheelPart( PartInfo info, WheelAttr attr, Skill skl, WheelOperator whl )
    {
        _info = info;
        _attr = attr;
        _skl = skl;
        _whl = whl;
        
    }

    #region Public Method
    //设置动力轮
    public void SetMotorWheel( WheelSelect wcs = WheelSelect.all )
    {
        _attr.motorWheel = wcs;
    }
    //设置制动轮
    public void SetBrakeWheel( WheelSelect wcs = WheelSelect.back )
    {
        _attr.brakeWheel = wcs;
    }
    //设置转向轮
    public void SetSteerWheel( WheelSelect wcs = WheelSelect.front )
    {
        _attr.steerWheel = wcs;
    }
    //应用参数变更
    public void Apply()
    {
        ApplyMotorTorque(_acl * _attr.motorTorque);
        ApplyBrakeTorque(_brk * _attr.brakeTorque);
        ApplySteerAngle(_str * _attr.steerAngle);
    }
    //同步车轮模型
    public void SyncMesh()
    {
        _whl.SyncMesh();
    }

    #endregion
    #region IPart Interface 
    public Order GenOrder()
    {
        float accel = CarInputManager.GetAccel();
        float steer = CarInputManager.GetSteer();
        float brake = CarInputManager.GetBrake();

        DriveInfo orderInfo = new DriveInfo(accel, steer, brake);

        DriveOrder order = new DriveOrder(orderInfo, this);

        return order;
    }
    public void RunOrder( Order order )
    {
        order.Apply();
    }
    public void UseSkill()
    {
        _skl.Use();
    }
    #endregion
    #region Private Method
    //设置动力扭矩
    private void ApplyMotorTorque( float torque )
    {
        _whl.SetMotorTorque(torque, _attr.motorWheel);
    }
    //设置制动扭矩
    private void ApplyBrakeTorque( float torque )
    {
        _whl.SetBrakeTorque(torque, _attr.brakeWheel);
    }
    //设置转向扭矩
    private void ApplySteerAngle( float steer )
    {
        _whl.SetSteerAngle(steer, _attr.steerWheel);
    }
    #endregion
    
}

