using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Singleton;
    [SerializeField] private GameOverUI m_gameOverUI;
    [SerializeField] private HUDUI m_hudUI;
    [SerializeField] private ShopUI m_shopUI;

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
    public static void ShowShop(bool show) => Singleton.m_shopUI.ShowPanel(show);

    public static void SetCoinText(float amount) => Singleton.m_hudUI.SetCoinText(amount);
}
