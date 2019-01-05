using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : IPartController {

    private WheelPart _wp;                                      //车轮配件
    private Queue<Order> _os;                                   //指令序列

    private delegate void fixedUpdate();
    private fixedUpdate _fixedUpdate;

    private bool _drivable;

    public bool Drivable { get { return _drivable; }
        set
        {
            if( value == _drivable ) return;

            _drivable = value;

            if( _drivable )
            {
                _fixedUpdate += Drive;
            }
            else
            {
                _fixedUpdate -= Drive;
            }
        } }

    //根据输入驾驶
    public void Drive()
    {
        _wp.GenOrder().Apply();
    }
    //构造函数
    public WheelController( WheelOperator wmg )
    {
        var userInfoMgr = Object.FindObjectOfType<PlayerInfoManager>();
        userInfoMgr.GetWheelPart(wmg, out _wp);    //初始化车轮控制器
        _os = new Queue<Order>();
        Drivable = true;
    }
    //更换配件
    public void ChangeWheelPart( WheelPart wp )
    {
        _wp = wp;
    }
    //将输入变为命令并执行，同时存储命令
    //获取配件接口
    public IPart GetPartInterface()
    {
        return _wp;
    }
    //输入指令序列
    public void InputOrderSequence( Queue<Order> os )
    {
        _os.Clear();
        _os = new Queue<Order>(os);
    }

    #region IPartController Interface
    public void Start()
    {
    }
    public void FixedUpdate()
    {
        if( _fixedUpdate != null ) _fixedUpdate();
        _wp.SyncMesh();
    }
    public void Update()
    {

    }
    #endregion
    private void HandleDrive()
    {
        Debug.Log("HandleDrive!" + "os count: " + _os.Count);
        if( _os.Count != 0 )
        {
            Order od = _os.Dequeue();
            od.Apply();
            
        }
    }
    
}
