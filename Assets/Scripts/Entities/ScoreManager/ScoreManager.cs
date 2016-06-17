using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public int totalDestroyed = 0;

    public int highScore;

    public static int currentScore = 0;

    void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        Debug.Log(PlayerPrefs.GetInt("HighScore"));
    }

    public bool CheckForHighScore()
    {
        if (highScore < currentScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            return true;
        }
        else
        {
            Debug.Log(PlayerPrefs.GetInt("HighScore"));
            return false;
        }
    }

    public void AddScore (int scoreAddition)
    {
        currentScore += scoreAddition;
    }

    public static void ResetScore()
    {
        currentScore = 0;
    }

    public void EraseHighScores()
    {
        Debug.Log("Erased All HighScores!");
        PlayerPrefs.DeleteAll();
    }
}
