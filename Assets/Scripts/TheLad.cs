using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheLad : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private float speed = 10f;
    private Rigidbody2D lad;
    private SpriteRenderer ladSprite;


    // Start is called before the first frame update
    void Start()
    {
        lad = GetComponent<Rigidbody2D>();
        ladSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var userInput = Input.GetAxis("Horizontal");
        /* Player Movement */
        
        var velocity = new Vector2(0, 0);
        if (userInput != 0)
        {
            velocity.x = userInput * speed;
        }
        
        lad.velocity = velocity;

        /*animations*/
        animator.SetFloat("speedx", Mathf.Abs(userInput));

        /* Sprite Flipping */

        if (velocity.x > 0)
        {
            ladSprite.flipX = true;
        }
        else if (velocity.x < 0)
        {
            ladSprite.flipX = false;
        } 
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Projectile"))
        {
            Destroy(this.gameObject);
            GameObject gameObj =  GameObject.FindGameObjectWithTag("GameManager");

			GameManager targetScript = gameObj.GetComponent<GameManager>();
			if (targetScript != null)
			{
				// Call a function on the target script
				targetScript.GameOver();
			}
        }
    }
}
