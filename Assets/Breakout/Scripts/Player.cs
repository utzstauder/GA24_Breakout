using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    Vector3 mousePositionScreen;
    Vector3 mousePositionWorldSpace; 

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        mousePositionScreen = Input.mousePosition;

        mousePositionWorldSpace = Camera.main.ScreenToWorldPoint(mousePositionScreen);

        print(mousePositionWorldSpace);
    }

    private void FixedUpdate()
    {
        Vector2 newPlayerPosition = new Vector2(mousePositionWorldSpace.x, rigidbody2d.position.y);
        rigidbody2d.MovePosition(newPlayerPosition);
    }
}
