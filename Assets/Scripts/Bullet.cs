using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.8f;
    public float range = 4;
    public float rangeX = 6;
    float startingX;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            AudioManager.instance.Play("EnemyDamage");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if(collision.tag == "Zombie")
        {
            AudioManager.instance.Play("EnemyDamage");
            collision.GetComponent<Zoombie>().TakeDamage(25);
            Destroy(gameObject);
        }
        if(collision.CompareTag("OutOfGame"))
        {
            Debug.Log("Done");
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void Start()
    {
        startingX = transform.position.x;
    }
    private void FixedUpdate()
    {
        //transform.Translate(Vector2.up * speed * Time.deltaTime * dir);
        if (transform.position.x > 0)
        {
            if (transform.position.x > startingX + rangeX)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            // Test
            if ((-transform.position.x) <startingX +range)
            {
                Destroy(gameObject);
            }
        }
        

    }
}
