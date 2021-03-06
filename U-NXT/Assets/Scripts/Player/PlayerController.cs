﻿using UnityEngine;
using System.Collections;

/*
===============================================================================

	Player Controller Handles all movement functions, Along with Health, and Weapon systems. It also contains public accessors for the Player's Data.

    Credit for the idea behind the variable Jump height: Reddit user "dookie-boy"

    url:https://www.reddit.com/r/Unity3D/comments/26p2yk/variable_jump_height_depending_on_button_push/

===============================================================================
*/


public class PlayerController : MonoBehaviour {

    //public
    public Transform groundCheck;
    public LayerMask lM;
    public GameObject[] munition;

    //private
    private Rigidbody2D rb2d;
    private const int MaxHealth = 20;
    private const int JumpForce = 8;
    private const int ShortJumpForce = 5;
    private const int MoveForce = 5;
    private const float groundCheckRadius = 0.25f;
    private int selectedMunition;
    private bool isGrounded;
    private bool jumpCancel;
    private bool jumpActive;

    private float reloadTime;

    // Use this for initialization
    void Start() {
        this.rb2d = GetComponent<Rigidbody2D>();
        selectedMunition = 0;
    }

    // Update is called once per frame
    void Update() {
        GroundDetect();
        MoveCharacter();
        Fire(selectedMunition);
    }

    /*
    ====================
    MoveCharacter()

      Moves the Character via Input from the Keyboard. Should be called first every frame. 
        Variable jump height is achieved by button press and hold. 
        isGrounded is calculated using the player's collider.   
    ====================
    */

    void MoveCharacter() {
        float inputH = Input.GetAxisRaw("Horizontal");

        //Horizontal
        if(inputH != 0) {
            rb2d.velocity = new Vector2(inputH * MoveForce, rb2d.velocity.y);
        } else {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }
        //Vertical
        if(jumpActive) {
            print("Jump Full");
            rb2d.velocity = new Vector2(rb2d.velocity.x, JumpForce);
            jumpActive = false;
        }

        if(jumpCancel) {
            if(rb2d.velocity.y > ShortJumpForce) {
                print("Jump Cut");
                rb2d.velocity = new Vector2(rb2d.velocity.x, ShortJumpForce);
                jumpCancel = false;
            }
        }
    }

    /*
    ====================
    GroundDetect()

      Detects if the player is touching the ground for jumping, 
        Also determines if the player is still holding the jump button for extended jumps.  
    ====================
    */

    void GroundDetect() {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, lM);

        if(Input.GetButtonDown("Jump") && isGrounded) {
            jumpActive = true;
        }
        if(Input.GetButtonUp("Jump") && !isGrounded) {
            print("G.D. " + Input.GetButtonUp("Jump") + "  , " + !isGrounded);
            jumpCancel = true;
        }
    }

    /*
    ====================
    Fire()

        Literally fires the attached projectile.
            Projectile is selected using the Int passed in during update.
            Attached projectile is Massless, and uses only a collider and a Rigidbody.
            Maximum Projectiles are possible by parent-child relationship.
    ====================
    */

    void Fire(int selectedProjectile) {

        if(Input.GetButtonDown("Fire1")) {
            
            GameObject child = (GameObject) Instantiate ( munition[ selectedMunition ], transform.position , munition[ selectedMunition ].transform.rotation);
            child.GetComponent<Projectile>().PlayFire();
            child.transform.SetParent(transform);

        }

    }
}