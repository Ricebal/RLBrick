using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{

    public static BrickManager Singleton;

    [SerializeField] private List<Brick> m_bricks;

    private void Awake()
    {
        InitializeSingleton();
        m_bricks = new List<Brick>();
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


    public static void AddBrick(Brick brick)
    {
        Singleton.m_bricks.Add(brick);
    }

    public static void RemoveBrick(Brick brick)
    {
        Singleton.m_bricks.Remove(brick);
        if (Singleton.m_bricks.Count == 0)
        {
            GameManager.EndLevel();
        }
    }
}
