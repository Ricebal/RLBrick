using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController2D m_controller = null;
    [SerializeField] private float m_hSpeed = 2f;
    [SerializeField] private float m_vSpeed = 2f;

    private Vector2 m_desiredMove = Vector2.zero;


    private void Update()
    {
        m_desiredMove.x = Input.GetAxisRaw("Horizontal") * m_hSpeed;
        m_desiredMove.y = Input.GetAxisRaw("Vertical") * m_vSpeed;
    }

    private void FixedUpdate()
    {
        m_controller.Move(m_desiredMove);
    }
}
