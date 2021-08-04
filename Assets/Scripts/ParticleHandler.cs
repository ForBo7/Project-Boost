using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem collisionFX = null;
    [SerializeField] ParticleSystem successFX = null;
    [SerializeField] ParticleSystem thrustFX = null;
    [SerializeField] ParticleSystem leftThrustFX = null;
    [SerializeField] ParticleSystem rightThrustFX = null;

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

    // Plays the thrust fx.
    public void PlayThrustFX()
    {
        thrustFX.Play();
    }

    // Plays the left thrust fx.
    public void PlayLeftThrustFX()
    {
        leftThrustFX.Play();
    }

    // Plays the right thrust fx.
    public void PlayRightThrustFX()
    {
        rightThrustFX.Play();
    }

    // Stops the thrust fx.
    public void StopThrustFX()
    {
        thrustFX.Stop();
    }

    // Stops the left thrust fx.
    public void StopLeftThrustFX()
    {
        leftThrustFX.Stop();
    }

    // Stops the right thrust fx.
    public void StopRightThrustFX()
    {
        rightThrustFX.Stop();
    }

    // Stops all thrust fx.
    public void StopAllThrustFX()
    {
        thrustFX.Stop();
        leftThrustFX.Stop();
        rightThrustFX.Stop();
    }
}
