using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
public class playerBotones : MonoBehaviour
{
     Rigidbody2D rb;
     SpriteRenderer sr;
    Animator animator;
    public float JumpForce = 5;
    public float velocity = 0;
    public float defaultVelocity=14;
    private GameManager gameManager;
    public int aux = 0;
    
     public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        gameManager = FindObjectOfType<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
         Movimiento();
        
    }
      private void Movimiento()
    {
        Walk();
        
    }


    private void Walk()
    {
        rb.velocity = new Vector2(velocity,rb.velocity.y);
        if(velocity < 0)
            sr.flipX = true;

        if(velocity > 0)
            sr.flipX = false;
    }

        public void MoverDerecha()
    {
        
        velocity = defaultVelocity;
        

    }

    public void MoverIzquierda()
    {
        
          velocity = -defaultVelocity;
        
           
    }
public void Quieto()
    {
        
        velocity=0;
    }

   public void Saltar()
    {
       
        if(aux < 2)
        {
            rb.AddForce(new Vector2(0,JumpForce),ForceMode2D.Impulse);
            aux++;
        }
        

    }

    
    public void Attack(){

        
            if(gameManager.auxbalas() > 0){
            var game = FindObjectOfType<GameManager>();
               if(sr.flipX == false){
               
                
                var shieldPosition = transform.position + new Vector3(2,0,0);
                var gb = Instantiate(bullet,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<bala>();
                controller.SetRightDirection(); 
                gameManager.perderBala();
                
             }
             if(sr.flipX==true){
                
                
                var shieldPosition = transform.position + new Vector3(-2,0,0);
                var gb = Instantiate(bullet,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<bala>();
                controller.SetLeftDirection(); 
                gameManager.perderBala();
               
             }
                     
         
        }
        
    }


    
}


