using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu; // Reference to the Pause Menu UI

    private bool isPaused = false; // Tracks whether the game is paused

    void Update()
    {
        // Check if the P key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Pause the game
        pauseMenu.SetActive(true); // Show the pause menu
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume the game
        pauseMenu.SetActive(false); // Hide the pause menu
    }

    public void QuitGame()
    {
        // Return to the main menu or quit the application
        Time.timeScale = 1f; // Resume the game before quitting
        SceneManager.LoadScene("MainMenu");
    }
}
