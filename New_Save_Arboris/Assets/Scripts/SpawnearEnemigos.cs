using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnearEnemigos : MonoBehaviour
{
    [SerializeField] private GameObject Bichitio;
    [SerializeField] private float tiempodesalida = 3.5f;

    public GameObject hormiguero;
    private void Start()
    {
        StartCoroutine(SpawnerEnemigo(tiempodesalida, Bichitio));
    }

    private IEnumerator SpawnerEnemigo(float Intervalo, GameObject Enemigo)
    {
        yield return new WaitForSeconds(Intervalo);

        // Obtén la posición del objeto actual
        Vector3 spawnPosition = hormiguero.transform.position;
        // Crea el NuevoEnemigo en la posición del objeto actual
        GameObject NuevoEnemigo = Instantiate(Enemigo, spawnPosition, Quaternion.identity);
        StartCoroutine(SpawnerEnemigo(Intervalo, Enemigo));
    }
}
