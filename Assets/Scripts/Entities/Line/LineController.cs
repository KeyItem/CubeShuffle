using UnityEngine;
using System.Collections;

public class LineController : MonoBehaviour
{
    private CubeSpawner cubeSpawner;
    private PlayerController playerController;
    private ScoreManager scoreManager;

    public float moveSpeed;
    public float rotateSpeed;

	void Awake ()
    {
        cubeSpawner = GameObject.FindGameObjectWithTag("LineSpawner").GetComponent<CubeSpawner>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();

        int randColor = Random.Range(1, 6);

        switch (randColor)
        {
            case 1:
                GetComponent<Renderer>().material = cubeSpawner.colorArray[0];
                tag = "Red";
                break;
            case 2:
                GetComponent<Renderer>().material = cubeSpawner.colorArray[1];
                tag = "Blue";
                break;
            case 3:
                GetComponent<Renderer>().material = cubeSpawner.colorArray[2];
                tag = "Yellow";
                break;
            case 4:
                GetComponent<Renderer>().material = cubeSpawner.colorArray[3];
                tag = "Green";
                break;
            case 5:
                GetComponent<Renderer>().material = cubeSpawner.colorArray[4];
                tag = "Purple";
                break;
            default:
                Debug.Log("Something went wrong within the switch @ " + this);
                break;
        }
	}
	
	void Update ()
    {
        transform.position += (new Vector3(0, -moveSpeed, 0) * Time.deltaTime);
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
	}

    void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag != gameObject.tag && other.gameObject.tag != "Shredder")
        {
            StateManager.StateManagement("Game Over");
        }
        else if (other.gameObject.tag == gameObject.tag)
        {
            playerController.ChangeColor();
            scoreManager.AddScore(1);
            Destroy(gameObject);
        }
    }
}
