using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//车轮零件属性，表示四个轮子组成的整体
[System.Serializable]
public struct WheelAttr
{
    [SerializeField] public string name;            //名称
    [SerializeField] public string material;        //材质
    [SerializeField] public float motorTorque;      //动力扭矩
    [SerializeField] public float brakeTorque;      //制动扭矩
    [SerializeField] public float steerAngle;       //转向角度
    [SerializeField] public float forwardStiff;     //正向摩擦
    [SerializeField] public float sidewayStiff;     //侧向摩擦

    [SerializeField] public WheelSelect motorWheel; //动力轮
    [SerializeField] public WheelSelect brakeWheel; //制动轮
    [SerializeField] public WheelSelect steerWheel; //转向轮
}
