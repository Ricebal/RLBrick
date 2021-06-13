using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementCheat : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = Input.mousePosition;
        Vector3 newTransform = Camera.main.ScreenToWorldPoint(mousepos);
        newTransform.z = 0f;
        transform.position = newTransform;
    }
}
