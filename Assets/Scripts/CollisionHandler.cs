using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
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
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
