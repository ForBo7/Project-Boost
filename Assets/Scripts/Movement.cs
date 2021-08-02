using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// A class to manage the movement of the rocket.
public class Movement : MonoBehaviour
{
    [SerializeField] float thrustFactor = 0;
    [SerializeField] float rotationFactor = 0;

    Rigidbody rb;
    Vector3 eulerAngleVelocity;

    RocketAudio rocketAudio;

    bool wPressed = false;
    bool aPressed = false;
    bool dPressed = false;

    // Start is called before the first frame update.
    private void Start()
    {
        InitializeComponents();
    }

    // Update is called once per frame.
    private void Update()
    {
        ProcessInput();
    }

    // FixedUpdate is called every 0.02 seconds or 50 times a second.
    private void FixedUpdate()
    {
        ThrustRocket();
        RotateRocket();
    }

    // Initialize the components required for the class.
    private void InitializeComponents()
    {
        rb = GetComponent<Rigidbody>();
        eulerAngleVelocity = new Vector3(0, 0, rotationFactor);
        rocketAudio = GetComponent<RocketAudio>();
    }

    // Identify which required keys have been pressed.
    private void ProcessInput()
    {
        wPressed = Input.GetKey(KeyCode.W);
        aPressed = Input.GetKey(KeyCode.A);
        dPressed = Input.GetKey(KeyCode.D);
    }

    // Thrust the rocket.
    void ThrustRocket()
    {
        rocketAudio.PlayThrustSFX(wPressed);
        if (wPressed)
        {
            rb.AddRelativeForce(Vector3.up * thrustFactor);
        }
    }

    // Rotate the rocket.
    private void RotateRocket()
    {
        // && used so cannot rotate in both directions at the same time.
        if (aPressed && !dPressed)
        {
            ApplyRotation(1);
        }
        if (dPressed && !aPressed)
        {
            ApplyRotation(-1);
        }
    }

    // Calculate and apply the required rotation. A rotationDirection of 1
    //  indicates anticlockwise. -1 indicates clockwise.
    private void ApplyRotation(int rotationDirection)
    {
        // Freezing rotation so we can manually rotate.
        rb.freezeRotation = true;

        Quaternion deltaRotation = Quaternion.Euler(eulerAngleVelocity *
                                                    rotationDirection);
        rb.MoveRotation(rb.rotation * deltaRotation);

        // Unfreezing rotation so physics system can act.
        rb.constraints = RigidbodyConstraints.FreezeRotationX |
                         RigidbodyConstraints.FreezeRotationY |
                         RigidbodyConstraints.FreezePositionZ;
    }

    // Returns whether w has been pressed.
    public bool GetWPressed()
    {
        return wPressed;
    }

    // Disable movement for this rocket by disabling the script.
    public void DisableMovement()
    {
        this.enabled = false;
    }

    // Freeze the position and rotation of the rocket.
    public void FreezePositionAndRotation()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
    }
}
