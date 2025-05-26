using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueState : MonoBehaviour
{
    public GameObject npcPrefab;

    public DialogueData dialogueData;
    public bool interactionFinished = false;
    public DialogueOutcome finalOutcome = DialogueOutcome.None;

    private int affinity = 0;

    public void AdjustAffinity(int change)
    {
        affinity += change;
    }

    public void FinishDialogue()
    {
        interactionFinished = true;
        finalOutcome = affinity >= 0 ? DialogueOutcome.Positive : DialogueOutcome.Negative;

        if (finalOutcome == DialogueOutcome.Positive && npcPrefab != null)
        {
            GameNpcManager.Instance.RegisterPositiveNPC(npcPrefab);
        }
    }
}
