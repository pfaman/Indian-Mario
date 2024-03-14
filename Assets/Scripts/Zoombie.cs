using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoombie : MonoBehaviour
{
    Transform target;
    public Transform borderCheck;
    public Animator animator;
    public Slider zombieHealthBar;

    public float healthHp = 100f;
    // Start is called before the first frame update
    void Start()
    {
        zombieHealthBar.value = healthHp;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreCollision(transform.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(0.34f, 0.34f);
        }
        else
        {
            transform.localScale = new Vector2(-0.34f, 0.34f);
        }
    }
    public void TakeDamage(int healthAmount)
    {
        
        healthHp -= healthAmount;
        zombieHealthBar.value = healthHp;
        if (healthHp > 0)
        {
            animator.SetTrigger("damage");
        }
        else
        {
            animator.SetTrigger("death");
            
            GetComponent<CapsuleCollider2D>().enabled = false;
            this.enabled = false;
            Invoke("DestroyEnemy", 2f);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void PlayerDamage()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCollision>().TakeDamage();
    }
}
