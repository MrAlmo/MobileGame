using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Talk : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText; 
    [SerializeField] private GameObject dialoguePanel; 
    [SerializeField] private Button nextButton; 

    private string[] dialogueLines; 
    private int currentLine = 0;
    public bool IsActive = false;

    public void StartDialogue(string[] lines)
    {
        dialogueLines = lines;
        currentLine = 0;
        dialoguePanel.SetActive(true);
        IsActive = true;
        ShowNextLine();
    }

    public void ShowNextLine()
    {
        if (currentLine < dialogueLines.Length)
        {
            dialogueText.text = dialogueLines[currentLine]; 
            currentLine++;
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        IsActive = false;
    }

    private void Start()
    {
        nextButton.onClick.AddListener(ShowNextLine);
        dialoguePanel.SetActive(false); 
    }
}

