using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private CubeSpawner cubeSpawner;

    public float moveDistance = 10f;
    public float rotateSpeed = 100f;    
    public float screenPadding = 0.5f;

    private float xMin;
    private float xMax;

    private int previousColor;

    void Awake ()
    {
        cubeSpawner = GameObject.FindGameObjectWithTag("LineSpawner").GetComponent<CubeSpawner>();

        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMostSide = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMostSide = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));

        xMin = leftMostSide.x + screenPadding;
        xMax = rightMostSide.x - screenPadding;

        ChangeColor();
    }
	
	void Update ()
    {
        RotatePlayer();
	}

    public void RotatePlayer()
    {
        if (StateManager.state == "Normal")
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
        }
    }

    public void Move(string direction)
    {
        if (StateManager.state == "Normal")
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

    public void ChangeColor()
    {
        int randColor = Random.Range(1, 6);

        if (previousColor == randColor)
        {
            ChangeColor();
        }

        switch (randColor)
        {
            case 1:
                GetComponent<Renderer>().material = cubeSpawner.colorArray[0];
                tag = "Red";
                previousColor = 1;
                break;
            case 2:
                GetComponent<Renderer>().material = cubeSpawner.colorArray[1];
                tag = "Blue";
                previousColor = 2;
                break;
            case 3:
                GetComponent<Renderer>().material = cubeSpawner.colorArray[2];
                tag = "Yellow";
                previousColor = 3;
                break;
            case 4:
                GetComponent<Renderer>().material = cubeSpawner.colorArray[3];
                tag = "Green";
                previousColor = 4;
                break;
            case 5:
                GetComponent<Renderer>().material = cubeSpawner.colorArray[4];
                tag = "Purple";
                previousColor = 5;
                break;
            default:
                Debug.Log("Something went wrong within the switch @ " + this);
                break;
        }
    }

}
