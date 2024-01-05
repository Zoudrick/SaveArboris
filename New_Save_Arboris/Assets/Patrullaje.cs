using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    [SerializeField] private float VelocidadMovimiento;

    [SerializeField] private Transform[] puntosdemovimiento;

    [SerializeField] private float distanciaminima;

    private int numeroAleatorio;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        numeroAleatorio = Random.Range(0, puntosdemovimiento.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, puntosdemovimiento[numeroAleatorio].position, VelocidadMovimiento * Time.deltaTime);

        if (Vector2.Distance(transform.position, puntosdemovimiento[numeroAleatorio].position) < distanciaminima)
        {
            numeroAleatorio = Random.Range(0, puntosdemovimiento.Length);
            Girar();
        }
    }


    private void Girar()
    {
        if (transform.position.x < puntosdemovimiento[numeroAleatorio].position.x)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }




}
