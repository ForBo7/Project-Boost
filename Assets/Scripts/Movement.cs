using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// A class to manage the movement of the rocket.
public class Movement : MonoBehaviour
{
    [SerializeField] float thrustFactor;

    Rigidbody rb;

    bool wPressed = false;
    bool aPressed = false;
    bool dPressed = false;

    // Start is called before the first frame update.
    void Start()
    {
        InitializeComponents();
    }

    // Update is called once per frame.
    void Update()
    {
        ProcessInput();
    }

    // FixedUpdate is called every 0.02 seconds or 50 times a second.
    void FixedUpdate()
    {
        ThrustRocket();
        RotateRocket();
    }

    // Initialize the components required for the class.
    void InitializeComponents()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Identify which required keys have been pressed.
    void ProcessInput()
    {
        wPressed = Input.GetKey(KeyCode.W);
        aPressed = Input.GetKey(KeyCode.A);
        dPressed = Input.GetKey(KeyCode.D);
    }

    // Thrust the rocket.
    void ThrustRocket()
    {
        if (wPressed)
        {
            Debug.Log("pressed");
            rb.AddRelativeForce(Vector3.up * thrustFactor);
        }
    }

    // Rotate the rocket.
    void RotateRocket()
    {
        // && used so cannot rotate in both directions at the same time.
        if (aPressed && !dPressed)
        {
            Debug.Log("A pressed - Rotating left...");
        }
        if (dPressed && !aPressed)
        {
            Debug.Log("D pressed - Rotating right...");
        }
    }

}
