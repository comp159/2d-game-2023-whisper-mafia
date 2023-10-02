using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 5f;
    private Rigidbody2D rb;
    private GameManager gm;
    
    private int collisionCount = 0;
    
    void Start()
    {
        gm.GetComponent<GameManager>();
    }

    public void Initialize(Vector2 direction, GameManager gm)
    {
        this.gm = gm;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * projectileSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gm.IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            gm.DestroyArrow(); //Increases currentArrowCount by 1
        }
        else
        {
            //If projectile doesn't hit a game object with the Enemy tag, the collision count increments
            collisionCount++;
        }

        //If the projectile's collision count is 2 or more, it's destroyed
        if (collisionCount >= 2)
        {
            Destroy(gameObject);
            gm.DestroyArrow(); //Increases currentArrowCount by 1
        }
    }
}
