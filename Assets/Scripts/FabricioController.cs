using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FabricioController : MonoBehaviour
{
    #region Variables

    public float velActual;             // velocidade atual do personagem
    public float velMax = 5.0f;         // velocidade maxima permitida ao personagem
    public float velRot = 130.0f;       // velocidade de rotacao do personagem
    public float xrl8I = 0.2f;          // aceleracao inicial do personagem, quando este ainda nao se deslocou
    public float xrl8 = 0.1f;           // aceleracao definitiva do personagem, ao ter o seu deslocamento iniciado
    public float dxrl8 = 0.07f;         // desaceleracao para reduzir a velocidade de deslocamento e parar o personagem

    public Text txtPoint;               // Text que corresponde ao texto relativo a pontuacao
    public static float points;         // variavel que sofrera alteracoes quando coletado uma nova capsula

    public GameObject portalPrefab;     // prefab do portal que redicionara o usuario para a a outra tela

    private Animator anime;             // variavel que chamara o componente Animator do personagem

    #endregion Variables

    private void Start()
    {
        // pontuacao inicial todo vez que a cena for inicializada
        points = 0.0f;

        // chamando o componente Animator do personagem
        anime = GetComponent<Animator>();
    }

    private void Update()
    {
        // movimentacao do personagem - rotacao: pt1_definindo o input
        float h = Input.GetAxisRaw("Horizontal");

        // movimentacao do personagem - rotacao: pt2_configurando a rotacao e sua velocidade
        Vector3 rotationBody = (Vector3.up * h * velRot * Time.deltaTime);

        // movimentacao do personagem - deslocamento: pt1_definindo o input
        float v = Input.GetAxisRaw("Vertical");

        // movimentacao do personagem - deslocamento: pt2_configuracao

        // se o valor do input Vertical for maior que 0, e o personagem ainda nao estiver se mexendo, ou seja, se a velocidade atual e menor que a maxima...
        if (v > 0 && velActual < velMax)
        {
            // a velocidade atual, se igual a 0, recebera um acrescimo correspondente a sua aceleracao inicial, e assim que deixar de ser nulo, recebera o valor da aceleracao definitiva
            velActual += (velActual == 0) ? xrl8I : xrl8;
        }
        // caso o valor do input Vertical for igual a 0, ou seja, o botao deixar de ser pressionado, e a velocidade atual ser maior que 0, pelo personagem ainda estar se deslocando...
        else if (v == 0 && velActual > 0)
        {
            // a velocidade atual comecara a diminuir conforme o valor da desaceleracao, fazendo com que o personagem pare de se deslocar
            velActual -= dxrl8;
        }

        // definicao do valor minimo e maximo que a velocidade atual pode atingir
        velActual = Mathf.Clamp(velActual, 0, velMax);

        // movimentacao do personagem - rotacao: pt3_associar a rotacao ao deslocamento, apenas
        if (velActual > 0)
        {
            transform.Rotate(rotationBody);
        }

        // fazer com que o personagem se desloque de fato, aplicando um Vector3.foward + a velocidade atual no transform.Translate do objeto
        transform.Translate(Vector3.forward * Time.deltaTime * velActual);

        // movimentacao do personagem - animacoes: ptUnica_criando uma variavel float que sera responsavel pelo controle da velocidade em que o parametro Blendtree alterara seus valores...
        float animF = Mathf.Clamp(velActual / velMax, 0, 1);
        // SetFloat associdado o parametro encarregado das animacoes e variavel float
        anime.SetFloat("speed", animF);

        // criacao da pontucacao - associar o objeto Text com a variavel da pontuacao, convertendo-a para texto
        txtPoint.text = points.ToString();

        // se a pontuacao atingir o valor minimo de 5...
        if (points == 5)
        {
            // o portal, antes invisivel na cena por estar inativo, sera ativado
            portalPrefab.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision c)
    {
        // detectando colisao com  o portal...
        if (c.collider.CompareTag("Portal"))
        {
            // para redirecionar quem joga para um nova cena
            SceneManager.LoadScene("_B");
        }
    }
}