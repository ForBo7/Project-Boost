using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for the movement of the rocket.
/// </summary>
public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    /// <summary>
    /// Do the appropriate action upon input.
    /// </summary>
    void ProcessInput()
    {
        ProcessThrustInput();
        ProcessRotationInput();
    }

    /// <summary>
    /// Check for thrust input. If so, run the thrust code.
    /// </summary>
    void ProcessThrustInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("W pressed - Thrusting...");
        }
    }

    /// <summary>
    /// Check for rotation input. If so, run the rotation code.
    /// </summary>
    void ProcessRotationInput()
    {
        // && used so cannot rotate in both directions at the same time.
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            Debug.Log("A pressed - Rotating left...");
        }
        if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            Debug.Log("D pressed - Rotating right...");
        }
    }

}
