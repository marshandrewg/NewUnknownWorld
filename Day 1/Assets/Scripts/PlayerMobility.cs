using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour
{

    public float speed;
    public bool facingRight = false;
    public int jumpPower;
    public bool grounded;



    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        PlayerRaycast();
    }

    void PlayerMove()
    {
      // Controls
      float input =  Input.GetAxis("Horizontal");
      if(Input.GetButtonDown("Jump") && grounded){
        Jump();
      }

      //Animations
      //Player Direction
      if(input < 0.0f && facingRight){
        FlipPlayer();
      }
      else if(!facingRight && input > 0.0f){
        FlipPlayer();
      }
      //Physics
      GetComponent<Rigidbody2D>().velocity = new Vector2(input * speed, GetComponent<Rigidbody2D>().velocity.y );
    }

    void FlipPlayer()
    {
      facingRight = !facingRight;
      Vector2 scale = gameObject.transform.localScale;
      scale.x *= -1;
      transform.localScale = scale;
    }

    void Jump()
    {
      GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower);
      grounded = false;
    }

    void PlayerRaycast()
    {
      RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
      if (hit != null && hit.collider != null && hit.distance < 1.2f && hit.collider.tag == "enemy"){
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 450);
        Destroy(hit.collider.gameObject);
      }
      if (hit != null && hit.collider != null && hit.distance < 1.1f && hit.collider.tag != "enemy"){
        grounded = true;
      }
    }
}
