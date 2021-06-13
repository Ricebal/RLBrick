using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D m_rigidbody2D;
    private Vector3 m_velocity = Vector3.zero;


    void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 move)
    {
        Vector3 targetVelocity = new Vector2(move.x, move.y);
        m_rigidbody2D.velocity = targetVelocity;
    }
}
