using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject[] Vidas;

    public void ActivarVidas(int n)
    {
        Vidas[n].SetActive(true);
    }

    public void DesactivarVidas(int n)
    {
        Vidas[n].SetActive(false);
    }
}
