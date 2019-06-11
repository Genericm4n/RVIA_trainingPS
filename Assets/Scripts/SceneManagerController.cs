using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{
    private void Start()
    {
        // iniciar um coroutine que carregara a cena inicial apos 2 segundos
        StartCoroutine("LoadScene");
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2.0f);

        // carregar a proxima cena
        SceneManager.LoadScene("_A");
    }
}