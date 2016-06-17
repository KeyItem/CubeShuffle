using UnityEngine;
using System.Collections;

public class LineController : MonoBehaviour
{
    private RotateParticles particleController;
    private CubeSpawner cubeSpawner;
    private PlayerController playerController;
    private ScoreManager scoreManager;
    private UIManager uiManager;

    public float moveSpeed;
    public float rotateSpeed;

	void Awake ()
    {
        cubeSpawner = GameObject.FindGameObjectWithTag("LineSpawner").GetComponent<CubeSpawner>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        particleController = GameObject.FindGameObjectWithTag("ParticleController").GetComponent<RotateParticles>();
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        transform.localScale = new Vector3(PlayerController.aspectScale, transform.localScale.y, PlayerController.aspectScale);

        rotateSpeed = playerController.rotateSpeed;

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
        if (cubeSpawner.areLinesInverted == true)
        {
            transform.position += (new Vector3(0, moveSpeed, 0) * Time.deltaTime);
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.position += (new Vector3(0, -moveSpeed, 0) * Time.deltaTime);
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }

	}

    void OnTriggerStay (Collider other)
    {
        if (other.gameObject.tag != gameObject.tag && other.gameObject.tag != "Shredder")
        {
            if (cubeSpawner.areLinesInverted == true)
            {
                cubeSpawner.InvertSpawns();
                Debug.Log("Reset Lines back to original position");
            }
            StateManager.StateManagement("Game Over");
            uiManager.GameOver();
        }
        else if (other.gameObject.tag == gameObject.tag)
        {
            cubeSpawner.lineList.Remove(gameObject);
            playerController.rotateSpeed += 10;
            playerController.ChangeColor();
            particleController.ChangeColor();
            scoreManager.AddScore(1);
            Destroy(gameObject);
        }
    }
}
