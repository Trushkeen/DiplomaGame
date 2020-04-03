using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New lootable object", menuName = "Loot")]
public class Loot : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public float Cost;
}
