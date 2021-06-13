using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDamage : MonoBehaviour
{
    [SerializeField] private float m_damage = 50f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Brick")
        {
            other.GetComponent<Brick>().TakeDamage(m_damage);
        }
    }
}
