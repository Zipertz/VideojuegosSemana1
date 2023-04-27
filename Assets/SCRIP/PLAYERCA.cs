using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement ;
public class PLAYERCA : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
     SpriteRenderer sr;
    Animator animator;
    public float velocity = 5;
    public float vcorrer = 20;
    public float JumpForce = 50f; 
 
  public AudioClip jumpclip;
  public AudioClip coin;
  public AudioClip muerte;
 AudioSource audioSource;


    
    public const int SaltoMax = 2;
    int aux = 2;
    int aux2=0; 

    private GameManager gameManager;
    public GameObject bullet;
   public PiesSalto piesSalto;
    public ParedSalto paredSalto;
    public ParedIzquierda paredIzquierda;
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
        gameManager = FindObjectOfType<GameManager>(); 
        audioSource = GetComponent<AudioSource>();
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

        if (Input.GetKeyDown(KeyCode.Space) && piesSalto.aux1<1)
        {
            audioSource.PlayOneShot(jumpclip);
            rb.AddForce(new Vector2(0,JumpForce),ForceMode2D.Impulse);
            ChangeAnimation(ANIMATION_SALTAR);
            piesSalto.aux1++;

           
        }

         if (Input.GetKeyDown(KeyCode.Space) && paredSalto.puedeSaltarPared)
        {
           
            rb.AddForce(new Vector2(0,JumpForce),ForceMode2D.Impulse);
            ChangeAnimation(ANIMATION_SALTAR);
           paredSalto.puedeSaltarPared = false;

           
        }
 if (Input.GetKeyDown(KeyCode.Space) && (paredIzquierda.puedeSaltarParedIzquierda) )
        {
           
            rb.AddForce(new Vector2(0,JumpForce),ForceMode2D.Impulse);
            ChangeAnimation(ANIMATION_SALTAR);
           paredIzquierda.puedeSaltarParedIzquierda = false;

           
        }





 if (Input.GetKeyDown(KeyCode.Space) && aux<1)
        {
           
            rb.AddForce(new Vector2(0,JumpForce),ForceMode2D.Impulse);
            ChangeAnimation(ANIMATION_SALTAR);
           aux++;
 
        }

 if (Input.GetKeyDown(KeyCode.L) && gameManager.auxbalas() > 0){

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

     private void ChangeAnimation(int animation)
    {
        animator.SetInteger("Estado0", animation);
       

    }
    private void OnTriggerEnter2D(Collider2D other) {
        
         if(other.gameObject.tag == "fruta"){
        aux=0;
         }

         if(other.gameObject.tag == "techoZombie"){
            velocity = 3;
         }

          if(other.gameObject.tag == "techoZombie2"){ 
            velocity = 5;
         }

          if(other.gameObject.tag == "techoZombie3"){
            velocity = 8;
         }

           if(other.gameObject.tag == "moneda"){
             audioSource.PlayOneShot(coin);
             gameManager.GanarCoin1(1);
             Destroy(other.gameObject);

           
         }

         if(other.gameObject.tag == "municion"){
             audioSource.PlayOneShot(coin);
             gameManager.GanarBala();
             Destroy(other.gameObject);

           
         }
         


    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "zombie"){
           
             gameManager.PerderVida(2);

               aux2++;
            if(aux2 == 2)
            {
                audioSource.PlayOneShot(muerte);
                Time.timeScale = 0;
                
            }
         }


        

         
    }

    
    
      
    




   
   

 
   
}
