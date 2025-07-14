using UnityEngine;
using UnityEngine.UI;

public class SaveData : MonoBehaviour
{
    public GameManagerScript gameManager;

    public Text HighScoreText;
    void Start()
    {
        int saveScore = LoadData();
        HighScoreText.text = saveScore.ToString(); // Display the loaded high score


    }

    void Update()
    {
        
    }
    public void SaveGame()
    {
        PlayerPrefs.SetInt("HighScore", gameManager.PlayerScore);
        PlayerPrefs.Save();
        
    }
    public int LoadData()
    {
        return PlayerPrefs.GetInt("HighScore"); // Default to 0 if no high score is saved
    }

    
}
