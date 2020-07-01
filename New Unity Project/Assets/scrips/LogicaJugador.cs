using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicaJugador : MonoBehaviour {
    public VidaJugador VidaJugador;
    public GameObject GameOver; 
    public bool VidaJugador0 = false;
    [SerializeField] private Animator animadorPerder;

	// Use this for initialization
	void Start () {
        VidaJugador = GetComponent<VidaJugador>();
	}
	
	// Update is called once per frame
	void Update () {
        RevisarVida();

        GameObject theBar = GameObject.Find ("Canvas/HPFondo/HPBar");
          var theBarRectTransform = theBar.transform as RectTransform;
          theBarRectTransform.sizeDelta = new Vector2 (VidaJugador.valor, theBarRectTransform.sizeDelta.y);

	}

    void RevisarVida()
    {
        if (VidaJugador0) return;
        if(VidaJugador.valor <= 0)
        {
            GameOver.SetActive(true);
            VidaJugador0 = true;
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            //Invoke("ReiniciarJuego", 5f * Time.unscaledDeltaTime);
        }
    }

    void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

   
}
