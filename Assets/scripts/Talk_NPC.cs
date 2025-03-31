using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk_NPC : MonoBehaviour
{
    [SerializeField] private Talk dialogueSystem;

    private string[] npcLines =
    {
        "Hello",
        "What do you want?",
        "Test ????"
    };

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with npc 1");
        if (collision.gameObject.CompareTag("Player"))
        {
            dialogueSystem.StartDialogue(npcLines);
        }
    }

}

