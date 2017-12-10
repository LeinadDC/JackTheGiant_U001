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
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        MovePlayer();
	}

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
        }
        else if(horizontalInput < 0)

        {
            if (CheckVelocity(velocity))
            {
                forceX = -speed;
                anim.SetBool("Walk", true);

                ChangeLocalScale(-1.3f);
            }
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        playerBody.AddForce(new Vector2(forceX, 0));
    }

    private bool CheckVelocity(float velocity)
    {
        return velocity < maxVelocity;
    }

    private Vector3 ChangeLocalScale(float xScale)
    {
        Vector3 temp = transform.localScale;
        temp.x = xScale;
        transform.localScale = temp;
        return temp;
    }
}
