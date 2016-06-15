using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CubeSpawner : MonoBehaviour
{
    private PlayerController playerController;

    public Vector3[] spawnVectors;
    public Material[] colorArray;
    public List<GameObject> lineList;

    public GameObject Line;
    public GameObject LineHolder;

    public float initialLineTime;
    public float lineTime;

    private int previousNumber;

    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

	void Start ()
    {
        initialLineTime = lineTime;
	}
	
	void Update ()
    {
        InitializeLines();
	}

    public void InitializeLines()
    {
        if (StateManager.state == "Normal")
        {
            lineTime -= Time.deltaTime;

            if (lineTime < 0)
            {
                SpawnLines();
                lineTime = initialLineTime;
            }
        }
        else
        {
            Debug.Log("Cant spawn lines because state is incorrect, state is " + StateManager.state);
        }
    }

    public void SpawnLines()
    {
        int spawnRand = Random.Range(1, 6);

        if (previousNumber == spawnRand)
        {
            return;
        }

        switch (spawnRand)
        {
            case 1:
                GameObject line1 = Instantiate(Line as GameObject);
                line1.transform.SetParent(LineHolder.transform);
                line1.transform.position = spawnVectors[0];
                line1.name = "Line1";
                lineList.Add(line1);
                previousNumber = 1;
                break;
            case 2:
                GameObject line2 = Instantiate(Line as GameObject);
                line2.transform.SetParent(LineHolder.transform);
                line2.transform.position = spawnVectors[1];
                line2.name = "Line1";
                lineList.Add(line2);
                previousNumber = 2;
                break;
            case 3:
                GameObject line3 = Instantiate(Line as GameObject);
                line3.transform.SetParent(LineHolder.transform);
                line3.transform.position = spawnVectors[2];
                line3.name = "Line1";
                lineList.Add(line3);
                previousNumber = 3;
                break;
            case 4:
                GameObject line4 = Instantiate(Line as GameObject);
                line4.transform.SetParent(LineHolder.transform);
                line4.transform.position = spawnVectors[3];
                line4.name = "Line1";
                lineList.Add(line4);
                previousNumber = 4;
                break;
            case 5:
                GameObject line5 = Instantiate(Line as GameObject);
                line5.transform.SetParent(LineHolder.transform);
                line5.transform.position = spawnVectors[4];
                line5.name = "Line1";
                lineList.Add(line5);
                previousNumber = 5;
                break;
            default:
                Debug.Log("Something went wrong within the switch @ " + this);
                break;
        }

    }

    public void Reset()
    {
        for (int i = 0; i < lineList.Count; i++)
        {
            Destroy(lineList[i]);
        }

        playerController.ResetPlayer();
        
    }
}
