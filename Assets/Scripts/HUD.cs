using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HUD : MonoBehaviour
{
    public void Start()
    {
        if (GameManager.Instance != null)
        {
            ActualizarPlatanos(GameManager.Instance.platanosTotales);
        }
    }
    public TextMeshProUGUI platanos;
    public GameObject[] vidas;

    public void Update()
    {
        platanos.text = GameManager.Instance.platanosTotales.ToString();
    }

    public void ActualizarPlatanos(int platanosTotales)
    {
        platanos.text = platanosTotales.ToString();
    }
    public int getPlatanos(int platanosTotales)
    {
        return platanosTotales;
    }

    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }
    public void DesactivarTodasVidas()
    {
        vidas[0].SetActive(false);
        vidas[1].SetActive(false);
        vidas[2].SetActive(false);
    }

}