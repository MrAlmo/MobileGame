using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacManager : MonoBehaviour
{
    public TicTacToe ticTacToe;
    public Talk_NPC npc;
    [SerializeField] private GameObject dialoguepanel;

    private void OnCollisionEnter2D(Collision2D collision)    
    {
        if (npc.hasTalked && !dialoguepanel.gameObject.activeSelf && !ticTacToe.gameObject.activeSelf && collision.gameObject.CompareTag("Player"))
        {
            ticTacToe.StartGame();
            
        }
    }
}
