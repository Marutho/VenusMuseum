using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab_WinCondition : MonoBehaviour
{
    public bool winCondition;
    public GameObject vasoMedio;
    public GameObject vasoLleno;
    public GameObject vasoVacio;

    public float metaPuntos;
    public float puntosActuales;

    public bool purpleType = false;
    public bool greenType = false;
    // Start is called before the first frame update
    void Start()
    {
        vasoVacio.SetActive(true);
        vasoMedio.SetActive(false);
        vasoLleno.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(puntosActuales==0.5f)
        {
            vasoVacio.SetActive(false);
            vasoMedio.SetActive(true);
        }
        else if (puntosActuales>=metaPuntos)
        {
            vasoMedio.SetActive(false);
            vasoLleno.SetActive(true);
            winCondition = true;
        }
    }
}
