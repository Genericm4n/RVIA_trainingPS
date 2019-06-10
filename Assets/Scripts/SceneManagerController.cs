using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("LoadScene");
    }

    private IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2.0f);

        SceneManager.LoadScene("_A");
    }
}