using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameNpcManager : MonoBehaviour
{
    public static GameNpcManager Instance;
    public List<GameObject> positiveNpcPrefabs = new List<GameObject>();



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterPositiveNPC(GameObject npcPrefab)
    {
        if (!positiveNpcPrefabs.Contains(npcPrefab))
        {
            npcPrefab.transform.SetParent(null);
            DontDestroyOnLoad(npcPrefab);
            positiveNpcPrefabs.Add(npcPrefab);
        }
    }

}


