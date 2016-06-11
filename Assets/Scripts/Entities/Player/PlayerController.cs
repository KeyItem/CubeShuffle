using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public string state = "Normal";

    public float moveDistance = 10f;
    public float screenPadding = 0.5f;

    private float xMin;
    private float xMax;

    void Awake ()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMostSide = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMostSide = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xMin = leftMostSide.x + screenPadding;
        xMax = rightMostSide.x - screenPadding;
    }
	
	void Update ()
    {
	
	}

    public void Move(string direction)
    {
        if (state == "Normal")
        {
            if (direction == "Right")
            {
                transform.position += (new Vector3(moveDistance, 0, 0));

                float newX = Mathf.Clamp(transform.position.x, xMin, xMax);

                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
            if (direction == "Left")
            {
                transform.position += (new Vector3(-moveDistance, 0, 0));

                float newX = Mathf.Clamp(transform.position.x, xMin, xMax);

                transform.position = new Vector3(newX, transform.position.y, transform.position.z);
            }
        }
    }
}
