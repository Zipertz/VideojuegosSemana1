using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneda : MonoBehaviour
{
    public int auxlvl = 0;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     private void OnTriggerEnter2D(Collider2D other) {
        
        

           if(other.gameObject.tag == "Player"){
             auxlvl++;
             gameManager.GanarCoin1(1);
             Destroy(this.gameObject);

           
         }

         if(other.gameObject.tag == "municion"){
             
             gameManager.GanarBala();
             Destroy(other.gameObject);

           
         }
         


    }
}
