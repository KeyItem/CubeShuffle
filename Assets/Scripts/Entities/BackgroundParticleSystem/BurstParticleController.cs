using UnityEngine;
using System.Collections;

public class BurstParticleController : MonoBehaviour
{
    public int particleAmount;

    public GameObject Player;

    void Awake()
    {
        Player = GameObject.Find("Player");
    }

    public void ChangeColor()
    {
        GetComponent<ParticleSystem>().startColor = Player.GetComponent<Renderer>().material.color;
    }

    public void BurstParticles()
    {
        ChangeColor();
        GetComponent<ParticleSystem>().Emit(particleAmount);
    }

}
