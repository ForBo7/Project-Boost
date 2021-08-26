using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Oscillates an object back and forth between two positions.
public class Oscillator : MonoBehaviour
{
    private enum Wave { Sine, Cosine };
    [SerializeField] private Vector3 finalPosition;
    [SerializeField] private float period = 0f;
    [SerializeField] private Wave wave = Wave.Sine;

    private const float tau = Mathf.PI * 2;
    private Vector3 startingPosition;
    private Vector3 movementThisFrame;
    private float movementFactor = 0;
    // The number of cycles that have lapsed since the scene has loaded.
    private float cycles = 0;
    private float sineWave = 0;
    private float cosineWave = 0;

    // Start is called before the first frame update
    private void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        if (wave == Wave.Sine)
        {
            CalculateSineMovementFactor();
        }
        else if (wave == Wave.Cosine)
        {
            CalculateCosineMovementFactor();
        }
        movementThisFrame = finalPosition * movementFactor;
        transform.position = startingPosition + movementThisFrame;
    }

    // Calculates the value for movementFactor with the use of a sine wave.
    private void CalculateSineMovementFactor()
    {
        if (period == Mathf.Epsilon) { return; }
        // Continuously grows.
        cycles = Time.time / period;
        // Gives a value between -1 and 1.
        sineWave = Mathf.Sin(cycles * tau);
        // Adjust the sineWave value so it goes between 0 and 1.
        movementFactor = (sineWave + 1f) / 2f;
    }

    // Calculates the value for movementFactor with the use of a cosine wave.
    private void CalculateCosineMovementFactor()
    {
        if (period == Mathf.Epsilon) { return; }
        // Continuously grows.
        cycles = Time.time / period;
        // Gives a value between -1 and 1.
        cosineWave = Mathf.Cos(cycles * tau);
        // Adjust the sineWave value so it goes between 0 and 1.
        movementFactor = (cosineWave + 1f) / 2f;
    }
}
