using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bala : MonoBehaviour
{
      SpriteRenderer sr;
    Animator animator;
    public float velocity = 1;
     private Rigidbody2D rb;

      public Text puntajetexto;

     public GameObject bullet1;
     public GameObject bullet2;
     public GameObject bullet3;
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
        Destroy(this.gameObject,5);
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
   
        rb.velocity = new Vector2(Speed,0);
        
        if (Input.GetKeyDown(KeyCode.M)  ){
            Destroy(this.gameObject);
          if(sr.flipX == false){

            var shieldPosition2 = transform.position + new Vector3(1,1,0);

                   var gb1 = Instantiate(bullet2,
                                 shieldPosition2,
                                 Quaternion.identity) as GameObject;
                var controller1 =gb1.GetComponent<bala2>();
               
                var shieldPosition = transform.position + new Vector3(1,0,0);

                var gb = Instantiate(bullet1,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<bala1>();


            var shieldPosition1 = transform.position + new Vector3(1,-1,0);
                var gb2 = Instantiate(bullet3,
                                 shieldPosition1,
                                 Quaternion.identity) as GameObject;

        

                var controller2 =gb2.GetComponent<bala3>();


            

             
                controller.SetRightDirection(); 
                
             }
             if(sr.flipX==true){
                
                
                 var shieldPosition1 = transform.position + new Vector3(-1,-1,0);
               



                     var gb2 = Instantiate(bullet3,
                                 shieldPosition1,
                                 Quaternion.identity) as GameObject;
                var controller2 =gb2.GetComponent<bala3>();

        var shieldPosition2 = transform.position + new Vector3(-1,1,0);
                   var gb1 = Instantiate(bullet2,
                                 shieldPosition2,
                                 Quaternion.identity) as GameObject;
                var controller1 =gb1.GetComponent<bala2>();

 var shieldPosition = transform.position + new Vector3(1,0,0);
               var gb = Instantiate(bullet1,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<bala1>();
                controller.SetLeftDirection(); 
               
             }
                     
        
        }

    }
  
      
   
      
  
    
}
