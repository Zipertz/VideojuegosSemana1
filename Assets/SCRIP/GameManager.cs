using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    public Image imageComponent;
    public Sprite[] players;
    public int currentplayer = 0;
    public GameObject Gpersonaje; 
    public GameObject Gpersonaje2; 

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
        LoadGame();
    }

   public void SaveGame(){
        var filePath = Application.persistentDataPath + "/prueba.dat";
        FileStream file;

        if(File.Exists(filePath))
            file = File.OpenWrite(filePath);
        else    
            file = File.Create(filePath);

        GameData data = new GameData();
        data.Balas = balas;
        data.Lives = lives;
        data.Zombie = zombie;
        data.Coin1=coin1;
        data.Currentplayer = currentplayer;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file,data);
        file.Close();

    }


      public void LoadGame(){
            var filePath = Application.persistentDataPath + "/prueba.dat";
        FileStream file;

        if(File.Exists(filePath)){
            file = File.OpenRead(filePath);
        }
        else    {
            Debug.LogError("No se encontreo archivo");
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        GameData data = (GameData) bf.Deserialize(file);
        file.Close();

        //utilizar los datos guardados
        coin1 = data.Coin1;
        zombie= data.Zombie;
        balas = data.Balas;
        lives = data.Lives;
        currentplayer = data.Currentplayer;
        PrintScreenLives();
        PrintScreenCoin1();
        PrintScreenEnemigo();
        PrintScreenBalas();
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

  public int Personajes(){
    return currentplayer;
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



//Personajes camnbio
public void siguientePersonaje() {
        if (currentplayer == 1 ) {
            currentplayer = 0;
        } else {
            currentplayer++;
        }
        cambiarPersonaje();
    }
    public void anterioirPersonaje() {
        if (currentplayer == 0 ) {
            currentplayer = 1;
        } else {
            currentplayer--;
        }
        cambiarPersonaje();
    }

    public void cambiarPersonaje() {
        imageComponent.sprite = players[currentplayer];
    }

    public void seleccionarPersonaje() {

      SaveGame();
      SceneManager.LoadScene(2);
      
    }


 
   

        
}
