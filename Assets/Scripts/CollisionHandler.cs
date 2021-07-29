using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Handles the collisions of the rocket and loads scenes.
public class CollisionHandler : MonoBehaviour
{
    // Get the current scene's index.
    private int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Handles the collisions of the rocket.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            LoadNextLevel();
        }
        else if (collision.gameObject.CompareTag("Friendly"))
        {
            Debug.Log("Collided with a friendly GameObject!");
        }
        else
        {
            ReloadScene();
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

    // Get the current scene's index and reload the scene.
    private void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }
}
