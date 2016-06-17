﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreGrabber : MonoBehaviour
{
    private Text scoreText;

    void OnEnable()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = ScoreManager.currentScore.ToString();
    }

}
