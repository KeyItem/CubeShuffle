using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    private CubeSpawner lineSpawner;
    private MusicManager musicManager;
    private ScoreManager scoreManager;
    private DifficultyManager difficultyManager;
    private PlayerController playerController;

    public GameObject StartUI;
    public GameObject GameOverUI;
    public GameObject OptionsUI;
    public GameObject HighScoreUI;
    public GameObject HowToPlayUI;

    void Awake()
    {
        lineSpawner = GameObject.FindGameObjectWithTag("LineSpawner").GetComponent<CubeSpawner>();
        musicManager = GameObject.FindGameObjectWithTag("MusicManager").GetComponent<MusicManager>();
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        difficultyManager = GameObject.FindGameObjectWithTag("DifficultyManager").GetComponent<DifficultyManager>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void StartGame ()
    {
        StateManager.StateManagement("Normal");
        StartUI.SetActive(false);
        GameOverUI.SetActive(false);
        HighScoreUI.SetActive(false);
        ScoreManager.ResetScore();
        musicManager.ResumeVolume();
        lineSpawner.initialLineTime = 1;
        playerController.rotateSpeed = playerController.initialRotateSpeed;
        difficultyManager.inverseTimer = difficultyManager.initialInverseTimer;
        lineSpawner.Reset();
        lineSpawner.lineList.Clear();
    }

    public void MainMenu()
    {
        lineSpawner.Reset();
        StateManager.StateManagement("Main Menu");
        GameOverUI.SetActive(false);
        HighScoreUI.SetActive(false);
        HowToPlayUI.SetActive(false);
        StartUI.SetActive(true);
        OptionsUI.SetActive(false);
        ScoreManager.ResetScore();
        musicManager.ResumeVolume();
    }

    public void GameOver()
    {
        StateManager.StateManagement("Game Over");
        if (scoreManager.CheckForHighScore() == true)
        {
            HighScoreUI.SetActive(true);
        }
        else
        {
            GameOverUI.SetActive(true);
        }
        musicManager.ReduceVolume();
    }

    public void Options()
    {
        StartUI.SetActive(false);
        OptionsUI.SetActive(true);
    }

    public void HowToPlay()
    {
        StartUI.SetActive(false);
        HowToPlayUI.SetActive(true);
    }
}
