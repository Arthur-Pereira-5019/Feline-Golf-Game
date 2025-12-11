using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int par;
    public int tacadas;
    public int pontuacao;

    public Canvas canvaPadrao;
    public Canvas canvaFinal;

    public TextMeshPro recorde;
    public TextMeshPro pontuacaoTexto;
    public TextMeshPro passaro;

    public Vector3 lastPos;

    public static GameManager gm;

    GameObject player;


    public int mapa;
    void Start()
    {
        canvaPadrao.enabled = true;
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {

    }

    public void tacada()
    {
        tacadas++;
        pontuacao = tacadas - par;
        lastPos = player.transform.position;
    }

    public void finalizarPartida()
    {
        if (PlayerPrefs.GetInt("recorde" + mapa, 100000) > pontuacao)
        {
            PlayerPrefs.SetInt("recorde" + mapa, pontuacao);
        }
        canvaPadrao.enabled = false;
        canvaFinal.enabled = true;
        String p = "";

        switch (pontuacao)
        {
            case -3:
                p = "Albatross";
                passaro.color = new Color32(0, 249, 255, 0);
                break;
            case -2:
                p = "Eagle";
                passaro.color = new Color32(0, 199, 45, 0);
                break;
            case -1:
                p = "Birdie";
                passaro.color = new Color32(175, 255, 0, 0);
                break;
            case 0:
                p = "Par";
                passaro.color = new Color32(255, 254, 0, 0);
                break;
            case 1:
                p = "Bogey";
                passaro.color = new Color32(255, 186, 0, 0);
                break;
            case 2:
                p = "Double Bogey";
                passaro.color = new Color32(255, 109, 0, 0);
                break;
            case 3:
                p = "Triple Bogey";
                passaro.color = new Color32(255, 0, 0, 0);
                break;
        }
        passaro.text = p;

    }

    public void subirFase()
    {
        int proximo = mapa + 1;
        SceneManager.LoadScene("nivel" + proximo);
    }
}
