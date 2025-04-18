using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 temproray_position;

    [SerializeField]
    private float minimum_x, maximum_x;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // LateUpdate is called after all calculations are finished
    void LateUpdate() //
    {
        // Checks if player is not equal to null
        if (!player)
        {
            return; // If test is met, it skips the following code
        }

        temproray_position = transform.position;
        temproray_position.x = player.position.x;

        if (temproray_position.x < minimum_x)
        {
            temproray_position.x = minimum_x;
        }

        if (temproray_position.x > maximum_x)
        {
            temproray_position.x = maximum_x;
        }

        transform.position = temproray_position;
    }
}