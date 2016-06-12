using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public int totalDestroyed = 0;

    public static float currentScore = 0;

	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    public void AddScore (float scoreAddition)
    {
        currentScore += scoreAddition;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
