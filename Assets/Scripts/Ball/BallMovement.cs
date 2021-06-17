using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float m_speed;
    private Rigidbody2D m_rigidbody2D;
    private bool m_attached;
    private bool m_shot;
    private bool m_leftPaddle;
    private float m_hMin;
    private float m_hMax;
    private float m_vMin;
    private float m_vMax;
    private Transform m_playerPosition;

    private void Start()
    {
        // Set initial variables and screen boundaries
        m_rigidbody2D = GetComponent<Rigidbody2D>();

        Vector2 screenSizeHalved = GameController.ScreenSizeHalved();
        m_hMin = -screenSizeHalved.x + (transform.localScale.x / 2);
        m_hMax = screenSizeHalved.x - (transform.localScale.x / 2);
        m_vMin = -screenSizeHalved.y + transform.localScale.y;
        m_vMax = screenSizeHalved.y - transform.localScale.y;

        m_playerPosition = GameController.PlayerPosition();
        ResetBall();
    }

    private void Update()
    {
        // Shoot the ball if the shoot button is pressed and the ball is attached to the paddle
        if (Input.GetButtonDown("Shoot") && m_attached)
        {
            m_shot = true;
        }
    }

    private void FixedUpdate()
    {
        // If the player shoots unattach the ball from the paddle
        if (m_shot)
        {
            m_rigidbody2D.AddForce(RandomDirection());
            m_shot = false;
            m_attached = false;
        }

        // If the ball is attached to the paddle follow the movement of the paddle
        if (m_attached && !m_leftPaddle)
        {
            transform.position = new Vector3(m_playerPosition.position.x, m_playerPosition.position.y + transform.localScale.y, m_playerPosition.position.z);

            return;
        }

        // Reset ball when it goes off the bottom of the screen
        if (transform.position.y < m_vMin)
        {
            UIManager.ShowGameOverScreen(true);
            ResetBall();

            return;
        }

        // Bounce of the vertical walls
        if (transform.position.x < m_hMin || transform.position.x > m_hMax)
        {
            m_rigidbody2D.velocity = new Vector2(-m_rigidbody2D.velocity.x, m_rigidbody2D.velocity.y);
        }

        // Bounce off the ceiling
        if (transform.position.y > m_vMax)
        {
            m_rigidbody2D.velocity = new Vector2(m_rigidbody2D.velocity.x, -m_rigidbody2D.velocity.y);
        }
    }

    // Reset the velocity and generate a new random direction for the next shot
    private void ResetBall()
    {
        m_rigidbody2D.velocity = Vector2.zero;
        m_attached = true;
        m_shot = false;
        m_leftPaddle = false;
    }

    private Vector2 RandomDirection() => new Vector2((float)Random.Range(-m_speed, m_speed), m_speed);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            CollideWithPlayer(other);
        }
    }

    private void CollideWithPlayer(Collider2D player)
    {
        if (!m_leftPaddle)
            return;

        float closestPoint = player.ClosestPoint(transform.position).x;
        float pos = player.transform.position.x;
        float hitPos = closestPoint - pos;
        m_rigidbody2D.velocity = Vector2.zero;
        m_rigidbody2D.AddForce(new Vector2(hitPos * m_speed, m_speed));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            m_leftPaddle = true;
        }
    }
}
