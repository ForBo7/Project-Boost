using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Handles the collisions of the rocket.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Collided with the finish pad!");
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
    private static void ReloadScene()
    {
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentSceneIndex);
    }
}
