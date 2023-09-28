using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 5f;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    public void Initialize(Vector2 direction)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * projectileSpeed;
    }

    /* //Commented out until we have enemies to shoot at
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Insert enemy class name:
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.Damange(0); //set the amount of damage
            Destroy(gameObject); //Destroy projectile once collides with enemy sprite
            Debug.Log("BULLET HIT ENEMY AND WAS DESTROYED!!!");
        }
    }
    */

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy")) return;
        
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
