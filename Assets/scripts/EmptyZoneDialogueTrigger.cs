using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmptyZoneDialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private DialogueData noPositiveNpcDialogue;
    [SerializeField] private GameObject fadeCanvas;
    private bool dialogueShown = false;
    private NPCDialogueState npcState;
    private bool hasCompleted = false;

    private void Awake()
    {
        npcState = GetComponent<NPCDialogueState>();
        if (npcState == null)
        {
            npcState = gameObject.AddComponent<NPCDialogueState>();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (dialogueShown) return;

        if (other.CompareTag("Player"))
        {
            if (GameNpcManager.Instance.positiveNpcPrefabs.Count == 0)
            {
                dialogueManager.StartDialogue(noPositiveNpcDialogue, npcState);
                dialogueManager.nextButton.gameObject.SetActive(false);
                StartCoroutine(time());
         
                dialogueShown = true;
            }
        }
    }

    private void Update()
    {
        if (dialogueShown && !dialogueManager.gameObject.activeSelf && !hasCompleted)
        {
            hasCompleted = true;
            StartCoroutine(FadeStartScene());
        }
    }

    IEnumerator time()
    {
        yield return new WaitForSeconds(2.5f);
        dialogueManager.EndDialogue();
    }

    private IEnumerator FadeStartScene()
    {
        fadeCanvas.gameObject.SetActive(true);
        yield return FadeController.Instance.StartCoroutine("Fade", 1f);
        SceneManager.LoadScene(0);
        yield return FadeController.Instance.StartCoroutine("Fade", 0f);
        fadeCanvas.gameObject.SetActive(false);
    }
}
