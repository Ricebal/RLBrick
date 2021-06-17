using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDamage : MonoBehaviour
{
    [SerializeField] private float m_damage = 50f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Brick")
        {
            other.transform.GetComponent<Brick>().TakeDamage(m_damage);
        }
    }
}
