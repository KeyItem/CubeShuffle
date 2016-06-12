using UnityEngine;
using System.Collections;

public class DifficultyManager : MonoBehaviour
{
    private CubeSpawner cubeSpawner;

    public float increaseInterval = 30f;
    public float speedIncrease = 0.15f;

    private float resetIncreaseInterval;

    public bool isDifficultyAdjustEnabled;

    void Awake()
    {
        resetIncreaseInterval = increaseInterval;

        cubeSpawner = GameObject.FindGameObjectWithTag("LineSpawner").GetComponent<CubeSpawner>();
    }

    void Update()
    {
        if (isDifficultyAdjustEnabled)
        {
            DifficultyAdjuster();
        }
    }

    public void DifficultyAdjuster()
    {
        increaseInterval -= Time.deltaTime;

        if (increaseInterval < 0 && cubeSpawner.initialLineTime >= 0.40)
        {
            cubeSpawner.initialLineTime -= speedIncrease;
            increaseInterval = resetIncreaseInterval;
        }



    }

}
