using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float pMoveSpeed = 6.0f;
    float jumpHeight = 20.0f;
    float moveDir;
    private int direction;
    private int jumpCounter=0;
    short maxJump = 1;
    int dashCounter = 0;
    short maxDash = 0;
    Rigidbody2D charRigidBody;
    SpriteRenderer charSprite;
    // Start is called before the first frame update
    void Start()
    {
        direction = 1;
        charRigidBody = GetComponent<Rigidbody2D>();
        charSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //getting direction of horizontal movement from player input.
        //multiplying by time.deltatime not nessecary in this case due to the fact that we are modifying the rigidbody's velocity
        moveDir = Input.GetAxis("Horizontal") * pMoveSpeed;
        charRigidBody.velocity = new Vector2(moveDir, charRigidBody.velocity.y);
        if (Input.GetButtonDown("Jump") && jumpCounter<maxJump)
        {
            //float go = jumpHeight; Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));
          //  Debug.Log(go);
            charRigidBody.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            jumpCounter++;

        }
        if (Input.GetButtonDown("Dash"))
        {
            Debug.Log("Dashing");
            charRigidBody.velocity = new Vector2(charRigidBody.velocity.x+100.0f*direction, charRigidBody.velocity.y);

        }
    

    }
    private void FixedUpdate()
    {
        if (moveDir > 0)
        {
            charSprite.flipX = false;
            direction = 1;
            Debug.Log(direction);
        }
        else if (moveDir < 0)
        {
            charSprite.flipX = true;
            direction = -1;
            Debug.Log(direction);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //using raycasting to check if the player has landed on a surface and can thus jump again.
        var normal = col.contacts[0].normal;
        if (normal.y > 0)//if the bottom side of our character hits something
        { //we reset the jumping bool to allow for jumps
            Debug.Log("Landed");
            jumpCounter = 0;
        }
        
    }
}

