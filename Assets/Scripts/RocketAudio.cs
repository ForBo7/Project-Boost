using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAudio : MonoBehaviour
{
    [SerializeField] AudioClip thrustSFX;
    [SerializeField] AudioClip collisionSFX;
    [SerializeField] AudioClip levelFinishSFX;

    AudioSource audioSource;

    Movement movement;
    CollisionHandler collisionHandler;

    // Start is called before the first frame update.
    private void Start()
    {
        InitializeComponents();
    }

    // Initialize the components required for the class.
    private void InitializeComponents()
    {
        audioSource = GetComponent<AudioSource>();
        movement = GetComponent<Movement>();
        collisionHandler = GetComponent<CollisionHandler>();
    }

    // Play the thrust sfx while the correct key is pressed.
    public void PlayThrustSFX(bool wPressed)
    {
        if (wPressed)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(thrustSFX);
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    // Stop audio.
    public void StopAudio()
    {
        audioSource.Stop();
    }

    // Play the collision sfx.
    public void PlayCollisionSFX()
    {
        audioSource.PlayOneShot(collisionSFX);
    }

    // Play the level finish sfx.
    public void PlayFinishSFX()
    {
        audioSource.PlayOneShot(levelFinishSFX);
    }
}
