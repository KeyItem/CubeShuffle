using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shredder : MonoBehaviour
{
    public List<GameObject> lineList;

    void Awake()
    {
        lineList = GameObject.FindGameObjectWithTag("LineSpawner").GetComponent<CubeSpawner>().lineList;
    }

    void OnTriggerEnter (Collider other)
    {
        lineList.Remove(other.gameObject);
        Destroy(other.gameObject);
    }

}
