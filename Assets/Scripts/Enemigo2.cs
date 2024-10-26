using UnityEngine;
using System.Collections;

public class Enemigo2 : MonoBehaviour
{
    public float cooldownAtaque;
    public float velocidadMovimiento = 1f; // Velocidad de movimiento hacia la izquierda
    private bool puedeAtacar = true;
    private SpriteRenderer spriteRenderer;
    AudioSource audioSource;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Movimiento constante hacia la izquierda
        transform.position += Vector3.left * velocidadMovimiento * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            if (!puedeAtacar) return;
            Animator animator = GetComponent<Animator>();

            puedeAtacar = false;
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;

            GameManager.Instance.PerderVida();
            other.gameObject.GetComponent<CharacterController>().AplicarGolpe();

            Invoke("ReactivarAtaque", cooldownAtaque);
        }
    }

    void ReactivarAtaque()
    {
        Animator animator = GetComponent<Animator>();

        puedeAtacar = true;
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
    }
}
