using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInput {
    private CarOrder _order;
    private WheelPart _wp;

    public float TimePoint { get { return _order._timePoint; } set { _order._timePoint = value; } }

    public CarInput( float accel, float steer, float brake, WheelPart wp )
    {
        _order._accel = accel;
        _order._steer = steer;
        _order._brake = brake;
        _wp = wp;
    }

    public CarInput( CarOrder order, WheelPart wp )
    {
        _order = order;
        _wp = wp;
    }
    
    public void Excute( WheelPart wp )
    {
        _wp = wp;
        Excute();
    }

    public void Excute()
    {
        _wp.Accel = _accel;
        _wp.Steer = _steer;
        _wp.Brake = _brake;
        _wp.Apply();
    }
}

public struct CarOrder
{
    public float _accel;
    public float _steer;
    public float _brake;
    public float _timePoint;
}
