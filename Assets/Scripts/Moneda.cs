using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public int valor;
    public GameManager gameManager;
    public AudioClip coinSFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.SumarPlatanos(valor);
            Destroy(this.gameObject);
           AudioManager.Instance.ReproducirSonido(coinSFX);
        }

    }
}