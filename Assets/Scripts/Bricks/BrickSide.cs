using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSide : MonoBehaviour
{
    [SerializeField] private BrickSides m_side;

    public BrickSides GetSide()
    {
        return m_side;
    }
}
