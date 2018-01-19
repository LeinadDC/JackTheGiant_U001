using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 8f, maxVelocity = 4f;
    private Rigidbody2D playerBody;
    private Animator anim;

    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }//Ends Awake
	
	void FixedUpdate () {
       // MovePlayer();
	}//Ends FixedUpdate

    void MovePlayer()
    {
        float forceX = 0f;
        float velocity = Mathf.Abs(playerBody.velocity.x);

        float horizontalInput = Input.GetAxisRaw("Horizontal");

        if(horizontalInput > 0)
        {
            if (CheckVelocity(velocity))
            {
                forceX = speed;
                anim.SetBool("Walk", true);

                ChangeLocalScale(1.3f);
            }
        }//Ends horizontalInput > 0
        else if(horizontalInput < 0)

        {
            if (CheckVelocity(velocity))
            {
                forceX = -speed;
                anim.SetBool("Walk", true);

                ChangeLocalScale(-1.3f);
            }
        }//Ends horizontalInput < 0
        else
        {
            anim.SetBool("Walk", false);
        }//Ends Else

        playerBody.AddForce(new Vector2(forceX, 0));
    }//Ends MovePlayer

    private bool CheckVelocity(float velocity)
    {
        return velocity < maxVelocity;
    }//Ends CheckVelocity

    private Vector3 ChangeLocalScale(float xScale)
    {
        Vector3 temp = transform.localScale;
        temp.x = xScale;
        transform.localScale = temp;
        return temp;
    }//Ends ChangeLocalScale

}//Ends Class
