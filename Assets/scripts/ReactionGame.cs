using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReactionGame : MonoBehaviour
{
    public GameObject gameUI;
    public Button clickButton;
    public TMP_Text statusText;

    private bool waitingForClick = false;
    private float signalTime;
    public bool Won = false;

    void Start()
    {
        gameUI.SetActive(false);
        clickButton.onClick.AddListener(OnButtonClick);
    }

    public void StartGame()
    {
        if (!Won)
        {
            gameUI.SetActive(true);
            statusText.text = "Wait...";
            StartCoroutine(WaitAndSignal());
        }
    }

    IEnumerator WaitAndSignal()
    {
        float delay = Random.Range(1f, 3f);
        yield return new WaitForSeconds(delay);
        signalTime = Time.time;
        waitingForClick = true;
        statusText.text = "PRESS!";
    }

    void OnButtonClick()
    {
        if (waitingForClick)
        {
            float reactionTime = Time.time - signalTime;
            if (reactionTime <= 0.45f)
            {
                Won = true;
                statusText.text = $"Reaction: {reactionTime:F3} sec\n You won!";
            }
            else
            statusText.text = $"Reaction: {reactionTime:F3} sec";
            
            waitingForClick = false;
            
        }
        else
        {
            statusText.text = "Very fast!";
        }
    }

    public void ResetGame()
    {
        StopAllCoroutines();
        waitingForClick = false;
        statusText.text = "Wait...";
        StartCoroutine(WaitAndSignal());
    }

    public void EndGame()
    {
        gameUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndGame();
        }
    }
}

