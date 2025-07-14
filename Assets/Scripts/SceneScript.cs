using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
  public void StartGame()
    {
        SceneManager.LoadScene("Game Scene"); // Load the game scene
    }
    public void QuitGame()
    {
        Application.Quit(); // Quit the application
    }
}
