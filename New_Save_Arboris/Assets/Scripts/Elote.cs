using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Elote : MonoBehaviour
{
    public bool posibleBomba = true;

    public Movimiento BaviM;
    public Tomarcosas tomandoCosas;

    Vector3 Disparo;
    public GameObject elote;
    public GameObject Maicito;
    public GameObject Bomba;
    public GameObject Maiz;
    void Start()
    {
        Disparo = (BaviM.centro.transform.position - BaviM.mira.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (BaviM.Tomando && posibleBomba)
        {
            Disparo = (BaviM.centro.transform.position - BaviM.mira.transform.position);
        }

        if (Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            if (posibleBomba == false)
            {
                Debug.Log("Explota");
                if (Bomba != null)
                {
                    // Destruir el objeto "Bomba" inmediatamente
                    Destroy(Bomba);
                    StartCoroutine(Recargar());
                }
            }
            else if(posibleBomba)
            {
                {
                    Bomba = Instantiate(Maicito);
                    Bomba.transform.position = elote.transform.position - (Disparo / 1.5f);
                    posibleBomba = false;
                }
            }
        }
    }
    IEnumerator Recargar()
    {
        yield return new WaitForSeconds(2f);
        posibleBomba = true;
        Debug.Log("Recargó");
    }
}
