using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    private void Start()
    {
        // destruir a capsula automaticamente, caso nao coletada
        Destroy(gameObject, 5.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        // se a capsula sofrer uma colisao com o personagem do jogador...
        if (other.CompareTag("Player"))
        {
            // a pontuacao ira aumentar...
            FabricioController.points++;
            // e a capsula sera destruida
            Destroy(gameObject);
        }
    }
}