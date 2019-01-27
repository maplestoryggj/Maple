using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [Header("GameOjects para instanciar")]
    public Transform[] arvores;
    public Transform[] pedras;
    public Transform background;
    public float xStartPosition;
    public float xPlusPosition;

    [Header("Posições para instanciar")]
    public Vector2 bgPosition = Vector2.zero;
    private List<Transform> bgs = new List<Transform>();

    private Transform playerTransform;
    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        myTransform = GetComponent<Transform>();
        Debug.Log(playerTransform.position);

        GerarBG(4);
    }

    void GerarFase()
    {
        int numArv = GetRandomIndex(5);
        for (int i = 0; i < numArv; i++)
        {
            Instantiate(arvores[GetRandomIndex(arvores.Length)], new Vector3(xStartPosition, 0, 0), Quaternion.identity);
            xStartPosition += xPlusPosition;
        }

    }

    int GetRandomIndex(int n)
    {
        return Random.Range(1, n);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(bgs[0].gameObject);
            bgs.RemoveAt(0);
            GerarBG(1);
            ChangeMyPosition();

        }
    }

    private void ChangeMyPosition()
    {
        myTransform.position = new Vector3(myTransform.position.x + 18f, 0, 0);
    }
    private void GerarBG(int q)
    {
        for(int i = 0; i < q; i++)
        {//lista de e sempre tirar o primeiro
            bgs.Add(Instantiate(background, bgPosition, Quaternion.identity));
            bgPosition = new Vector2(bgPosition.x+18, 0);
        }
    }
}
