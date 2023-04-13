using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiesSalto : MonoBehaviour
{
    public bool puedeSaltar=false;
    public int aux1=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


private void OnCollisionEnter2D(Collision2D other) {
     if(other.gameObject.tag == "Piso"){
        aux1=0;
         }

     
}
 

}
