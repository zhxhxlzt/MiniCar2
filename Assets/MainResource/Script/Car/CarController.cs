using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 赛车控制器，提供赛车所有零件的控制方法
/// </summary>
public class CarController : MonoBehaviour
{
    private WheelController _carDriveCtrl;                                   //驾驶控制器
    [SerializeField] private  WheelOperator _wmg;                            //车轮管理器
    [SerializeField] private  Rigidbody _rg;                                 //赛车刚体

    private void Awake()
    {
        _carDriveCtrl = new WheelController( _wmg );         //生成车轮控制器
        #region Test Region
        //*************Test**************
        //Test();
        #endregion
    }
    //使用配件技能
    public void UsePartSkill( IPart part )
    {
        part.UseSkill();
    }
    //在固定时间更新配件的fixdeUpdate方法
    public void FixeUpdateParts()
    {
        _carDriveCtrl.FixedUpdate();
    }
    
    //调用所有零件的固定时间更新方法
    private void FixedUpdate()
    {
        FixeUpdateParts();
        //if( TestMethod != null ) TestMethod();
    }

    private void OnGUI()
    {
        if( GUILayout.Button("Pause") ) _carDriveCtrl.Drivable = false;
        if( GUILayout.Button("Resume") ) _carDriveCtrl.Drivable = true;
        GUILayout.BeginHorizontal();
        GUILayout.Box(Convert.ToInt16((_rg.velocity.magnitude * 3.6f * 2)).ToString());
        GUILayout.Box("KM/H");
        GUILayout.EndHorizontal();
    }

    //#region Test Method
    //public Action TestMethod;
    //bool enableDrive = true;
    //Queue<Order> os = new Queue<Order>();
    //Vector3 pos;
    //Quaternion quat;

    //public void HandleDrive()
    //{
    //    if( Input.GetKeyDown(KeyCode.R) ) enableDrive = !enableDrive;
    //    if( enableDrive )
    //        Drive(GetDriveOrder());
    //}

    //public void SetStartPosition()
    //{
    //    pos = transform.position;
    //    quat = transform.rotation;
    //}

    //public void TestDrive()
    //{
    //    Order o = GetDriveOrder();
    //    os.Enqueue(o);
    //    Drive(o);
    //}

    //public void TestReplay()
    //{
    //    transform.SetPositionAndRotation(pos, quat);
    //    _carDriveCtrl.Reset();
    //    _carDriveCtrl.InputOrderSequence(os);
    //}

    //public void ReplayTest()
    //{
    //    if( Input.GetKeyDown(KeyCode.B) )
    //    {
    //        Debug.Log("Record begin!");
    //        SetStartPosition();
    //        TestMethod += TestDrive;
    //        Debug.Log("Start Position is:" + pos);
    //    }

    //    if( Input.GetKeyDown(KeyCode.E) )
    //    {
    //        Debug.Log("Begin Replay!");
    //        TestMethod -= TestDrive;
    //        _rg.velocity = Vector3.zero;
    //        TestReplay();
    //    }

    //}

    //public void Test()
    //{
    //    TestMethod += ReplayTest;
    //}
    //#endregion
}
