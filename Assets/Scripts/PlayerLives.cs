using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionPrefab;
    public GameOverController gameOverController;

    void Start()
    {
        // Initialization logic if needed
    }

    void Update()
    {
        // Optional: Add any additional updates here
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Enemy")
        {
            Destroy(collision.collider.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            lives -= 1;
            UpdateLivesUI();

            if (lives <= 0)
            {
                Destroy(gameObject);
                gameOverController.GameOver(); // Trigger Game Over
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyProjectile")
        {
            Destroy(collision.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            lives -= 1;
            UpdateLivesUI();

            if (lives <= 0)
            {
                Destroy(gameObject);
                gameOverController.GameOver(); // Trigger Game Over
            }
        }
    }

    // Update the UI based on the current number of lives
    private void UpdateLivesUI()
    {
        for (int i = 0; i < livesUI.Length; i++)
        {
            livesUI[i].enabled = i < lives;
        }
    }
}
