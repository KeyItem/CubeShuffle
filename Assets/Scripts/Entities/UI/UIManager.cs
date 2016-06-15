using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    private CubeSpawner lineSpawner;

    public GameObject StartUI;
    public GameObject GameOverUI;

    void Awake()
    {
        lineSpawner = GameObject.FindGameObjectWithTag("LineSpawner").GetComponent<CubeSpawner>();
    }

    public void StartGame ()
    {
        lineSpawner.Reset();
        StateManager.StateManagement("Normal");
        StartUI.SetActive(false);
        GameOverUI.SetActive(false);
    }

    public void PauseGame()
    {
        StateManager.StateManagement("Paused");
    }

    public void MainMenu()
    {
        lineSpawner.Reset();
        StateManager.StateManagement("Main Menu");
        GameOverUI.SetActive(false);
        StartUI.SetActive(true);
        ScoreManager.ResetScore();
    }

    public void GameOver()
    {
        StateManager.StateManagement("Game Over");
        GameOverUI.SetActive(true);
    }
}
