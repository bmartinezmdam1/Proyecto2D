using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public HUD hud;

    public int platanosTotales { get; private set; }

    private int vidas = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void SumarPlatanos(int platanosSumar)
    {
        platanosTotales += platanosSumar;
//        hud.ActualizarPlatanos(platanosTotales);
    }

    public void PerderVida()
    {
        vidas -= 1;

        if (vidas == 0)
        {
            // Reiniciamos el nivel.
            SceneManager.LoadScene(1);
        }

        hud.DesactivarVida(vidas);
    }

    public void PerderVidaFondo()
    {
        vidas = 0;
        hud.DesactivarVida(vidas);
        SceneManager.LoadScene(1);
    }
}