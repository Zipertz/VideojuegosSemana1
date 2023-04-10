using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYERCA : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
     SpriteRenderer sr;
    Animator animator;
    public float velocity = 10;
    public float vcorrer = 20;
    public float JumpForce = 5; 


    
    const int ANIMATION_QUIETO = 0;
    const int ANIMATION_CAMINAR = 1;
    const int ANIMATION_CORRER = 2;
    const int ANIMATION_ATACAR = 3;

    const int ANIMATION_DISPARO = 4; 

    const int  ANIMATION_DESLIZAR = 5;
    const int ANIMATION_DISPARAR = 6;

    const int ANIMATION_MORIR = 7;
    const int ANIMATION_SALTAR = 8;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         rb.velocity = new Vector2(0, rb.velocity.y);  
          ChangeAnimation(ANIMATION_QUIETO);  
  


        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocity, rb.velocity.y);
          
            sr.flipX = false;
            ChangeAnimation(ANIMATION_CAMINAR);   
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-velocity, rb.velocity.y);

           sr.flipX = true;
           ChangeAnimation(ANIMATION_CAMINAR);   
          
        }

        if (Input.GetKey(KeyCode.X))
        {
           
             ChangeAnimation(ANIMATION_ATACAR);   
            
        }
         if (Input.GetKey(KeyCode.Z))
        {
           
             ChangeAnimation(ANIMATION_DISPARO);   
            
        }
      
           if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.N))
        {
            
          rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = true;
            
            ChangeAnimation(ANIMATION_DESLIZAR);
        }

         if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.N))
        {
            
          rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false;
            
            ChangeAnimation(ANIMATION_DESLIZAR);
        }



     if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.M))
        {
            
          rb.velocity = new Vector2(-velocity, rb.velocity.y);
            sr.flipX = true;
            
            ChangeAnimation(ANIMATION_DISPARAR);
        }

    if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.M))
        {
            
          rb.velocity = new Vector2(velocity, rb.velocity.y);
            sr.flipX = false;
            
            ChangeAnimation(ANIMATION_DISPARAR);
        }


  if (Input.GetKeyUp(KeyCode.F))
        {
            
            ChangeAnimation(ANIMATION_MORIR);
        }

        if (Input.GetKeyDown(KeyCode.Space) )
        {
           
            rb.AddForce(new Vector2(0,JumpForce),ForceMode2D.Impulse);
            ChangeAnimation(ANIMATION_SALTAR);
           

           
        }

    
 }

     private void ChangeAnimation(int animation)
    {
        animator.SetInteger("Estado0", animation);
       

    }
   
}
