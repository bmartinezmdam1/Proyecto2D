using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestGMController : MonoBehaviour
{
    public void LoadLevel(string nivel)
    {
        SceneManager.LoadScene(nivel);
    }
}
