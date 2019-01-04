using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="partCollection")]
public class CarPartInfoCollection : ScriptableObject {

    public PartInfo[] wheel;
    public PartInfo[] guide;
    public PartInfo[] cover;
    public PartInfo[] pan;
    public PartInfo[] battery;
    public PartInfo[] motor;
}
