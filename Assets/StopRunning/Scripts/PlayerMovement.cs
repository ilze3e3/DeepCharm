using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    private float move;

    public float moveSpeed = 5;
    public float jumpHeight = 5;
    public float sprintMulti = 2;
    public bool shielded = false;
 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal") * moveSpeed;

        if (Input.GetButtonDown("Jump")) //Checks if the button is pressed on that frame and "jump" is assigned to a keybinding
        {
            rb.velocity += Vector2.up * jumpHeight;

        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Obstacles")
        {
            Debug.Log("Player hit an obstacle");
            if (shielded)
            {
                shielded = false;
                // Change sprite
            }
            else
            {
                Debug.Log("Player Should Die");
                Time.timeScale = 0;
                // Spawn Game Over UI
            }
        }
        if(collision.gameObject.tag == "Shield_Powerup")
        {
            Destroy(collision.gameObject);
            shielded = true;
        }
    }
    /*
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move, rb.velocity.y);  // Easier customisation compared to manually hardcoding vector2.left and vector2.right
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    */
}
