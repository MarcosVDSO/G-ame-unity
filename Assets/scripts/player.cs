using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Animator playerAnim;
    private Rigidbody2D rbPlayer;
    private SpriteRenderer sr; 
    public float speed;
    public float jumpForce;
    public bool inFloor = true; 
    //public bool attackingBool = false;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
       MovePlayer(); 
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();
        LongAttack();
        FisicalAttack();
        
        //StopPlayerInAttack();
    }

    void MovePlayer() {
        float horizontalMoviment = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalMoviment);
        //transform.position += new Vector3(horizontalMoviment * Time.deltaTime * speed, 0, 0);
        rbPlayer.velocity = new Vector2(horizontalMoviment * speed, rbPlayer.velocity.y);

        if(horizontalMoviment > 0) {
            sr.flipX = false;
            playerAnim.SetBool("Walk", true);
        }

        else if (horizontalMoviment < 0) {
            sr.flipX = true;
            playerAnim.SetBool("Walk", true);
        }
        else {
            playerAnim.SetBool("Walk", false);
        }
    }

    void Jump() {
        if (Input.GetButtonDown("Jump") && inFloor) {
            playerAnim.SetBool("Jump", true);
            rbPlayer.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            inFloor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Ground") {
            inFloor = true;
            playerAnim.SetBool("Jump", false);
            
        }
    }

    void FisicalAttack() {
        //attackingBool = true;
        if(Input.GetButtonDown("Fire2") && inFloor) {
             playerAnim.SetBool("FisicalAttack", true);
             speed = 0;
             
        }
    }

    // void StopPlayerInAttack() {
    //     if(attackingBool == true) {
    //         speed = 0;
    //     }
    // }

    void EndFisicalAttack() {
        playerAnim.SetBool("FisicalAttack", false);
        //attackingBool = false;
        speed = 4;
    }

    void LongAttack() {
        //attackingBool = true;
        if(Input.GetButtonDown("Fire3")) {
             playerAnim.SetBool("LongAttack", true);
             speed = 0;
             
        }
    }

    // void StopPlayerInAttack() {
    //     if(attackingBool == true) {
    //         speed = 0;
    //     }
    // }

    void EndLongAttack() {
        playerAnim.SetBool("LongAttack", false);
        //attackingBool = false;
        speed = 4;
    }



}
