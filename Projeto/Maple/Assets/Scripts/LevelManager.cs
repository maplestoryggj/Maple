using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [Header("GameOjects para instanciar")]
    public Transform[] arvores;
    public Transform[] pedras;
    public Transform grama;
    public Transform background;
    private float xStartPosition;
    public float xPlusPosition = 2f;
    public int numArv = 9;

    [Header("Posições para instanciar")]
    public Vector2 bgPosition = Vector2.zero;
    private List<Transform> bgs = new List<Transform>();

    private Transform playerTransform;
    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        xStartPosition = bgPosition.x;
        playerTransform = FindObjectOfType<PlayerController>().GetComponent<Transform>();
        myTransform = GetComponent<Transform>();
        Debug.Log(playerTransform.position);

        GerarBG(4);
    }

    void GerarFase()
    {
        //int numArv = GetRandomIndex(1, 5);
        for (int i = 0; i < numArv; i++)
        {
            Instantiate(arvores[GetRandomIndex(1, arvores.Length)], new Vector3(xStartPosition, GetRandomIndex(-3, 2), 0), Quaternion.identity);
            xStartPosition = xStartPosition + xPlusPosition;
            Debug.Log(xStartPosition);
            if (i % 3 == 0)
            {
                Instantiate(grama, new Vector3(xStartPosition, -3.489f, 0), Quaternion.identity);
            }
        }

    }

    int GetRandomIndex(int min, int max)
    {
        return Random.Range(min, max);
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
            xStartPosition = bgPosition.x;
            GerarFase();
            bgPosition = new Vector2(bgPosition.x+18, 0);
            
        }
    }
}
