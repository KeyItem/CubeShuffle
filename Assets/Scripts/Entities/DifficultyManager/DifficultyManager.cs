using UnityEngine;
using System.Collections;

public class DifficultyManager : MonoBehaviour
{
    private CubeSpawner cubeSpawner;

    public float increaseInterval = 30f;
    public float speedIncrease = 0.15f;
    public float inverseTimer = 30f;
    public float initialInverseTimer;

    private float resetIncreaseInterval;

    public bool isDifficultyAdjustEnabled;

    void Awake()
    {
        resetIncreaseInterval = increaseInterval;
        initialInverseTimer = inverseTimer;

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
        if (StateManager.state == "Normal")
        {
            increaseInterval -= Time.deltaTime;
            inverseTimer -= Time.deltaTime;

            if (increaseInterval < 0 && cubeSpawner.initialLineTime >= 0.40)
            {
                cubeSpawner.initialLineTime -= speedIncrease;
                increaseInterval = resetIncreaseInterval;
            }

            if (inverseTimer < 0)
            {
                cubeSpawner.canSpawnLines = false;

                if (cubeSpawner.lineList.Count == 0)
                {
                    cubeSpawner.InvertSpawns();
                    cubeSpawner.canSpawnLines = true;
                    inverseTimer = initialInverseTimer;
                }
            }

        }
    }
}
