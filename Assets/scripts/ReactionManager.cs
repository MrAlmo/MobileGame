using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionManager : MonoBehaviour
{
    public ReactionGame react;
    public Talk_NPC npc;
    [SerializeField] private GameObject dialoguepanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (npc.hasTalked && !dialoguepanel.gameObject.activeSelf && !react.gameObject.activeSelf && collision.gameObject.CompareTag("Player"))
        {
            react.StartGame();

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            react.EndGame();
        }
    }
}
