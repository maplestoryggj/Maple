using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb; // Rigidbody do personagem
    private Transform tr; // Transform do personagem 
    private float height = 0f; // Altura do personagem

    [Header("Movimento")]
    public int clickForce = 500;
    private Plane plane = new Plane(Vector3.up, Vector3.zero);

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        height = tr.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pegar a posição inicial do clique");
        }

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Ver pra que direção for e add a força");

            //rb.AddForce( alguma coisa * clickForce);
        }
    }
}
