using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour
{
    public static string state = "Normal";

    public static void StateManagement (string newState)
    {
        switch (newState)
        {
            case "StartScreen":

                break;
            case "Normal":

                break;
            case "Game Over":
                state = "Game Over";
                Debug.Log(ScoreManager.currentScore);
                Time.timeScale = 0;
                break;
        }
    }
}
