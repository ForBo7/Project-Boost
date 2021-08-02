using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles the collisions of the rocket and calls the appropriate methods.
public class CollisionHandler : MonoBehaviour
{
    SceneLoader sceneLoader = null;
    Movement movement = null;
    RocketAudio rocketAudio = null;

    bool hasCollided = false;
    bool hasFinished = false;

    // Start is called before the first frame update.
    private void Start()
    {
        InitializeComponents();
    }

    // Handles the collisions of the rocket.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            hasFinished = true;
            rocketAudio.PlayFinishSFX();
            movement.DisableMovement();
            movement.FreezePositionAndRotation();
            Invoke("LoadNextScene", sceneLoader.GetNextLevelDelay());
        }
        else if (collision.gameObject.CompareTag("Friendly"))
        {
            // Pass.
        }
        else
        {
            hasCollided = true;
            rocketAudio.PlayCollisionSFX();
            movement.DisableMovement();
            Invoke("ReloadScene", sceneLoader.GetNextLevelDelay());
        }
    }

    // Initialize the required components.
    private void InitializeComponents()
    {
        sceneLoader = GameObject.Find("Level Manager").GetComponent<SceneLoader>();
        movement = GetComponent<Movement>();
        rocketAudio = GetComponent<RocketAudio>();
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

    // Returns whether the rocket has collided.
    public bool GetHasCollided()
    {
        return hasCollided;
    }

    // Returns whether the rocket has reached the finish pad.
    public bool GetHasFinished()
    {
        return hasFinished;
    }
}
