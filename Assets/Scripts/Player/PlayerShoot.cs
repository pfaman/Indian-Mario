using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    PlayerControls playerControls;
    public Animator animator;
    public GameObject bullet;
    public Transform bulletHole;
    public float bulletForce = 300f;

    private void Awake()
    {
        playerControls = new PlayerControls();
        playerControls.Enable();

        playerControls.Land.Shoot.performed += ctx => Fire();

        
    }

    public void Fire()
    {
        animator.SetTrigger("shoot");
        GameObject go= Instantiate(bullet, bulletHole.position, bullet.transform.rotation);
        if (GetComponent<PlayerMovement>().isFacingRight)
        {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.right * bulletForce);
        }
        else
        {
            go.GetComponent<Rigidbody2D>().AddForce(Vector2.left * bulletForce);
        }
            
    }
}
