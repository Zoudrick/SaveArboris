using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.EventSystems.EventTrigger;

public class Coco : MonoBehaviour
{
    public bool posibleDisparo = true;
    public Tomarcosas tomar;

    public Movimiento BaviM;
    public Tomarcosas tomandoCosas;

    Vector3 Disparo;
    public GameObject coco;
    public GameObject agua;
    public GameObject chorro;

    public bool CocoTomado = false;

    public bool solito = false;
    void Start()
    {
        Disparo = (BaviM.centro.transform.position - BaviM.mira.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(BaviM.Tomando == false)
        {
            CocoTomado = false;
        }
        if (BaviM.Tomando && posibleDisparo && tomandoCosas.Coco)
        {
            if (tomandoCosas.Coco)
            {
                Disparo = (BaviM.centro.transform.position - BaviM.mira.transform.position);
            }
        }
        if (Gamepad.current.buttonSouth.wasPressedThisFrame && posibleDisparo)
        {   
            chorro = Instantiate(agua);
            chorro.transform.position = coco.transform.position - (Disparo/1.5f);
            StartCoroutine(Disparando());
        }
        if (posibleDisparo == false)
        {
            chorro.transform.position += Disparo * Time.deltaTime * -9.0f;
        }

        if (solito && posibleDisparo)
        {
            StartCoroutine(DisparoSolito());
        }
    }
    IEnumerator Disparando()
    {
        posibleDisparo = false;
        yield return new WaitForSeconds(0.35f);
        chorro.SetActive(false);
        posibleDisparo = true;
    }
    IEnumerator DisparoSolito()
    {
        posibleDisparo = false;
        chorro = Instantiate(agua);
        chorro.transform.position = coco.transform.position - (Disparo / 1.5f);
        StartCoroutine(Disparando());
        chorro.transform.position += Disparo * Time.deltaTime * -9.0f;
        yield return new WaitForSeconds(1);
        posibleDisparo = true;
    }
}