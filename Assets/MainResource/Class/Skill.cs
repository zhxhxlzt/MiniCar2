using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill {
    private GameObject _gb;
    public Skill( GameObject gb ) { _gb = gb; }
    public virtual void Use() { }
}
