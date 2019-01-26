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

    Vector2 startPos, endPos, direction;
 

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
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;

            Debug.Log("1 - Pegar a posição inicial do clique" + startPos);

        }
        if (Input.GetMouseButton(0))
        {

        }

        if (Input.GetMouseButtonUp(0))
        {

            endPos = Input.mousePosition;

            Debug.Log("2 - Ver pra que direção for e add a força" + endPos);

            direction = endPos - startPos;

            Debug.Log(direction);
            rb.velocity = Vector2.zero;
            rb.AddForce(direction);
        }
    }

    void FixedUpdate()
    {
        
    }
}
