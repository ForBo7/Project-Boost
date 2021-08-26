using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Oscillates an object back and forth between two positions.
public class Oscillator : MonoBehaviour
{
    enum Wave { Sine, Cosine };
    [SerializeField] Vector3 finalPosition;
    [SerializeField] float period = 0;
    [SerializeField] Wave wave = Wave.Sine;

    const float tau = Mathf.PI * 2;
    Vector3 startingPosition;
    Vector3 movementThisFrame;
    float movementFactor = 0;
    // The number of cycles that have lapsed since the scene has loaded.
    float cycles = 0;
    float sineWave = 0;
    float cosineWave = 0;

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
        // Continuously grows.
        cycles = Time.time / period;
        // Gives a value between -1 and 1.
        sineWave = Mathf.Sin(cycles * tau);
        // Adjust the sineWave value so it goes between 0 and 1.
        movementFactor = (sineWave + 1) / 2;
    }

    // Calculates the value for movementFactor with the use of a cosine wave.
    private void CalculateCosineMovementFactor()
    {
        // Continuously grows.
        cycles = Time.time / period;
        // Gives a value between -1 and 1.
        cosineWave = Mathf.Cos(cycles * tau);
        // Adjust the sineWave value so it goes between 0 and 1.
        movementFactor = (cosineWave + 1) / 2;
    }
}
