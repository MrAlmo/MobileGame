using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk_NPC : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueSystem;
    [SerializeField] private DialogueData dialogueData;

    private bool hasTalked = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasTalked) return;

        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueSystem.StartDialogue(dialogueData);
            hasTalked = true;
        }
    }
}

