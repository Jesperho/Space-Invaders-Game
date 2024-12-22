using Unity.Mathematics;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public float cooldown = 0.5f; // Cooldown time in seconds
    private float lastShotTime = -Mathf.Infinity; // Tracks when the last shot was fired
    public GameObject projectilePrefab; // The projectile prefab
    public AudioClip shootSound; // Shooting sound effect
    private AudioSource audioSource; // Reference to the AudioSource component

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player presses the fire button and if the cooldown has passed
        if (Input.GetButtonDown("Fire1") && Time.time >= lastShotTime + cooldown)
        {
            Shoot();
            lastShotTime = Time.time; // Update the time of the last shot
        }
    }

    void Shoot()
    {
        // Instantiate the projectile
        Instantiate(projectilePrefab, transform.position, quaternion.identity);

        // Play the shooting sound effect
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
    }
}
