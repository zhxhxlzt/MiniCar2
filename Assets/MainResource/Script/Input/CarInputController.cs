using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriveInputController : MonoBehaviour {

    private WheelPart _wp;                                  //车轮配件
    private Queue<CarInput> _os = new Queue<CarInput>();    //指令序列
    private List<CarOrder> _osbp = new List<CarOrder>();    //备份指令
    private CarOrder _order;                                //指令
    private float _startTime;                               //开始时间

    private void FixedUpdate()
    {
        float accel = Input.GetAxis("Vertical");
        float steer = Input.GetAxis("Horizontal");
        float brake = Input.GetAxis("Jump");

        if( _order._accel != accel || _order._steer != steer || _order._brake != brake )
        {
            _order._accel = accel;
            _order._steer = steer;
            _order._brake = brake;
            _order._timePoint = Time.time - _startTime;
            CarInput order = new CarInput(_order, _wp);
            _osbp.Add(_order);
            order.TimePoint = Time.time - _startTime;
            _os.Enqueue(order);
        }
    }

    public void Record(CarOrder order)
    {
        _osbp.Add(order);
    }


}
