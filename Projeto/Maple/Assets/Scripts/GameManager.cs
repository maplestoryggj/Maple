using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("About the Player")]
    public PlayerAtrib playerAtrib;

    [Header("About the PlayButton")]
    public Animator playButtonAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAtrib.XForce = 100;
        playerAtrib.YForce = 50;
        playerAtrib.CanMove = false; // Não deixa você controlar o player
    }


    public void StartGame()
    {
        playButtonAnim.SetBool("Clicked", true); // Anima o botão

        //Mostra a animação inicial

        // Chama corroutina e depois chama a animação para ensinar a mover

        playerAtrib.CanMove = true; // Pode controlar o player


    }
}
