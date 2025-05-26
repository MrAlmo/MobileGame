using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalLevelSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints; 

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
            Instantiate(list[i], spawnPoints[i].position, Quaternion.identity);
        }
    }
}
