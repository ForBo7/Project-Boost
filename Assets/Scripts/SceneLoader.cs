using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float nextLevelDelay = 0f;

    private int currentSceneIndex = 0;

    // Start is called before the first frame update.
    private void Start()
    {
        // Get the index of the current scene.
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Reload the current scene.
    public void ReloadScene()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    // Load the next scene.
    public void LoadNextScene()
    {
        int nextSceneIndex = currentSceneIndex + 1;
        // Loop back to first level if at last level.
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

    // Returns the delay after which a scene loads or reloads.
    public float GetNextLevelDelay()
    {
        return nextLevelDelay;
    }
}
