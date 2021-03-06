using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles the collisions of the rocket and calls the appropriate methods.
public class CollisionHandler : MonoBehaviour
{
    private SceneLoader sceneLoader = null;
    private Movement movement = null;
    private RocketAudio rocketAudio = null;
    private ParticleHandler particleHandler = null;

    private bool transitioning = false;
    private bool collisionsEnabled = true;

    // Toggles collisionsEnabled.
    public void ToggleCollisionsEnabled()
    {
        collisionsEnabled = !collisionsEnabled;
    }

    // Start is called before the first frame update.
    private void Start()
    {
        InitializeComponents();
    }

    // Handles the collisions of the rocket.
    private void OnCollisionEnter(Collision collision)
    {
        if (transitioning || !collisionsEnabled)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            ExecuteFinishSequence();
        }
        else if (collision.gameObject.CompareTag("Friendly"))
        {
            // Pass.
        }
        else
        {
            ExecuteCollisionSequence();
        }
    }

    // Initialize the required components.
    private void InitializeComponents()
    {
        sceneLoader = GameObject.Find("Level Manager").GetComponent<SceneLoader>();
        movement = GetComponent<Movement>();
        rocketAudio = GetComponent<RocketAudio>();
        particleHandler = GetComponent<ParticleHandler>();
    }

    // The sequence of steps to execute upon collision.
    private void ExecuteCollisionSequence()
    {
        // Stop the thrust sfx.
        rocketAudio.StopAudio();
        particleHandler.StopAllThrustFX();
        particleHandler.PlayCollisionFX();
        rocketAudio.PlayCollisionSFX();
        movement.DisableMovement();
        transitioning = true;
        Invoke("ReloadScene", sceneLoader.GetNextLevelDelay());
    }

    // The sequence of steps to execute upon finishing.
    private void ExecuteFinishSequence()
    {
        // Stop the thrust sfx.
        rocketAudio.StopAudio();
        particleHandler.StopAllThrustFX();
        particleHandler.PlaySuccessFX();
        rocketAudio.PlayFinishSFX();
        movement.DisableMovement();
        movement.FreezePositionAndRotation();
        transitioning = true;
        Invoke("LoadNextScene", sceneLoader.GetNextLevelDelay());
    }


    // Call the method that loads the next scene.
    private void LoadNextScene()
    {
        sceneLoader.LoadNextScene();
    }

    // Class the method the reloads the current scene.
    private void ReloadScene()
    {
        sceneLoader.ReloadScene();
    }
}
