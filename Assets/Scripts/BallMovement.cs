using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D m_controller = null;
    [SerializeField] private float m_speed;
    private Rigidbody2D m_rigidbody2D;
    private Vector2 m_direction;
    private bool m_attached = true;
    private bool m_shot = false;
    private bool m_leftPaddle = false;
    private float m_hMin;
    private float m_hMax;
    private float m_vMin;
    private float m_vMax;
    private Transform m_playerPosition;

    private void Start()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();

        Vector2 screenSizeHalved = GameController.ScreenSizeHalved();
        m_hMin = -screenSizeHalved.x + transform.localScale.x;
        m_hMax = screenSizeHalved.x - transform.localScale.x;
        m_vMin = -screenSizeHalved.y + transform.localScale.y;
        m_vMax = screenSizeHalved.y - transform.localScale.y;

        m_playerPosition = GameController.PlayerPosition();

        m_direction = RandomDirection();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Shoot") && m_attached)
        {
            m_shot = true;
        }
    }

    private void FixedUpdate()
    {
        if (m_shot)
        {
            m_direction = RandomDirection();
            Debug.Log(RandomDirection());
            Debug.Log(RandomDirection());
            Debug.Log(RandomDirection());
            Debug.Log(RandomDirection());
            Debug.Log(RandomDirection());
            m_shot = false;
            m_attached = false;
        }

        if (m_attached && !m_leftPaddle)
        {
            transform.position = new Vector3(m_playerPosition.position.x, m_playerPosition.position.y + transform.localScale.y, m_playerPosition.position.z);

            return;
        }

        if (transform.position.y < m_vMin)
        {
            ResetBall();

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

    private void ResetBall()
    {
        Debug.Log("lost");
        m_rigidbody2D.velocity = Vector2.zero;

        m_attached = true;
        m_shot = false;
        m_leftPaddle = false;
    }

    private Vector2 RandomDirection() => new Vector2((float)Random.Range(-100, 101) / 100, 1);


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            if (!m_leftPaddle)
                return;


            float closestPoint = other.ClosestPoint(transform.position).x;
            float pos = other.transform.position.x;
            float hitPos = closestPoint - pos;
            m_direction.y *= -1;
            m_direction.x = hitPos;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            m_leftPaddle = true;
        }
    }
}
