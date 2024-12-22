using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime); // Move downward
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boundary"))
        {
            Debug.Log("Projectile hit the boundary."); // Debug log
            Destroy(gameObject); // Destroy projectile
        }
    }
}
