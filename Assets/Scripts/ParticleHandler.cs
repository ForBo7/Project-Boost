using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionFX = null;
    [SerializeField] ParticleSystem successFX = null;

    // Plays the collision fx.
    public void PlayCollisionFX()
    {
        collisionFX.Play();
    }

    // Plays the success fx.
    public void PlaySuccessFX()
    {
        successFX.Play();
    }

}
