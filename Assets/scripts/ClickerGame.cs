using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickerGame : MonoBehaviour
{
    public GameObject gameUI;
    public Button clickButton;
    public TMP_Text scoreText;
    public TMP_Text timerText;

    private int score = 0;
    private float timeLeft = 10f;
    private bool gameActive = false;
    public bool Won = false;

    void Start()
    {
        gameUI.SetActive(false);
        clickButton.onClick.AddListener(OnClick);
    }

    public void StartGame()
    {
        if (!Won)
        {
            score = 0;
            timeLeft = 10f;
            gameActive = true;
            gameUI.SetActive(true);
            scoreText.text = "Score: 0";
            timerText.text = "Time: 10";
        }
    }

    void Update()
    {
        if (gameActive)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = $"Time: {Mathf.Ceil(timeLeft)}";

            if (timeLeft <= 0)
            {
                gameActive = false;
                if (score >= 50)
                {
                    Won = true;
                    timerText.text = "You Won!";
                }
                else
                timerText.text = "Time is out!";
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndGame();
        }
    }

    void OnClick()
    {
        if (gameActive)
        {
            score++;
            scoreText.text = $"Score: {score}";
        }
    }

    public void EndGame()
    {
        gameUI.SetActive(false);
    }
}
