using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Singleton;
    private float m_totalScore;
    private float m_coins;

    private void Awake()
    {
        InitializeSingleton();
        m_totalScore = 0;
        m_coins = 0;
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

    public static void AddCoins(float amount)
    {
        Singleton.m_coins += amount;
        Singleton.m_totalScore += amount * 10;
        UIManager.SetCoinText(Singleton.m_coins);
    }

    public static bool RemoveCoins(float amount)
    {
        if (amount > Singleton.m_coins)
        {
            return false;
        }
        Singleton.m_coins -= amount;
        UIManager.SetCoinText(Singleton.m_coins);
        return true;
    }
}
