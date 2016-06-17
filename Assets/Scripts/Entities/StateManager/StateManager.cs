using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour
{
    public static string state = "Main Menu";

    public static void StateManagement (string newState)
    {
        switch (newState)
        {
            case "Main Menu":
                state = "Main Menu";
                Time.timeScale = 0;
                break;
            case "Normal":
                state = "Normal";
                Time.timeScale = 1;
                break;
            case "Paused":
                state = "Paused";
                Time.timeScale = 0;
                break;
            case "Game Over":
                state = "Game Over";
                Time.timeScale = 0;
                break;
        }
    }
}
