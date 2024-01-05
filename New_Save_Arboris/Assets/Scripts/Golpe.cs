using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe : MonoBehaviour
{
    public GameObject golpeado;

    public AudioClip GolpeBasura;
    public AudioClip GolpeEnemigo;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Basura"))
        {
            ControladorSonido.Instance.EjecutarSonido(GolpeBasura);
            golpeado = other.gameObject;
            Destroy(golpeado);
            golpeado = GameObject.Find("Vacio");
        }

        if (other.CompareTag("Enemigo"))
        {
            ControladorSonido.Instance.EjecutarSonido(GolpeEnemigo);
            golpeado = other.gameObject;
            Destroy(golpeado);
            golpeado = GameObject.Find("Vacio");
        }
    }
}
