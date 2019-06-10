using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FabricioController : MonoBehaviour
{
    #region Variables

    public float velActual;
    public float velMax = 5.0f;
    public float velRot = 130.0f;
    public float xrl8I = 0.2f;
    public float xrl8 = 0.1f;
    public float dxrl8 = 0.07f;

    public Text txtPoint;
    public static float points;

    public GameObject portalPrefab;

    private Animator anime;

    #endregion Variables

    private void Start()
    {
        points = 0.0f;

        anime = GetComponent<Animator>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 rotationBody = (Vector3.up * h * velRot * Time.deltaTime);

        float v = Input.GetAxisRaw("Vertical");

        if (v > 0 && velActual < velMax)
        {
            velActual += (velActual == 0) ? xrl8I : xrl8;
        }
        else if (v == 0 & velActual > 0)
        {
            velActual -= dxrl8;
        }

        velActual = Mathf.Clamp(velActual, 0, velMax);

        if (velActual > 0)
        {
            transform.Rotate(rotationBody);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * velActual);

        float animF = Mathf.Clamp(velActual / velMax, 0, 1);
        anime.SetFloat("speed", animF);

        txtPoint.text = points.ToString();

        if (points == 5)
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