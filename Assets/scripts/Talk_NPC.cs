using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk_NPC : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueSystem;
    [SerializeField] private DialogueData dialogueData;

    private bool hasTalked = false;
    private NPCDialogueState npcState;
    private void Awake()
    {
        npcState = GetComponent<NPCDialogueState>();
        if (npcState == null)
        {
            npcState = gameObject.AddComponent<NPCDialogueState>();
        }

        npcState.dialogueData = dialogueData;

        GameNpcManager.Instance.allNPCs.Add(npcState);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasTalked) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueSystem.StartDialogue(dialogueData, npcState);
            hasTalked = true;
            LevelManager.Instance.RegisterTalk();
        }
    }
}

