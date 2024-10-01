using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fondoMapa : MonoBehaviour
{
    public HUD hud;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            // Perdemos una vida.
            GameManager.Instance.PerderVidaFondo();
            hud.DesactivarTodasVidas();

            // Aplicamos golpe al personaje.
        }
    }
}
