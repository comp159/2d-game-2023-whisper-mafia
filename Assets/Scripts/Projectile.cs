using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //UPDATE (Continued): Add player momentum to projectile speed for a faster projectile
    //[UPDATE] 9-28-2023 - Spoke with Brian in-person about this mechanic. Due to the time constraints, this idea will be scrapped.
    
    //UPDATE (Continued): Allow projectile to only bounce ONCE on a 2D collider object. The next 2D collider destroys the projectile.
    //[UPDATE] 9-28-2023 --> Completed [We can increase the bounce limit by changing the second if statement to whatever value desired]
    
    [SerializeField] private float projectileSpeed = 5f;
    private Rigidbody2D rb;
    private GameManager gm;
    
    private int collisionCount = 0;
    
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
        }
    }
}
