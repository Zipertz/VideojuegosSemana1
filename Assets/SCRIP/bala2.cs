using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala2 : MonoBehaviour
{
      SpriteRenderer sr;
    Animator animator;
    public float velocity = 1;
    public float velocity1 = 1;
     private Rigidbody2D rb;
  public float Speed;
  public float Speed1;
  
       public void SetRightDirection(){
        Speed = velocity;
        Speed1 = velocity1;
    }
    public void SetLeftDirection(){
        Speed = -velocity;
        Speed1 = -velocity1;
    }
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,5);
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
   
        rb.velocity = new Vector2(Speed,Speed1);
        
        
    }
      private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "zombie"){
           Destroy(this.gameObject);
         }

         
    }
}
