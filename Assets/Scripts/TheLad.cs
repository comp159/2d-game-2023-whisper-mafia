using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheLad : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D lad;


    // Start is called before the first frame update
    void Start()
    {
        lad = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float userInput = Input.GetAxis("Horizontal");
        if (userInput != 0) {
            Vector2 velocity = new Vector2(userInput * speed, 0);
            lad.velocity = velocity;
        }
        else {
            lad.velocity = Vector2.zero;
        }
    }
}
