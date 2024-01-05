using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piedra : MonoBehaviour
{
    public Movimiento BaviM;
    public Tomarcosas tomar;
    public GameObject piedra;

    public Rigidbody2D masa;

    public bool disponible = false;
    void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.collider.CompareTag("Bavi"))
        {
            disponible = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hoyo"))
        {
            // Desactivar colisiones del objeto actual
            tomar.sujetable = GameObject.Find("Vacio");
            BaviM.Agarrar = false;
            GameObject.Destroy(piedra);
        }
    }
}