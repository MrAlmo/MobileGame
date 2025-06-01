using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] public DialogueManager dialogueManager;
    [SerializeField] private DialogueData dialogueIfAlone;
    [SerializeField] private DialogueData dialogueIfMany;
    [SerializeField] public FadeController fadeCanvas;

    private void Start()
    {
        SpawnPositiveNPCs();
    }

    private void SpawnPositiveNPCs()
    {
        var list = GameNpcManager.Instance.positiveNpcPrefabs;
        int spawnCount = Mathf.Min(list.Count, spawnPoints.Length);

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject npc = Instantiate(list[i], spawnPoints[i].position, Quaternion.identity);

            Talk_NPC talkScript = npc.AddComponent<Talk_NPC>();
            talkScript.hasTalked = false;
            

            NPCDialogueState npcState = npc.GetComponent<NPCDialogueState>();
            if (npcState == null)
            {
                npcState = npc.AddComponent<NPCDialogueState>();
            }
            

            talkScript.dialogueSystem = dialogueManager;

            
            DialogueData chosenDialogue = (list.Count == 1) ? dialogueIfAlone : dialogueIfMany;

            talkScript.dialogueData = chosenDialogue;
            talkScript.npcPrefab = list[i];
            npcState.dialogueData = chosenDialogue;
            FinalEnding final = npc.AddComponent<FinalEnding>();
            final.dialogueManager = dialogueManager;
            final.fadeCanvas = fadeCanvas;
        }
    }
}
