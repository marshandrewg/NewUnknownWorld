using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour
{

    public float speed;
    public bool facingRight = false;  


    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
      // Controls
      float input =  Input.GetAxis("Horizontal");
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
      scale.y *= -1;
      transform.localScale = scale;
    }
}
