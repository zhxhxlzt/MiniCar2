using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制器接口，用来控制零件控制器的行为
/// </summary>
public interface IPartController {
    void Start();
    void FixedUpdate();
    void Update();
    //void End();
    //void Pause();
    //void Resume();
}
