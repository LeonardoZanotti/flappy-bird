using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamecontroller : MonoBehaviour
{   
    public int score;
    public Text scoretext;
    
    // chamado uma vez ao iniciar o jogo
    void Start() {      // quando apertar o botão
        Time.timeScale = 1;     // tempo volta a escala normal de 1 segundo por segundo
    }

    public void RestartGame() {     // botão de reiniciar o game
        SceneManager.LoadScene(0);      // carrega a cena 0 -> só há uma cena no game que fica na posição 0
    }
}
