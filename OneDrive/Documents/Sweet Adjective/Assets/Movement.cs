using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float pMoveSpeed = 6.0f;
    float jumpHeight = 10.0f;
    bool jumping;
    Rigidbody2D charRigidBody;
    SpriteRenderer charSprite;
   
    // Start is called before the first frame update
    void Start()
    {
        charRigidBody = GetComponent<Rigidbody2D>();
        charSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //getting direction of horizontal movement from player input.
        //multiplying by time.deltatime not nessecary in this case due to the fact that we are modifying the rigidbody's velocity
        float moveDir = Input.GetAxis("Horizontal") * pMoveSpeed;
        charRigidBody.velocity = new Vector2(moveDir, charRigidBody.velocity.y);
        // Your jump code:
        if (Input.GetButtonDown("Jump") && !jumping)
        {
            Debug.Log("Jumping");
            charRigidBody.velocity = new Vector2(charRigidBody.velocity.x, jumpHeight);
            jumping = true;

        }
        if (moveDir > 0)
        {
            charSprite.flipX = false;
        }
        else if (moveDir < 0)
        {
            charSprite.flipX = true;
        }
        //Debug.Log(moveDir); //used this to see the velocity values for the character

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //using raycasting to check if the player has landed on a surface and can thus jump again.
        var normal = col.contacts[0].normal;
        if (normal.y > 0)//if the bottom side of our character hits something
        { //we reset the jumping bool to allow for jumps
            Debug.Log("Landed");
            jumping = false;
        }
        /* if (normal.y < 0)
         { //if the top side hit something
             Debug.Log("You Hit the roof");
         }*/
    }
}

