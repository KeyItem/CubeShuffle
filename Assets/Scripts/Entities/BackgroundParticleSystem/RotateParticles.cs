using UnityEngine;
using System.Collections;

public class RotateParticles : MonoBehaviour
{
    private GameObject Player;

    public float rotationSpeed;
	
    void Start()
    {
        Player = GameObject.Find("Player");

        ChangeColor();
    }

	void Update ()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
	}

    public void ChangeColor()
    {
        GetComponent<ParticleSystem>().startColor = Player.GetComponent<Renderer>().material.color;
    }
}
