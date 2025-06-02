using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject optionsPanel;

    void Start()
    {
        if (SettingsUIController.Instance == null)
        {
            SceneManager.LoadScene("SettingsUI", LoadSceneMode.Additive);
        }
    }


    public void StartGame()
    {
        // Завантажити основну сцену гри
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenOptions()
    {
        if (SettingsUIController.Instance != null)
        {
            SettingsUIController.Instance.OpenSettings();
        }
    }


    public void CloseOptions()
    {
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Гра закрита"); // Не видно в редакторі, але працює у build
    }
}

