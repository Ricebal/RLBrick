using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private float m_health = 100f;

    public void TakeDamage(float amount)
    {
        m_health = Mathf.Max(0, m_health - amount);
        Debug.Log("Ouch I took " + amount + " damage, I now have " + m_health + " hp left.");
        if (m_health == 0)
            Break();
    }

    private void Break()
    {
        Debug.Log("I died");
        Destroy(this.gameObject);
    }
}
