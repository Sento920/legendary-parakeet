﻿using UnityEngine;
using System.Collections;

/*


public class PlayerController : MonoBehaviour {

    //public
    public Transform groundCheck;
    public LayerMask LM;


    //private
    private Rigidbody2D rb2d;
    private const int MaxHealth = 20;
    private const int JumpForce = 8;
    private const int ShortJumpForce = 5;
    private const int MoveForce = 5;
    private const float groundCheckRadius = 0.25f;
    [SerializeField]
    private bool isGrounded;
    private bool jumpCancel;
    private bool jumpActive;


    // Use this for initialization
    void Start () {
        this.rb2d = GetComponent< Rigidbody2D >();
        
	}
	
	// Update is called once per frame
	void Update () {
        GroundDetect();
        MoveCharacter();
	}

/*

    void MoveCharacter()
    {
        float inputH = Input.GetAxisRaw( "Horizontal" );
        
        //Horizontal
        if ( inputH != 0 ) {
            rb2d.velocity = new Vector2 ( inputH * MoveForce, rb2d.velocity.y );
        } else {
            rb2d.velocity = new Vector2 ( 0f , rb2d.velocity.y );
        }
        //Vertical
        if ( jumpActive ) {
            print("Jump Full");
            rb2d.velocity = new Vector2 ( rb2d.velocity.x , JumpForce );
            jumpActive = false;
        }

        if ( jumpCancel ) {
            if( rb2d.velocity.y > ShortJumpForce ) {
                print("Jump Cut");
                rb2d.velocity = new Vector2 ( rb2d.velocity.x , ShortJumpForce );
                jumpCancel = false;
            }
        }
    }

/*

    void GroundDetect() {

        isGrounded = Physics2D.OverlapCircle( groundCheck.position , groundCheckRadius, LM );

        if(Input.GetButtonDown( "Jump" )  && isGrounded) {
            jumpActive = true;
        }
        if(Input.GetButtonUp( "Jump" ) && !isGrounded) {
            print( "G.D. " + Input.GetButtonUp("Jump") + "  , " + !isGrounded );
            jumpCancel = true;
        }
    }


}