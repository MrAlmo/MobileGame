using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Level2TP : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject fadeCanvas;



    private GameObject player;



    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag(playerTag) && LevelManager.Instance.nextLevel)
        {
            yesButton.GetComponentInChildren<TMP_Text>().text = "Yes";
            noButton.GetComponentInChildren<TMP_Text>().text = "No";
            yesButton.onClick.AddListener(OnYes);
            noButton.onClick.AddListener(OnNo);
            player = other.gameObject;
            ShowDialogue("Enter the Gym?");
        }
        else if (other.CompareTag(playerTag) && !LevelManager.Instance.nextLevel)
        {

            player = other.gameObject;
            ShowDialogue("Door is closed.");

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            HideDialogue();
            player = null;
            yesButton.onClick.RemoveAllListeners();
            noButton.onClick.RemoveAllListeners();
        }
    }


    private void OnYes()
    {
        if (player != null && LevelManager.Instance.nextLevel)
        {

            StartCoroutine(FadeNextScene());
            //LevelManager.Instance.GoToNextLevel();
        }
        HideDialogue();
    }

    private void OnNo()
    {
        HideDialogue();
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
        else
        {
            text.text = question;
            dialoguePanel.SetActive(true);
            nextButton.gameObject.SetActive(false);
            yesButton.gameObject.SetActive(false);
            noButton.gameObject.SetActive(false);
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



