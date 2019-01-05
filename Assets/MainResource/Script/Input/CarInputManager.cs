using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 获取赛车输入
/// </summary>
public class CarInputManager {

	public static float GetAccel()
    {
        return Input.GetAxis("Vertical");
    }

    public static float GetSteer()
    {
        return Input.GetAxis("Horizontal");
    }

    public static float GetBrake()
    {
        return Input.GetAxis("Jump");
    }
}
