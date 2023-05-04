using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
     public Text livesText ;
     public Text MonedaText ;
     public Text EnemigoText ;
     public Text BalasText ;

     private int lives;
     private int coin1;

      private int balas;

       private int zombie;

     AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
         lives=2;
         coin1=0;
         balas=15;
         zombie=0;
          audioSource = GetComponent<AudioSource>();
        PrintScreenCoin1();
     
        PrintScreenLives();

        
        PrintScreenEnemigo();

        
        PrintScreenBalas();
        PrintSPerderBalas();
    }
   public int auxbalas(){
     return balas;
   }

   public int auxcoin(){
     return coin1;
   }

   public int auxlive(){
     return lives;
   }

   public int auxzombie(){
   return zombie;
   }

    // Update is called once per frame
    //  public int Lives(){

    //     return lives;

    // }
    
    //  public int Coins1(){

    //     return coin1;

    // }
    public void GanarCoin1(int coins1){
    coin1 += coins1;
    PrintScreenCoin1();
   }

     public void GanarEnemigo(int enemigo){
    zombie += enemigo;
    PrintScreenEnemigo();
   }

      public void GanarBala(){
     balas = balas+5;
    PrintScreenBalas();
   }

 public void perderBala(){
     this.balas-=1;
     PrintSPerderBalas();
    
    }
   public void PerderVida(int lives){

    this.lives -=1;
    PrintScreenLives();
    if (this.lives==0){
     audioSource.Stop();
    }
    

   }
     private void PrintScreenLives(){
        livesText.text = "Vida: " + lives   ;

   }

   
    private void PrintScreenCoin1(){
        MonedaText.text = "Llave: " + coin1;

   }


    private void  PrintScreenEnemigo(){
        EnemigoText.text = "puntos: " + zombie;

   }
     
 private void  PrintScreenBalas(){
        BalasText.text = "Balas: " + balas;

   }
         private void  PrintSPerderBalas(){
        BalasText.text = "Balas: "+ balas;

   }



        
}
