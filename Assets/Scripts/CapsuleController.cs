using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FabricioController.points++;
            Destroy(gameObject);
        }
    }
}