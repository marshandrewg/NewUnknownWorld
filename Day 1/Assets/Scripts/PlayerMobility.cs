using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMobility : MonoBehaviour
{

    public float speed;
    public int jumpPower;
    public bool grounded;
    public Animator anim;



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

      //Player Direction
      if(input < 0.0f ){
        GetComponent<SpriteRenderer>().flipX = true;
      }
      else if(input > 0.0f){
        GetComponent<SpriteRenderer>().flipX = false;
      }
      //Physics
      GetComponent<Rigidbody2D>().velocity = new Vector2(input * speed, GetComponent<Rigidbody2D>().velocity.y );
      anim.SetFloat("speed", Mathf.Abs(input * speed));

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
