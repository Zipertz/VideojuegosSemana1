using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarPlayer : MonoBehaviour
{

    public GameObject Gpersonaje; 
    public GameObject Gpersonaje2; 

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>(); 
         if(gameManager.Personajes() == 1){
      var shieldPosition = transform.position + new Vector3(2,0,0);
                var gb = Instantiate(Gpersonaje,
                                 shieldPosition,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<PLAYERCA>();
  }

  if(gameManager.Personajes() == 0){

    var shieldPosition1 = transform.position + new Vector3(2,0,0);
                var gb = Instantiate(Gpersonaje2,
                                 shieldPosition1,
                                 Quaternion.identity) as GameObject;
                var controller =gb.GetComponent<PLAYERCA>();

  }
        
    }

}
