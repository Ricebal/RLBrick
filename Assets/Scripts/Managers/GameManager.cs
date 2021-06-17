using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;

    [SerializeField] private Camera m_mainCamera = null;
    [SerializeField] private Transform m_playerPosition = null;

    private bool m_canControl = true;

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

    public static Vector2 ScreenSizeHalved()
    {
        float halfHeight = Singleton.m_mainCamera.orthographicSize;
        float halfWidth = Singleton.m_mainCamera.aspect * halfHeight;
        return new Vector2(halfWidth, halfHeight);
    }

    public static Transform PlayerPosition()
    {
        return Singleton.m_playerPosition;
    }

    public static void ChangeControlState(bool enabled)
    {
        Singleton.m_canControl = enabled;
    }

    public static bool CanControl()
    {
        return Singleton.m_canControl;
    }

    public static void EndLevel()
    {
        UIManager.ShowShop(true);
    }
}
