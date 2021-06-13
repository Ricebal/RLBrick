using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D m_controller = null;
    [SerializeField] private float m_speed;
    private Rigidbody2D m_rigidbody2D;
    private Vector2 m_direction = new Vector2(.5f, -1);

    private void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        m_controller.Move(m_direction * m_speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            float closestPoint = other.ClosestPoint(transform.position).x;
            float pos = other.transform.position.x;
            float hitPos = closestPoint - pos;
            Debug.Log(closestPoint);
            Debug.Log(pos);
            Debug.Log(hitPos);
            m_direction.y *= -1;
            float bounce = m_direction.x + hitPos;
            m_direction.x = hitPos;
        }
    }
}
