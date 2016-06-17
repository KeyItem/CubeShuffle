using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    private CubeSpawner lineSpawner;
    private MusicManager musicManager;

    public GameObject StartUI;
    public GameObject GameOverUI;
    public GameObject OptionsUI;

    void Awake()
    {
        lineSpawner = GameObject.FindGameObjectWithTag("LineSpawner").GetComponent<CubeSpawner>();
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();

    }

    public void StartGame ()
    {
        lineSpawner.Reset();
        StateManager.StateManagement("Normal");
        StartUI.SetActive(false);
        GameOverUI.SetActive(false);
        ScoreManager.ResetScore();
        musicManager.ResumeVolume();
        lineSpawner.initialLineTime = 1;
    }

    public void MainMenu()
    {
        lineSpawner.Reset();
        StateManager.StateManagement("Main Menu");
        GameOverUI.SetActive(false);
        StartUI.SetActive(true);
        OptionsUI.SetActive(false);
        ScoreManager.ResetScore();
        musicManager.ResumeVolume();
    }

    public void GameOver()
    {
        StateManager.StateManagement("Game Over");
        GameOverUI.SetActive(true);
        musicManager.ReduceVolume();
    }

    public void Options()
    {
        StartUI.SetActive(false);
        OptionsUI.SetActive(true);
    }
}
