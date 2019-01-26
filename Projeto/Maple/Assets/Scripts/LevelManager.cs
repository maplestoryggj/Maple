using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [Header("GameOjects para instanciar")]
    public Transform[] arvores;
    public Transform[] pedras;
    public Transform background;

    [Header("Posições para instanciar")]
    public Vector2 bgPosition = Vector2.zero;

    private Transform playerTransform;
    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        myTransform = GetComponent<Transform>();
        Debug.Log(playerTransform.position);

        GerarBG(2);
    }

    void GerarFase()
    {
        /*for (int i = 0; i < n; i++)
        {
            Instantiate(environments[GetRandomIndex(environmentsCount)], new Vector3(xStartPosition, 0, 0), Quaternion.identity);
            xStartPosition += xPlusPosition;
        }*/

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GerarBG(1);
        }

        ChangeMyPosition();
    }

    private void ChangeMyPosition()
    {
        myTransform.position = new Vector3(myTransform.position.x + 18f, 0, 0);
    }
    private void GerarBG(int q)
    {
        for(int i = 0; i < q; i++)
        {
            Instantiate(background, bgPosition, Quaternion.identity);
            bgPosition = new Vector2(bgPosition.x+18, 0);
        }
    }
}
