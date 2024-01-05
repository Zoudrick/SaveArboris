using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DesactivarHoyo : MonoBehaviour
{
    public Animator animator;

    public AudioSource audio;

    public AudioClip AudioRoca;

    public GameObject Pared;

    public GameObject Piedra;
    private void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Piedra"))
        {
            GameObject piedraGameObject = collision.gameObject; // Obtén directamente el GameObject
            GetComponent<Collider2D>().enabled = false;
            animator.SetBool("Tapado", true);
            audio.PlayOneShot(AudioRoca);
            GameObject.Destroy(Pared); // Destruye el GameObject de la pared
            GameObject.Destroy(piedraGameObject); // Destruye el GameObject de la piedra
        }
    }
}
