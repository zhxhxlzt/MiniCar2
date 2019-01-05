using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using WC = UnityEngine.WheelCollider;

public enum WheelSelect { frontLeft, frontRight, backLeft, backRight, front, back, all } //车轮选择

public class WheelOperator : MonoBehaviour
{
    [SerializeField] private List<WC> _wc = new List<WC>();                     //车轮碰撞器
    [SerializeField] private List<Transform> _wm = new List<Transform>();       //车轮模型transform

    //选择出一个或一组特定的车轮
    public List<WC> SelectWheel( WheelSelect opt )
    {
        List<WC> targetWheels = new List<WC>();
        switch( opt )
        {
            case WheelSelect.frontLeft:
                targetWheels.Add(_wc[0]);
                break;
            case WheelSelect.frontRight:
                targetWheels.Add(_wc[1]);
                break;
            case WheelSelect.backLeft:
                targetWheels.Add(_wc[2]);
                break;
            case WheelSelect.backRight:
                targetWheels.Add(_wc[3]);
                break;
            case WheelSelect.front:
                targetWheels.Add(_wc[0]);
                targetWheels.Add(_wc[1]);
                break;
            case WheelSelect.back:
                targetWheels.Add(_wc[2]);
                targetWheels.Add(_wc[3]);
                break;
            case WheelSelect.all:
                for( int i = 0; i < _wc.Capacity; i++ )
                {
                    targetWheels.Add(_wc[i]);
                }
                break;
        }

        return targetWheels;
    }
    //设置动力扭矩
    public void SetMotorTorque( float torque, WheelSelect ws )
    {
        var wcs = SelectWheel(ws);
        foreach( WC e in wcs )
        {
            e.motorTorque = torque;
        }
    }
    //设置制动扭矩
    public void SetBrakeTorque( float torque, WheelSelect ws )
    {
        var wcs = SelectWheel(ws);
        foreach( WC e in wcs )
        {
            e.brakeTorque = torque;
        }
    }
    //设置转向角度
    public void SetSteerAngle( float angle, WheelSelect ws )
    {
        var wcs = SelectWheel(ws);
        foreach( WC e in wcs )
        {
            e.steerAngle = angle;
        }
    }
    //设置车轮半径
    public void SetRadius( float r )
    {
        _wc.ForEach(( e ) => e.radius = r);
    }
    //设置模型与车轮同步
    public void SyncMesh()
    {
        for( int i = 0; i < 4; i++ )
        {
            Vector3 pos;    Quaternion quat;
            _wc[i].GetWorldPose(out pos, out quat);
            _wm[i].SetPositionAndRotation(pos, quat);
        }
    }
}

