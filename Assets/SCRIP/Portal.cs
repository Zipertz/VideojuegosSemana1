using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
     Rigidbody2D rb;
     SpriteRenderer sr;
    Animator animator;
    public GameObject zombie;
    private float tiempoEnemigo =3f;
    private float tiempoultimo = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
      

    }

    // Update is called once per frame
    void Update()
    {
       tiempoultimo += Time.deltaTime;
       if(tiempoultimo >= tiempoEnemigo)
       {
        tiempoultimo = 0f;
        Instantiate(zombie, transform.position, Quaternion.identity);
       }
       
    }

}
