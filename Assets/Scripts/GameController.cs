using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Singleton;

    [SerializeField] private Camera m_mainCamera = null;
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
}
