using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles the collisions of the rocket and loads scenes.
public class CollisionHandler : MonoBehaviour
{
    SceneLoader sceneLoader = null;
    Movement movement = null;

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

    private void InitializeComponents()
    {
        sceneLoader = GameObject.Find("Level Manager").GetComponent<SceneLoader>();
        movement = GetComponent<Movement>();
    }

    private void LoadNextScene()
    {
        sceneLoader.LoadNextScene();
    }

    private void ReloadScene()
    {
        sceneLoader.ReloadScene();
    }
}
