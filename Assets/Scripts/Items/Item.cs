using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Custom/Item", order = 0)]
public class Item : ScriptableObject
{
    public string Name;
    public string Description;
    public float Cost;
}
