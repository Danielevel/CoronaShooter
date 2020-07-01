using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public static bool GameIsOver = false;

    public GameObject OverMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        Cursor.lockState = CursorLockMode.None;
        OverMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsOver = false;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = true;
        OverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsOver = true;
        
    }
    public void LoadMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1f;
        OverMenuUI.SetActive(false);
        GameIsOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    public void cerrarJuego()
    {
        Application.Quit();
        Debug.Log("Se precionó el botón cerrar");
    }
    
}
