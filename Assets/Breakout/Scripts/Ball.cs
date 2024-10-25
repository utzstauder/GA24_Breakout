using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public float initialSpeed = 10f;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rigidbody2d.velocity = new Vector2(0, initialSpeed);
    }
}
