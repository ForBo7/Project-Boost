using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAudio : MonoBehaviour
{
    AudioSource audioSource;

    bool wPressed = false;

    // Start is called before the first frame update.
    private void Start()
    {
        InitializeComponents();
    }

    // Update is called once per frame.
    private void Update()
    {
        GetInput();
        PlayThrustSFX();
    }

    // Initialize the components required for the class.
    private void InitializeComponents()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Identify which required keys have been pressed.
    private void GetInput()
    {
        wPressed = Input.GetKey(KeyCode.W);
    }

    // Play the thrust sfx while the correct key is pressed.
    private void PlayThrustSFX()
    {
        if (wPressed)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }
}
