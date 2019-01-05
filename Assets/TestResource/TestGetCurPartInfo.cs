using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGetCurPartInfo : MonoBehaviour {

    private PlayerInfoManager _infoMgr;
    [SerializeField]PartInfo _info;
    [SerializeField] List<PartInfo> _partInfoList;
    private void Start()
    {
        _infoMgr = Object.FindObjectOfType<PlayerInfoManager>();
        _info = _infoMgr.GetCurrentCarPart(PartType.wheel);
        _partInfoList = _infoMgr.GetPlayerPartList(PartType.wheel);
    }
    private void OnGUI()
    {
        //GUILayout.Box("id: " + _info.id + "\nname: " + _info.name);
    }
}
