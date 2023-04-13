using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedIzquierda : MonoBehaviour
{
    public bool puedeSaltarParedIzquierda=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.tag == "Pared"){
        puedeSaltarParedIzquierda = true;
         }
}
}
