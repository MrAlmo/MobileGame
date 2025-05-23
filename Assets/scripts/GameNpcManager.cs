using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameNpcManager : MonoBehaviour
{
    public static GameNpcManager Instance;
    public List<NPCDialogueState> allNPCs;

    public Transform finalZone; // место для спавна

    private void Awake()
    {
        Instance = this;
    }

    public void SpawnPositiveNPCs()
    {
        foreach (var npc in allNPCs)
        {
            if (npc.finalOutcome == DialogueOutcome.Positive)
            {
                npc.transform.position = GetRandomPositionInZone();
            }
            else
            {
                npc.gameObject.SetActive(false); // или удалить
            }
        }
    }

    private Vector3 GetRandomPositionInZone()
    {
        // Простой случай — около финальной зоны
        return finalZone.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), 0);
    }
}
