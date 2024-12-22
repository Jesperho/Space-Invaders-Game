using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the Game Over UI
    public GameObject gameplayObjects; // Parent object for gameplay elements
    public TMP_Text gameOverScoreText; // Reference to the score text on the Game Over UI
    public PointManager pointManager; // Reference to the PointManager

    public void GameOver()
    {
        Time.timeScale = 0f; // Pause the game
        gameOverPanel.SetActive(true); // Show the Game Over UI

        if (gameplayObjects != null)
        {
            gameplayObjects.SetActive(false); // Disable gameplay objects
        }

        // Display the final score on the Game Over UI
        if (pointManager != null && gameOverScoreText != null)
        {
            gameOverScoreText.text = "Final Score: " + pointManager.GetScore();
        }
    }

    public void RetryGame()
    {
        Time.timeScale = 1f; // Resume the game

        if (gameplayObjects != null)
        {
            gameplayObjects.SetActive(true); // Re-enable gameplay objects
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }
}
