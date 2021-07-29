using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles the collisions of the rocket and loads scenes.
public class CollisionHandler : MonoBehaviour
{
    // Time delay to load a level.
    [SerializeField] float nextLevelDelay = 0f;

    // Get the current scene's index.
    private int currentSceneIndex = 0;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Handles the collisions of the rocket.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            BeginLoadSequence();
        }
        else if (collision.gameObject.CompareTag("Friendly"))
        {
            Debug.Log("Collided with a friendly GameObject!");
        }
        else
        {
            BeginReloadSequence();
        }
    }

    // Get the current scene's index and reload the scene.
    private void LoadNextLevel()
    {
        int nextSceneIndex = currentSceneIndex + 1;
        // Loop back to first level if at last level.
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    // Disable rocket controls.
    private void DisableMovement()
    {
        GetComponent<Movement>().enabled = false;
    }

    // Get the current scene's index and reload the scene.
    private void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    // Perform the neccessary logic to reload a level.
    private void BeginReloadSequence()
    {
        DisableMovement();
        Invoke("ReloadScene", nextLevelDelay);
    }

    // Perform the neccessary logic to load a level.
    private void BeginLoadSequence()
    {
        DisableMovement();
        Invoke("LoadNextLevel", nextLevelDelay);
    }
}
