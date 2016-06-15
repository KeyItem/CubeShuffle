using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public int totalDestroyed = 0;

    public static float currentScore = 0;

    public void AddScore (float scoreAddition)
    {
        currentScore += scoreAddition;
    }

    public static void ResetScore()
    {
        currentScore = 0;
    }
}
