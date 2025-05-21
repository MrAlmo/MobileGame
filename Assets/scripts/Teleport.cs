using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;
    [SerializeField] private Button nextButton;
    [SerializeField] private TMP_Text text;
    [SerializeField] private CameraSwitch CameraSwitch;
    [SerializeField] private GameObject fadeCanvas;

    private GameObject player;



    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag(playerTag))
        {
            yesButton.GetComponentInChildren<TMP_Text>().text = "Yes";
            noButton.GetComponentInChildren<TMP_Text>().text = "No";
            yesButton.onClick.AddListener(OnYes);
            noButton.onClick.AddListener(OnNo);
            player = other.gameObject;
            ShowDialogue("Enter the room?");

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
        if (player != null && teleportTarget != null)
        {
            StartCoroutine(FadeTeleport(player, teleportTarget.position));
            //player.transform.position = teleportTarget.position;
            //CameraSwitch.SwitchToCabinetCamera();
        }
        HideDialogue();
    }

    private void OnNo()
    {
        HideDialogue();
    }
    private void ShowDialogue(string question)
    {
        text.text = question;
        dialoguePanel.SetActive(true);
        nextButton.gameObject.SetActive(false);
        yesButton.gameObject.SetActive(true);
        noButton.gameObject.SetActive(true);
    }

    private void HideDialogue()
    {
        dialoguePanel.SetActive(false);
    }

    private IEnumerator FadeTeleport(GameObject player, Vector3 position)
    {
        fadeCanvas.gameObject.SetActive(true);
        yield return FadeController.Instance.StartCoroutine("Fade", 1f);
        player.transform.position = position;
        CameraSwitch.SwitchToCabinetCamera();
        yield return FadeController.Instance.StartCoroutine("Fade", 0f);
        fadeCanvas.gameObject.SetActive(false);
    }
}

