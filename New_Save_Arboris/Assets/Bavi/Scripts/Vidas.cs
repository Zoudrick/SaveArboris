using System.Collections;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    public float vidas = 3;
    public bool vulnerable = true;
    public bool movible = true;
    public GameObject enemigo;
    public GameObject Bavi;
    public Vector3 chingadazo;

    public float velocidadMovimiento = 7.0f;
    public Movimiento BaviM;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemigo"))
        {
            if (vulnerable)
            {
                enemigo = collision.gameObject;
                movible = false;
                vidas = vidas - 1;
                vulnerable = false;
                chingadazo = enemigo.transform.position;

                StartCoroutine(chingadazoTime());
            }
            if (BaviM.Tomando)
            {
                BaviM.Tomando = false;
                BaviM.Agarrar = false;
            }
        }
    }

    void FixedUpdate()
    {
        if (!movible)
        {
            Vector3 direccionContraria = Bavi.transform.position - chingadazo;
            Bavi.transform.position += direccionContraria.normalized * velocidadMovimiento * 2 * Time.fixedDeltaTime;
        }
    }

    IEnumerator chingadazoTime()
    {
        yield return new WaitForSeconds(0.2f);
        movible = true;
        yield return new WaitForSeconds(0.4f);
        vulnerable = true;
    }
}