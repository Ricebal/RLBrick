using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Singleton;
    [SerializeField] private GameOverUI m_gameOverUI;

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

    public static void ShowGameOverScreen(bool show) => Singleton.m_gameOverUI.ShowPanel(show);
}
