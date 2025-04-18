using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [HideInInspector]
    public float speed;

    private Rigidbody2D my_body;

    private void Awake()
    {
        my_body = GetComponent<Rigidbody2D>();

        speed = 7;
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        my_body.velocity = new Vector2(speed, my_body.velocity.y);
    }
}