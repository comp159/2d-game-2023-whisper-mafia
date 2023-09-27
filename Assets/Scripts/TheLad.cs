using UnityEngine;

public class TheLad : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D _lad;
    
    // Start is called before the first frame update
    void Start()
    {
        _lad = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var userInput = Input.GetAxis("Horizontal");
        var velocity = new Vector2(0, 0);
        
        if (userInput != 0)
        {
            velocity.x = userInput * speed;
        }

        _lad.velocity = velocity;
    }
}
