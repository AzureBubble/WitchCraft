using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 1f; // Adjust this value to change the speed

    private Vector3 mouseStartPosition;
    private Vector3 objectStartPosition;
    private bool isDragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPosition = Input.mousePosition;
            objectStartPosition = transform.position;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 mouseDelta = (Input.mousePosition - mouseStartPosition) * speed;
            Vector3 objectPosition = objectStartPosition + new Vector3(mouseDelta.x, 0f, 0f);
            transform.position = objectPosition;
        }
    }
}

