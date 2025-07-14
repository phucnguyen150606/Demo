using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject VolumeUI;
    public Text scoreText;
    public int PlayerScore = 0;
    public GameObject StartText;
    public bool isPaused = false;
    public GameObject Setting_Screen;
    public SaveData saveData; // Reference to SaveData script

  

    void Start()
    {
      
        Time.timeScale = 0f; // Pause the game
        scoreText.text = PlayerScore.ToString();
    }
    void Update()
    {
        
        if (!Setting_Screen.activeSelf && !GameOverUI.activeSelf && Input.GetKeyDown(KeyCode.Space)) // Check if the space key is pressed
        {
            Time.timeScale = 1f; // Resume the game
            StartText.SetActive(false); // Hide the start text
        }
        // Only pause the game if GameOverUI just became active and the game isn't already paused
        Setting();
    }
    public void addScore(int AddScore)
    {
        PlayerScore = PlayerScore + AddScore;
        scoreText.text = PlayerScore.ToString();
    }

    public void ResetGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
   
    public void GameOver()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0; // Pause the game
        if(PlayerScore > saveData.LoadData())
        {
            saveData.SaveGame(); // Save the game if the score is higher than the saved score
        }
    }

    public void QuitButton()
    {
        Application.Quit(); // Quit the Game
    }

    public void ResumeButton()
    {
        Setting_Screen.SetActive(false); // hide the settings screen
        isPaused = false;
        if(StartText.activeSelf || GameOverUI.activeSelf) return; // If the start text is active, do nothing
        Time.timeScale = 1; // Resume the game
        
    }
    public void Setting()
    {
        if (VolumeUI.activeSelf) return; // If the game is over, do nothing
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (!isPaused)
            {
                Time.timeScale = 0; // Pause the game
                Setting_Screen.SetActive(true); // Show the settings screen
                isPaused = true; // Set the pause state to true
            }
            else
            {
                Setting_Screen.SetActive(false); // Hide the settings screen
                isPaused = false; // Set the pause state to false
                if (StartText.activeSelf || GameOverUI.activeSelf) return; // If the start text is active, do nothing
                Time.timeScale = 1; // Resume the game
                
            }
        }
    }

    public void VolumeButton()
    {
            if (isPaused)
            {
                Setting_Screen.SetActive(false); // Show the settings screen
                VolumeUI.SetActive(true); // Show the volume settings screen
            }
    }

    public void BackButton()
    {
        if (isPaused)
        {
            Setting_Screen.SetActive(true); // Show the settings screen
            VolumeUI.SetActive(false); // Show the volume settings screen
        }
    }
}
