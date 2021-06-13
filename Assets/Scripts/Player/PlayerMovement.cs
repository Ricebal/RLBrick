using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D m_controller = null;
    [SerializeField] private float m_hSpeed = 2f;
    [SerializeField] private float m_vSpeed = 2f;

    private float m_hMin;
    private float m_hMax;
    private bool m_touchLeft;
    private bool m_touchRight;
    private Vector2 m_desiredMove = Vector2.zero;
    private Rigidbody2D m_rigidbody2D;

    private void Start()
    {
        // Set initial variables and screen boundaries
        m_rigidbody2D = GetComponent<Rigidbody2D>();
        Vector2 screenSizeHalved = GameController.ScreenSizeHalved();
        m_hMin = -screenSizeHalved.x + (transform.localScale.x / 2);
        m_hMax = screenSizeHalved.x - (transform.localScale.x / 2);
    }

    private void Update()
    {
        // Get movement inputs and limit moving out of the screen
        m_desiredMove.x = Input.GetAxisRaw("Horizontal") * m_hSpeed;
        if (m_touchLeft && m_desiredMove.x > 0)
        {
            m_touchLeft = false;
        }
        if (m_touchRight && m_desiredMove.x < 0)
        {
            m_touchRight = false;
        }
        m_desiredMove.y = Input.GetAxisRaw("Vertical") * m_vSpeed;
    }

    private void FixedUpdate()
    {
        m_controller.Move(m_desiredMove);

        // Prevent the paddle from going off the screen
        if (transform.position.x < m_hMin || m_touchLeft)
        {
            m_touchLeft = true;
            transform.position = new Vector3(m_hMin, transform.position.y, transform.position.z);
            m_rigidbody2D.velocity = Vector2.zero;
        }

        if (transform.position.x > m_hMax || m_touchRight)
        {
            m_touchRight = true;
            transform.position = new Vector3(m_hMax, transform.position.y, transform.position.z);
            m_rigidbody2D.velocity = Vector2.zero;
        }
    }
}
