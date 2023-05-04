using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
public class final : MonoBehaviour
{
    private GameManager gameManager;
    private moneda contmoneda;
    // Start is called before the first frame update
    void Start()
    {
        contmoneda = FindObjectOfType<moneda>(); 
         gameManager = FindObjectOfType<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter2D(Collider2D other) {
     
         if(other.gameObject.tag == "Player"){

            Debug.Log(gameManager.auxcoin());
           if(gameManager.auxcoin() == 2){
                     SceneManager.LoadScene(0);
                }
           
         }

    }
   
}
