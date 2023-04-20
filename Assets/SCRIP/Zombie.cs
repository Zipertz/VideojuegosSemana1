using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

     SpriteRenderer sr;
    Animator animator;
    public float velocity = 1f;
     private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
   
        rb.velocity = new Vector2 (-velocity,0);
        sr.flipX = true;
        
    }
    void OnCollisionEnter2D(Collision2D other) {
        
   if(other.gameObject.tag == "bala"){
           Destroy(this.gameObject);
         }
      
      if(other.gameObject.tag == "bala1"){
           Destroy(this.gameObject);
         }
         if(other.gameObject.tag == "bala2"){
           Destroy(this.gameObject);
         }
         if(other.gameObject.tag == "bala3"){
           Destroy(this.gameObject);
         }
    
    }
    
}
