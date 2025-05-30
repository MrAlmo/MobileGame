using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level3TP : MonoBehaviour
{
    [SerializeField] private TicTacToe TicTacToe;
    [SerializeField] private ReactionGame React;
    [SerializeField] private ClickerGame ClickerGame;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject fadeCanvas;



    private GameObject player;
    private bool hasCompleted = false;


    private void Update()
    {

        if (!hasCompleted &&
        TicTacToe.Won &&
        React.Won &&
        ClickerGame.Won &&
        !TicTacToe.gameObject.activeSelf &&
        !React.gameObject.activeSelf &&
        !ClickerGame.gameObject.activeSelf)
        {
            hasCompleted = true; 

            if (LevelManager.Instance.nextLevel)
            {
                yesButton.GetComponentInChildren<TMP_Text>().text = "Yes";
                noButton.GetComponentInChildren<TMP_Text>().text = "Let's go";
                yesButton.onClick.AddListener(OnYes);
                noButton.onClick.AddListener(OnNo);
                ShowDialogue("Now you can enter the roof.");
            }
        }
    }


    private void OnYes()
    {
        if (LevelManager.Instance.nextLevel)
        {
            StartCoroutine(FadeNextScene());
            //LevelManager.Instance.GoToNextLevel();
        }
        HideDialogue();
    }

    private void OnNo()
    {
        OnYes();
    }
    private void ShowDialogue(string question)
    {
        if (LevelManager.Instance.nextLevel)
        {
            text.text = question;
            dialoguePanel.SetActive(true);
            nextButton.gameObject.SetActive(false);
            yesButton.gameObject.SetActive(true);
            noButton.gameObject.SetActive(true);
        }
        
    }

    private void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }

    private IEnumerator FadeNextScene()
    {
        fadeCanvas.gameObject.SetActive(true);
        yield return FadeController.Instance.StartCoroutine("Fade", 1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return FadeController.Instance.StartCoroutine("Fade", 0f);
        fadeCanvas.gameObject.SetActive(false);
    }
}


    //void Update()
    //{
    //    if (TicTacToe.Won && React.Won && ClickerGame.Won && !TicTacToe.gameObject.activeSelf && !React.gameObject.activeSelf && !ClickerGame.gameObject.activeSelf)
    //    {

    //    }
    //}



