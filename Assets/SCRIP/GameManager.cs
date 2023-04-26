using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
     public Text livesText ;
     public Text MonedaText ;

     private int lives;
     private int coin1;
    // Start is called before the first frame update
    void Start()
    {
         lives=3;
         coin1=0;

        PrintScreenCoin1();
     
        PrintScreenLives();
    }

    // Update is called once per frame
    //  public int Lives(){

    //     return lives;

    // }
    
    //  public int Coins1(){

    //     return coin1;

    // }
    public void GanarCoin1(int moneda1){
    coin1 += moneda1;
    PrintScreenCoin1();
   }
   public void PerderVida(int lives){

    this.lives -=1;
    PrintScreenLives();
    

   }
     private void PrintScreenLives(){
        livesText.text = "Vida: " + lives   ;

   }

   
    private void PrintScreenCoin1(){
        MonedaText.text = "Moneda: " + coin1;

   }
}
