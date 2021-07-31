using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles the collisions of the rocket and calls the appropriate methods.
public class CollisionHandler : MonoBehaviour
{
    SceneLoader sceneLoader = null;
    Movement movement = null;

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
            movement.DisableMovement();
            Invoke("ReloadScene", sceneLoader.GetNextLevelDelay());
        }
    }

    // Initialize the required components.
    private void InitializeComponents()
    {
        sceneLoader = GameObject.Find("Level Manager").GetComponent<SceneLoader>();
        movement = GetComponent<Movement>();
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
