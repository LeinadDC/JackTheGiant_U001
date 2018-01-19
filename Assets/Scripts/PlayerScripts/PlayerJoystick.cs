using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour {

    public float speed = 8f, maxVelocity = 4f;
    private Rigidbody2D playerBody;
    private Animator anim;

    private bool moveLeft, moveRight;

    void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }//Ends Awake

    // Update is called once per frame
    void FixedUpdate () {
        if (moveLeft)
        {
            MoveLeft();
        }

        if (moveRight)
        {
            MoveRight();
        }
	}

    public void SetMoveLeft(bool moveLeft)
    {
        this.moveLeft = moveLeft;
        this.moveRight = !moveLeft;
    }

    public void StopMoving()
    {
        moveLeft = moveRight = false;
        anim.SetBool("Walk", false);
    }


    void MoveLeft()
    {
        float forceX = 0f;
        float velocity = Mathf.Abs(playerBody.velocity.x);

        if (CheckVelocity(velocity))
        {
            forceX = -speed;
            anim.SetBool("Walk", true);

            ChangeLocalScale(-1.3f);
        }

        playerBody.AddForce(new Vector2(forceX, 0));
    }

    void MoveRight()
    {
        float forceX = 0f;
        float velocity = Mathf.Abs(playerBody.velocity.x);

        if (CheckVelocity(velocity))
        {
            forceX = speed;
            anim.SetBool("Walk", true);

            ChangeLocalScale(1.3f);
        }

        playerBody.AddForce(new Vector2(forceX, 0));
    }

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
}
