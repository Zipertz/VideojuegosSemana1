using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
public class final : MonoBehaviour
{
    private GameManager gameManager;
    private moneda contmoneda;

    private bool botonPaso = false;
    // Start is called before the first frame update
    void Start()
    {
        contmoneda = FindObjectOfType<moneda>(); 
         gameManager = FindObjectOfType<GameManager>(); 
    }
    void update(){
        botonApagado();
    }

    public void botonPrendido(){
        botonPaso = true;
    }

    public void botonApagado(){
        botonPaso = false;
    }

private void OnCollisionEnter2D(Collision2D other) {
     if(other.gameObject.tag == "Player"){

            Debug.Log(gameManager.auxcoin());
            Debug.Log(botonPaso);
           if(gameManager.auxcoin() == 1 && gameManager.auxzombie() == 3 && botonPaso == true ){
            
                 SceneManager.LoadScene(0);
            }    
                
           
         }


}
    

}