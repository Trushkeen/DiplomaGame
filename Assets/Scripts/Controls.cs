using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Controls
{
    //Weapon Interaction
    public static KeyCode FireBtn { get; set; } = KeyCode.Mouse0;
    public static KeyCode ReloadBtn { get; set; } = KeyCode.R;

    //Movement
    public static KeyCode ForwardBtn { get; set; } = KeyCode.W;
    public static KeyCode BackwardBtn { get; set; } = KeyCode.S;
    public static KeyCode LeftBtn { get; set; } = KeyCode.A;
    public static KeyCode RightBtn { get; set; } = KeyCode.D;
    public static KeyCode JumpBtn { get; set; } = KeyCode.Space;
}
