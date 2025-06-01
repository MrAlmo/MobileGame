using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TMP_Text npcText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Button[] optionButtons;
    [SerializeField] public Button nextButton;

    private DialogueData currentDialogue;
    private int currentLineIndex;
    public bool IsActive = false;
    private NPCDialogueState npcState;

    public void StartDialogue(DialogueData data, NPCDialogueState npc)
    {
        IsActive = true;
        currentDialogue = data;
        npcState = npc;
        currentLineIndex = 0;
        dialoguePanel.SetActive(true);
        nextButton.gameObject.SetActive(false);
        ShowLine();
    }

    private void ShowLine()
    {
        DialogueLine line = currentDialogue.lines[currentLineIndex];
        npcText.text = line.npcText;

        bool hasOptions = line.options != null && line.options.Length > 0;

        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (i < line.options.Length)
            {
                optionButtons[i].gameObject.SetActive(true);
                optionButtons[i].GetComponentInChildren<TMP_Text>().text = line.options[i].playerResponse;

                int nextIndex = line.options[i].nextLineIndex;
                int affinityChange = line.options[i].affinityChange;
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => OnOptionSelected(nextIndex, affinityChange));
            }
            else
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
        
        nextButton.gameObject.SetActive(!hasOptions);
        nextButton.onClick.RemoveAllListeners();

        if (!hasOptions)
        {
            nextButton.onClick.AddListener(() => OnOptionSelected(currentLineIndex + 1, 0));
        }
    }



    private void OnOptionSelected(int nextIndex, int affinityChange)
    {
        npcState.AdjustAffinity(affinityChange);

        if (nextIndex >= 0 && nextIndex < currentDialogue.lines.Length)
        {
            currentLineIndex = nextIndex;
            ShowLine();
        }
        else
        {
            npcState.FinishDialogue();
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
        dialoguePanel.SetActive(false);
    }
}