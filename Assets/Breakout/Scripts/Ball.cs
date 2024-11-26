using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    public float initialSpeed = 10f;
    private Vector3 initialPosition;

    [Range(0.95f, 1.05f)]
    public float speedIncreaseMultiplier = 1f;

    private float currentSpeed;

    private bool isReadyToLaunch;

    GameObject playerGameObject;
    public Vector2 playerOffset = new Vector2(0, 1f);

    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    private void Start()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
        print(playerGameObject.name);

        isReadyToLaunch = true;
    }

    private void Update()
    {
        if (isReadyToLaunch)
        {
            Vector2 playerPosition = playerGameObject.transform.position;
            // rigidbody2d.MovePosition(playerPosition + playerOffset);
            transform.position = playerPosition + playerOffset;

            if (Input.GetMouseButtonDown(0))
            {
                currentSpeed = initialSpeed;
                rigidbody2d.velocity = new Vector2(0, initialSpeed);

                isReadyToLaunch = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        currentSpeed *= speedIncreaseMultiplier;

        rigidbody2d.velocity = rigidbody2d.velocity.normalized * currentSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        rigidbody2d.velocity = Vector2.zero;
        rigidbody2d.MovePosition(initialPosition);
        isReadyToLaunch = true;
    }
}
