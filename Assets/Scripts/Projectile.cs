using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 5f;
    //[SerializeField] private float lifeTime = 1f;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    private GameObject player;
    private Rigidbody2D playerRB;

    private int collisionCount = 0;
    
    public void Initialize(Vector2 direction)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody2D>();
        
        rb = GetComponent<Rigidbody2D>();
        var modifiedDirection = direction.normalized;
        
        modifiedDirection.x += playerRB.velocity.x / projectileSpeed;
        rb.velocity = modifiedDirection * projectileSpeed;
        print(rb.velocity);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy")) return;
        
        Destroy(collision.gameObject);
        Destroy(gameObject);
        Debug.Log("Projectile destroyed evil square!");
    }
}
