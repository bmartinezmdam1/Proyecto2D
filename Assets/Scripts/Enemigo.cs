using UnityEngine;
using System.Collections;

public class Enemigo : MonoBehaviour
{
    public float cooldownAtaque;
    private bool puedeAtacar = true;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    public HUD hud;
    private bool colisionManejada = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (colisionManejada) return;
        if (other.gameObject.CompareTag("Player"))
        {
            colisionManejada = true;
            audioSource.Play();
            if (!puedeAtacar) return;
            Animator animator = GetComponent<Animator>();
            animator.SetBool("Collision", true);
            puedeAtacar = false;
            Color color = spriteRenderer.color;
            color.a = 0.5f;
            spriteRenderer.color = color;
            GameManager.Instance.PerderVida();
            other.gameObject.GetComponent<CharacterController>().AplicarGolpe();
            Invoke("ReactivarAtaque", cooldownAtaque);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (colisionManejada) return;
        if (other.CompareTag("Player"))
        {
            colisionManejada = true;
            audioSource.Play();
            if (!puedeAtacar) return;
            Animator animator = GetComponent<Animator>();
            animator.SetBool("Collision", true);
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
        animator.SetBool("Collision", false);
        puedeAtacar = true;
        colisionManejada = false; // Resetear la bandera para la próxima colisión
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
    }
}
