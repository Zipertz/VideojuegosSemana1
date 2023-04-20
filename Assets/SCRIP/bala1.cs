using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala1 : MonoBehaviour
{
    // Start is called before the first frame update
   
      SpriteRenderer sr;
    Animator animator;
    public float velocity = 1;
     private Rigidbody2D rb;
  public float Speed;
       public void SetRightDirection(){
        Speed = velocity;
    }
    public void SetLeftDirection(){
        Speed = -velocity;
    }
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
   
        rb.velocity = new Vector2(Speed,0);
        
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "zombie"){
           Destroy(this.gameObject);
         }

         
    }
}
