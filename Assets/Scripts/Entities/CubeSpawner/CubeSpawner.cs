﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CubeSpawner : MonoBehaviour
{
    public Vector3[] spawnVectors;
    public Material[] colorArray;

    public GameObject Line;
    public GameObject LineHolder;

    public float startTime;
    public float repeatRate;

	void Start ()
    {
        InvokeRepeating("SpawnCube", startTime, repeatRate);
	}
	
	void Update ()
    {
	
	}

    public void SpawnCube()
    {
        int spawnRand = Random.Range(1, 5);
        Debug.Log(spawnRand);

        switch (spawnRand)
        {
            case 1:
                GameObject line1 = Instantiate(Line as GameObject);
                line1.transform.SetParent(LineHolder.transform);
                line1.transform.position = spawnVectors[0];
                line1.name = "Line1";
                break;
            case 2:
                GameObject line2 = Instantiate(Line as GameObject);
                line2.transform.SetParent(LineHolder.transform);
                line2.transform.position = spawnVectors[1];
                line2.name = "Line1";
                break;
            case 3:
                GameObject line3 = Instantiate(Line as GameObject);
                line3.transform.SetParent(LineHolder.transform);
                line3.transform.position = spawnVectors[2];
                line3.name = "Line1";
                break;
            case 4:
                GameObject line4 = Instantiate(Line as GameObject);
                line4.transform.SetParent(LineHolder.transform);
                line4.transform.position = spawnVectors[3];
                line4.name = "Line1";
                break;
            case 5:
                GameObject line5 = Instantiate(Line as GameObject);
                line5.transform.SetParent(LineHolder.transform);
                line5.transform.position = spawnVectors[4];
                line5.name = "Line1";
                break;
        }

    }
}
