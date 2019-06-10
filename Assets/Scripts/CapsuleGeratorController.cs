using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleGeratorController : MonoBehaviour
{
    public GameObject capsPrefab;
    public float delay = 3.0f;

    private void Start()
    {
        InvokeRepeating("InvokeCaps", delay, delay);
    }

    private void InvokeCaps()
    {
        GameObject caps = Instantiate(capsPrefab);

        caps.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(1, 2), Random.Range(-5, 5));
    }
}