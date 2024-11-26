using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public float initialSpeed = 10f;

    [Range(0.95f, 1.05f)]
    public float speedIncreaseMultiplier = 1f;

    private float currentSpeed;

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        currentSpeed = initialSpeed;
        rigidbody2d.velocity = new Vector2(0, initialSpeed); ;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed *= speedIncreaseMultiplier;

        rigidbody2d.velocity = rigidbody2d.velocity.normalized * currentSpeed;
    }
}
