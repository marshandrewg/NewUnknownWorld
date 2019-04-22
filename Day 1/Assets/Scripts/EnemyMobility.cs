using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMobility : MonoBehaviour
{

    public float speed;
    public float xMove;


    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(xMove,0));
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (xMove, 0) * speed;
        if(hit.distance < 1.1f){
          Flip();
          if(hit.collider.tag == "Player"){
            Destroy(hit.collider.gameObject);
          }
        }
    }

    void Flip()
    {
      Vector2 scale = gameObject.transform.localScale;
      scale.x *= -1;
      transform.localScale = scale;
      xMove *= -1;
    }
}
