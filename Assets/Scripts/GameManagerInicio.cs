using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerInicio : MonoBehaviour
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

    public void CambiarEscena(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }

    public void CerrarAplicacion()
    {
        // En Unity, usamos Application.Quit() para cerrar la aplicación.
        Application.Quit();
    }

    // Este método no es necesario en Unity, ya que no hay un "RoutedEventArgs"
    private void M_Salir_Click()
    {
        CerrarAplicacion();
    }
}
