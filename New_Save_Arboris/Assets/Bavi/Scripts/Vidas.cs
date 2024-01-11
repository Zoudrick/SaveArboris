using System.Collections;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    public HUD hud;

    public int vidas = 2;
    public int limite = 3;
    public bool vulnerable = true;
    public bool movible = true;
    public GameObject enemigo;
    public GameObject Bavi;

    public GameObject comida;

    public Vector3 chingadazo;

    public float velocidadMovimiento = 7.0f;
    public Movimiento BaviM;

    private void Start()
    {
        hud.DesactivarVidas(2);
        hud.DesactivarVidas(4);
        hud.DesactivarVidas(3);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemigo"))
        {
            if (vulnerable)
            {
                enemigo = collision.gameObject;
                movible = false;
                vidas = vidas - 1;
                hud.DesactivarVidas(vidas);
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
        if (collision.collider.CompareTag("Composta"))
        {
            vidas = vidas + 1;
            if(vidas > limite)
            {
                vidas = limite;
            }
            hud.ActivarVidas(vidas-1);
            comida = collision.collider.gameObject;
            Destroy(comida);
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