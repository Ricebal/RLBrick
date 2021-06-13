using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D m_controller = null;
    [SerializeField] private float m_speed;
    private Rigidbody2D m_rigidbody2D;
    private Vector2 m_direction = new Vector2(.5f, -1);
    private float m_hMin;
    private float m_hMax;
    private float m_vMin;
    private float m_vMax;

    private void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        Vector2 screenSizeHalved = GameController.ScreenSizeHalved();
        m_hMin = -screenSizeHalved.x;
        m_hMax = screenSizeHalved.x;
        m_vMin = -screenSizeHalved.y;
        m_vMax = screenSizeHalved.y;
    }

    private void FixedUpdate()
    {
        if (transform.position.y < m_vMin)
        {
            Debug.Log("Lost");
            return;
        }
        if (transform.position.x < m_hMin || transform.position.x > m_hMax)
        {
            m_direction.x *= -1;
        }

        if (transform.position.y > m_vMax)
        {
            m_direction.y *= -1;
        }
        m_controller.Move(m_direction * m_speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            float closestPoint = other.ClosestPoint(transform.position).x;
            float pos = other.transform.position.x;
            float hitPos = closestPoint - pos;
            m_direction.y *= -1;
            m_direction.x = hitPos;
        }
    }
}
