using UnityEngine;
using System.Collections;

public class LineController : MonoBehaviour
{
    public float moveSpeed;

	void Awake ()
    {
        int randColor = Random.Range(1, 5);
	}
	
	void Update ()
    {
        transform.position += (new Vector3(0, -moveSpeed, 0) * Time.deltaTime);
	}
}
