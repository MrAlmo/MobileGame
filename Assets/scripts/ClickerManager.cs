using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerManager : MonoBehaviour
{
    public ClickerGame click;
    public Talk_NPC npc;
    [SerializeField] private GameObject dialoguepanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (npc.hasTalked && !dialoguepanel.gameObject.activeSelf && !click.gameObject.activeSelf && collision.gameObject.CompareTag("Player"))
        {
            click.StartGame();

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            click.EndGame();
        }
    }
}
