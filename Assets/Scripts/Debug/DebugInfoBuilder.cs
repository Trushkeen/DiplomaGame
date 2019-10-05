using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInfoBuilder
{
    private string DebugInfo = string.Empty;

    public void AddFacingInfo(string name)
    {
        DebugInfo += $"Facing at {name}\n";
    }

    public void AddFPSInfo(string count)
    {
        DebugInfo += $"FPS: {count}\n";
    }

    public void AddXYZInfo(string label, float x, float y, float z)
    {
        DebugInfo += $"{label} X:{x}, Y:{y}, Z:{z}\n";
    }

    public void AddVector2Info(string label, Vector2 v)
    {
        DebugInfo += $"{label} X:{v.x}, Y:{v.y}\n";
    }

    public void AddVector3Info(string label, Vector3 v)
    {
        DebugInfo += $"{label} X:{v.x}, Y:{v.y}, Z{v.z}\n";
    }

    public void AddQuaternionInfo(string label, Quaternion v)
    {
        DebugInfo += $"{label} X: {v.x}, Y: {v.y}, Z: {v.z}, W: {v.w}\n";
    }

    public void AddSampleInfo(string label, string info)
    {
        DebugInfo += $"{label}: {info}\n";
    }

    public string Return()
    {
        return DebugInfo;
    }
}
