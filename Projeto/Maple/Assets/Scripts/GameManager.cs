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
        playerAtrib.CanMove = true;
    }


    public void StartGame()
    {
        //playButtonAnim.SetBool(); // Anima o botão

        //Mostra a animação inicial

    }
}
