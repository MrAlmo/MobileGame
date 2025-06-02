using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsUIController : MonoBehaviour
{
    public static SettingsUIController Instance;

    public GameObject settingsPanel;
    public Slider volumeSlider;
    public AudioSource audioSource;

    private bool isOpen = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Знищити дубль
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        settingsPanel.SetActive(false);
    }


    void Start()
    {
        if (volumeSlider != null && audioSource != null)
        {
            volumeSlider.value = PlayerPrefs.GetFloat("volume", 1f);
            audioSource.volume = volumeSlider.value;
            volumeSlider.onValueChanged.AddListener(SetVolume);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu" && Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleSettings();
        }
    }

    public void OpenSettings()
    {
        isOpen = true;
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseSettings()
    {
        isOpen = false;
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ToggleSettings()
    {
        isOpen = !isOpen;
        settingsPanel.SetActive(isOpen);
        Time.timeScale = isOpen ? 0f : 1f;
    }

    public void SetVolume(float value)
    {
        if (audioSource != null)
        {
            audioSource.volume = value;
            PlayerPrefs.SetFloat("volume", value);
        }
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        settingsPanel.SetActive(false);
        isOpen = false;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Гра закрита");
    }
}
