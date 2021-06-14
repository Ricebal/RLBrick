using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSide : MonoBehaviour
{
    [SerializeField] private BrickSides m_side;
    private bool m_disabled = false;
    private float m_timeDisabled;

    public BrickSides GetSide()
    {
        return m_side;
    }

    public void Touch()
    {
        Debug.Log("Hit: " + m_side);
        foreach (BrickSide brickSide in transform.parent.GetComponentsInChildren<BrickSide>())
        {
            if (brickSide.GetSide() != m_side)
            {
                Debug.Log("Disabled: " + brickSide.GetSide());
                brickSide.Disable();
            }
        }
    }

    public void Untouch()
    {
        foreach (BrickSide brickSide in transform.parent.GetComponentsInChildren<BrickSide>())
        {
            Debug.Log("Enabling: " + brickSide.GetSide());
            brickSide.Enable();
        }
    }

    public void Enable()
    {
        m_disabled = true;
    }

    public void Disable()
    {
        m_disabled = true;
    }

    public bool IsDisabled()
    {
        return m_disabled;
    }
}
