using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalEnding : MonoBehaviour
{
    [SerializeField] private Talk_NPC talkSys;
    [SerializeField] public DialogueManager dialogueManager;
    [SerializeField] public FadeController fadeCanvas;
    private bool hasCompleted = false;
    void Start()
    {
        talkSys = GetComponent<Talk_NPC>();
       
    }

    
    void Update()
    {
        if (!hasCompleted && talkSys.hasTalked && !dialogueManager.gameObject.activeSelf)
        {
            hasCompleted = true;
            StartCoroutine(FadeStartScene());
        }
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
