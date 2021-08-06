using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cheat keys to help in development. Not for actual playable builds.
public class CheatKeys : MonoBehaviour
{
    private SceneLoader sceneLoader = null;
    private CollisionHandler collisionHandler = null;

    private bool lPressed = false;
    private bool cPressed = false;

    // Start is called before the first frame update
    private void Start()
    {
        InitializeComponents();
    }

    // Update is called once per frame.
    private void Update()
    {
        if (Debug.isDebugBuild)
        {
            GetInput();

            if (lPressed)
            {
                Debug.Log("Loading next scene...");
                sceneLoader.LoadNextScene();
            }

            if (cPressed)
            {
                Debug.Log("Collisions toggled.");
                collisionHandler.ToggleCollisionsEnabled();
            }
        }
    }

    // Initializes the required components.
    private void InitializeComponents()
    {
        sceneLoader = GetComponent<SceneLoader>();
        collisionHandler = GameObject.Find("Rocket").GetComponent<CollisionHandler>();
    }

    // Record which keys have been pressed.
    private void GetInput()
    {
        lPressed = Input.GetKey(KeyCode.L);
        cPressed = Input.GetKey(KeyCode.C);
    }
}
