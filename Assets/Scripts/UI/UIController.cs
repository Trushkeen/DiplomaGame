using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI DebugText;
    
    private Camera PlayerCamera;

    void Start()
    {
        PlayerCamera = Camera.main;
    }

    void Update()
    {
        var tr = PlayerCamera.transform;
        var info = new DebugInfoBuilder();
        string debugInfo = string.Empty;
        if (Physics.Raycast(tr.position, tr.forward, out RaycastHit hit, 10F, ~(2 << 8), QueryTriggerInteraction.Ignore))
        {
            info.AddFacingInfo(hit.collider.name);
        }
        info.AddVector3Info("Camera Pos", PlayerCamera.transform.position);
        DebugText.text = info.Return();
    }
}
