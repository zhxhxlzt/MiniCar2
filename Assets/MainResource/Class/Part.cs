using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WheelMgr;

//零件功能接口
public interface IPart {

    void Start();           //开始时调用
    void Update();          //每帧更新
    void FixedUpdate();     //固定时间更新
    void UseSkill();        //使用零件技能
}

public class WheelPart : IPart
{
    #region Private Member

    private PartInfo _info;         //零件信息
    private WheelAttr _attr;        //零件属性
    private Skill _skl;             //持有技能
    private WheelManager _wmg;      //车轮管理器

    private float _acl;             //加速控制 accel
    private float _str;             //转向控制 steer
    private float _brk;             //刹车控制 brake

    private WheelSelect _mtts;      //动力扭矩作用车轮
    private WheelSelect _bkts;      //刹车扭矩作用车轮
    private WheelSelect _strs;      //转向扭矩作用车轮
    #endregion

    #region Public Member 
    //提供参数设置方法
    public float Accel { get { return _acl; } set { _acl = Mathf.Clamp(value, -1, 1); } }
    public float Steer { get { return _str; } set { _str = Mathf.Clamp(value, -1, 1); } }
    public float Brake { get { return _brk; } set { _brk = Mathf.Clamp(value, 0, 1); } }
    #endregion

    //设置动力轮
    public void SetMotorWheel( WheelSelect wcs = WheelSelect.all )
    {
        _mtts = wcs;
    }
    //设置制动轮
    public void SetBrakeWheel( WheelSelect wcs = WheelSelect.back )
    {
        _bkts = wcs;
    }
    //设置转向轮
    public void SetSteerWheel( WheelSelect wcs = WheelSelect.front )
    {
        _strs = wcs;
    }
    //应用参数变更
    public void Apply()
    {
        ApplyMotorTorque(_acl * _attr.motorTorque);
        ApplyBrakeTorque(_brk * _attr.brakeTorque);
        ApplySteerAngle(_str * _attr.steerAngle);
    }

    #region Private Method
    //设置动力扭矩
    private void ApplyMotorTorque( float torque )
    {
        _wmg.SetMotorTorque(torque, _mtts);
    }
    //设置制动扭矩
    private void ApplyBrakeTorque( float torque )
    {
        _wmg.SetBrakeTorque(torque, _bkts);
    }
    //设置转向扭矩
    private void ApplySteerAngle( float steer )
    {
        _wmg.SetSteerAngle(steer, _strs);
    }
    #endregion

    #region IPart Interface 

    public void Start() { }
    public void Update() { }
    public void FixedUpdate() { }
    public void UseSkill()
    {
        _skl.Use();
    }

    #endregion
}


