using System.Collections.Generic;
using UnityEngine;

public class EnemyGridManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs; // List of enemy prefabs
    public int rows = 5; // Number of rows
    public int columns = 10; // Number of columns
    public float spacing = 1.5f; // Spacing between enemies
    public float moveSpeed = 2f; // Grid movement speed
    public GameOverController GameOverController; // Reference to the GameOverController

    private Vector2 direction = Vector2.right;

    void Start()
    {
        CreateEnemyGrid();
    }

    void Update()
    {
        MoveGrid();

        // Check if all enemies are destroyed
        if (AreAllEnemiesDestroyed())
        {
            GameOverController.GameOver(); // Trigger Game Over when all enemies are destroyed
        }
    }

    void CreateEnemyGrid()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                Vector3 position = transform.position + new Vector3(col * spacing, -row * spacing, 0);

                // Select an enemy prefab
                GameObject selectedPrefab = SelectEnemyPrefab(row, col);

                // Instantiate the enemy
                GameObject enemy = Instantiate(selectedPrefab, position, Quaternion.identity, transform);

                // Ensure the enemy has the "Enemy" tag
                enemy.tag = "Enemy";
            }
        }
    }

    GameObject SelectEnemyPrefab(int row, int col)
    {
        if (enemyPrefabs.Count == 0)
        {
            Debug.LogError("No enemy prefabs assigned to EnemyGridManager!");
            return null;
        }

        return enemyPrefabs[(row + col) % enemyPrefabs.Count];
    }

    void MoveGrid()
    {
        // Move the grid in the current direction
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Check for boundaries
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (enemy != null)
            {
                float xPos = enemy.transform.position.x;

                if (xPos <= -8f || xPos >= 8f) // Adjust based on screen boundaries
                {
                    ChangeDirectionAndDescend();
                    break;
                }
            }
        }
    }

    void ChangeDirectionAndDescend()
    {
        direction *= -1; // Reverse direction
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z); // Descend
    }

    bool AreAllEnemiesDestroyed()
    {
        // Check if there are no active enemies with the "Enemy" tag
        GameObject[] remainingEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        return remainingEnemies.Length == 0;
    }
}
