using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private int requiredTalks = 3; 
    private int currentTalks = 0;

     public bool nextLevel = false; 
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void RegisterTalk()
    {
        currentTalks++;
        Debug.Log("Talked with NPC: " + currentTalks + "/" + requiredTalks);

        if (currentTalks >= requiredTalks)
        {
            Debug.Log("All NPC talked");
            nextLevel = true; 
        }
    }

    public void GoToNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
