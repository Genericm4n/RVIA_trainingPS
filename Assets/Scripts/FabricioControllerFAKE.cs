using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FabricioControllerFAKE : MonoBehaviour
{
    #region VARIAVEIS

    public float velAtual;
    public float velMaxima = 6.0f;
    public float velRotacao = 120.0f;
    public float aceleracaoInicial = 0.2f;
    public float aceleracao = 0.3f;
    public float desaceleracao = 0.07f;

    public Animator anime;

    public Text txtPonto;
    public float pontos;

    public GameObject portalPrefab;

    #endregion VARIAVEIS

    private void Start()
    {
        pontos = 0f;

        anime = GetComponent<Animator>();
    }

    private void Update()
    {
        float hori = Input.GetAxisRaw("Horizontal");

        Vector3 rotacaoCorpo = (Vector3.up * hori * velRotacao * Time.deltaTime);

        float vert = Input.GetAxisRaw("Vertical");

        if (vert > 0 && velAtual < velMaxima)
        {
            velAtual += (velAtual == 0) ? aceleracaoInicial : aceleracao;
        }
        else if (vert == 0 && velAtual > 0)
        {
            velAtual -= desaceleracao;
        }

        velAtual = Mathf.Clamp(velAtual, 0, velMaxima);

        if (velAtual > 0)
        {
            transform.Rotate(rotacaoCorpo);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * velAtual);

        float paramVelocidade = Mathf.Clamp(velAtual / velMaxima, 0, 1);
        anime.SetFloat("speed", paramVelocidade);

        txtPonto.text = pontos.ToString();

        if (pontos == 5)
        {
            portalPrefab.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        if (c.collider.CompareTag("Portal"))
        {
            SceneManager.LoadScene("_B");
        }
    }
}