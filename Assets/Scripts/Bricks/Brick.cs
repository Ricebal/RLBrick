using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private float m_health = 100f;
    [SerializeField] private float m_baseCoinValue = 10f;

    private void Start()
    {
        BrickManager.AddBrick(this);
    }

    public void TakeDamage(float amount)
    {
        m_health = Mathf.Max(0, m_health - amount);
        if (m_health == 0)
            Break();
    }

    private void Break()
    {
        ScoreManager.AddCoins(m_baseCoinValue);
        BrickManager.RemoveBrick(this);
        Destroy(this.gameObject);
    }
}
