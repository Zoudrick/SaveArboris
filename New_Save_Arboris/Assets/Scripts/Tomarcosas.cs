using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tomarcosas : MonoBehaviour
{
    public bool Tomable = false;
    public Movimiento BaviM;
    public Piedra piedrita;
    public bool acercar = true;
    public bool Coco = false;

    public GameObject sujetable;

    Renderer rendererSujetable;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Piedra") || other.CompareTag("Maceta") || other.CompareTag("Coco"))
        {
            if (BaviM.Tomando == false)
            {
                Tomable = true;
                sujetable = other.gameObject;
                rendererSujetable = sujetable.GetComponent<Renderer>();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Piedra") || other.CompareTag("Maceta") || other.CompareTag("Coco"))
        {
            StartCoroutine(TriggerTime());
        }
    }

    private void Update()
    {
        Collider2D colliderSujetable = (sujetable != null) ? sujetable.GetComponent<Collider2D>() : null;



        if (BaviM.Agarrar)
        {
            sujetable.transform.position = transform.position;
            sujetable.transform.position = sujetable.transform.position + Vector3.up * 0.2f;

            if (sujetable.tag.Equals("Coco"))
            {
                Coco = true;
            }
                if (acercar)
            {    
                if (rendererSujetable != null)
                {
                    rendererSujetable.sortingOrder = 6;
                }
            }
            else
            {
                rendererSujetable.sortingOrder = 4;
            }

            BaviM.Tomando = true;

            if (colliderSujetable != null)
            {
                colliderSujetable.enabled = false;
            }
        }
        else
        {
            BaviM.Tomando = false;
            Coco = false;
            if (colliderSujetable != null)
            {
                colliderSujetable.enabled = true;
                rendererSujetable.sortingOrder = 4;
            }
        }
    }

    IEnumerator TriggerTime()
    {
        yield return new WaitForSeconds(0.1f);
        if (Tomable)
        {
            Tomable = false;
            Coco = false;
            Debug.Log("Intomable");
        }
    }
}
