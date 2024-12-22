using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject explosionPrefab; // Drag your explosion prefab here

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a projectile tagged as "PlayerProjectile"
        if (collision.collider.gameObject.tag == "PlayerProjectile")
        {
            // Instantiate the explosion effect at the enemy's position
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            // Destroy the projectile
            Destroy(collision.collider.gameObject);
 
            // Destroy the enemy
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Alternative for trigger-based collision
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject); // Destroy the projectile
            Destroy(gameObject); // Destroy the enemy
        }
    }
}
