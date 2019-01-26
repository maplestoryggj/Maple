using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [Header("GameOjects para instanciar")]
    public Transform[] arvores;
    public Transform[] pedras;
    public Transform background;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        Debug.Log(playerTransform.position);

        GerarFase();
    }

    void GerarFase()
    {


    }
}
