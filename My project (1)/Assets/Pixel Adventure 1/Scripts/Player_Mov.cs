using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class Player_Mov : MonoBehaviour
{

    bool canJump;

    void Update()
    {   
        if(Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new UnityEngine.Vector2(-4000f * Time.deltaTime,0) );
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new UnityEngine.Vector2(4000f * Time.deltaTime,0));
            gameObject.GetComponent<Animator>().SetBool("moving", true);
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if(!Input.GetKey("left") && !Input.GetKey("right"))
        {
            gameObject.GetComponent<Animator>().SetBool("moving", false);

            
        }

         
        if(Input.GetKeyDown("up") && canJump)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce (new UnityEngine.Vector2 (0, 1000f));
        }

    }


  private  void OnCollisionEnter2D (Collision2D collision)
    {
            if(collision.transform.tag == "Ground" )
            {
                canJump = true;
            }

    }
}