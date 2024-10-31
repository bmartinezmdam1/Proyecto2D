using UnityEngine;
using System.Collections;

public class Enemigo2 : MonoBehaviour
{
    public float cooldownAtaque;
    public float velocidadMovimiento = 1f; // Velocidad de movimiento
    private bool puedeAtacar = true;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    public HUD hud;

    private Vector3 posicionInicial;
    public float distanciaMovimiento = 5f; // Distancia que el enemigo avanza antes de regresar
    private bool moviendoIzquierda = true;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Movimiento constante
        if (moviendoIzquierda)
        {
            transform.position += Vector3.left * velocidadMovimiento * Time.deltaTime;
            if (Vector3.Distance(transform.position, posicionInicial) >= distanciaMovimiento)
            {
                moviendoIzquierda = false;
            }
        }
        else
        {
            transform.position += Vector3.right * velocidadMovimiento * Time.deltaTime;
            if (Vector3.Distance(transform.position, posicionInicial) <= 0.1f)
            {
                moviendoIzquierda = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
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
        if (other.CompareTag("Player"))
        {
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
        Color c = spriteRenderer.color;
        c.a = 1f;
        spriteRenderer.color = c;
    }
    
}
