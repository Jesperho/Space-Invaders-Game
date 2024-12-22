using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float moveSpeed;

    public GameObject explosionPrefab;
    private PointManager pointManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            pointManager.UpdateScore(50);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
        
        if(collision.gameObject.tag == "Shield")
        {
            Destroy(gameObject);
        }
        
    }

}
