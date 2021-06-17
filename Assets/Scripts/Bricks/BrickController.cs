using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrickSides { LEFT, RIGHT, UP, DOWN }

public class BrickController : MonoBehaviour
{

    public static BrickController Singleton;

    [SerializeField] private List<Brick> m_bricks = new List<Brick>();

    private void Awake()
    {
        InitializeSingleton();
    }

    private void InitializeSingleton()
    {
        if (Singleton != null && Singleton != this)
        {
            Destroy(this);
        }
        else
        {
            Singleton = this;
        }
    }
}
