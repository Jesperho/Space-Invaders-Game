using UnityEngine;

public class Shield : MonoBehaviour
{
    public Sprite[] states; // Array of sprites for shield states
    private int health; // Shield health
    private SpriteRenderer sr; // SpriteRenderer for visuals

    void Start()
    {
        health = 4; // Initialize shield health
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Shield touched by Enemy.");
            TakeDamage(); // Apply damage to the shield
        }
        else if (collision.CompareTag("EnemyProjectile"))
        {
            Debug.Log("Shield hit by EnemyProjectile.");
            Destroy(collision.gameObject); // Destroy the projectile
            TakeDamage(); // Apply damage to the shield
        }
        else if (collision.CompareTag("PlayerProjectile"))
        {
            Debug.Log("Shield hit by PlayerProjectile.");
            Destroy(collision.gameObject); // Destroy the player projectile
        }
    }

    private void TakeDamage()
    {
        health--; // Reduce shield health
        Debug.Log($"Shield damaged. Remaining health: {health}");

        if (health <= 0)
        {
            Debug.Log("Shield destroyed.");
            Destroy(gameObject); // Destroy the shield
        }
        else
        {
            sr.sprite = states[health - 1]; // Update the sprite based on health
        }
    }
}
