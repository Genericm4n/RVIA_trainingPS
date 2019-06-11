using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleGeratorController : MonoBehaviour
{
    public GameObject capsPrefab;       // prefab correspondente a capsula que sera coletada pelo jogador
    public float delay = 3.0f;          // intervalo de tempo em que sera instanciada uma nova capsula

    private void Start()
    {
        //InvokeRepeating que chamara um metodo que instanciara as capsulas em um determinado intervalo de tempo
        InvokeRepeating("InvokeCaps", delay, delay);
    }

    private void InvokeCaps()
    {
        // criar uma variavel GameObject que instanciara a capsula
        GameObject caps = Instantiate(capsPrefab);
        // usar o transform.position dessa variavel para instanciar as capsulas em um local aleatorio do cenario
        caps.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(1, 2), Random.Range(-5, 5));
    }
}