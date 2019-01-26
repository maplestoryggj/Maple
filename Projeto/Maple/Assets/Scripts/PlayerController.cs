using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    private Rigidbody2D rb; // Rigidbody do personagem
    private Transform tr; // Transform do personagem 
    private float height = 0f; // Altura do personagem

    [Header("Movimento")]
    public PlayerAtrib playerAtrib;
    private float xForce = 0f;
    private float yForce = 0f;

    private Plane plane = new Plane(Vector3.up, Vector3.zero);

    Vector2 startPos, endPos, direction;
 

    // Start is called before the first frame update
    void Start(){
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        height = tr.position.y;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0)){

            endPos = Input.mousePosition;

            direction = endPos - startPos;

            rb.velocity = Vector2.zero;
            if (playerAtrib.CanMove)
            {
                if (direction.y > playerAtrib.YForce)
                {
                    yForce = playerAtrib.YForce;
                }
                else if (direction.y < -playerAtrib.YForce)
                {
                    yForce = -playerAtrib.YForce;
                }
                else
                {
                    yForce = direction.y;
                }

                if (direction.x > playerAtrib.XForce)
                {
                    xForce = playerAtrib.XForce;
                }
                else if (direction.x < 0)
                {
                    xForce = playerAtrib.XForce;
                }
                else
                {
                    xForce = direction.x;
                }
            }
            else
            {
                xForce = 0;
                yForce = 0;
            }
           
            Debug.Log("x = " + xForce + "   y = " + yForce);
            rb.AddForce(new Vector2(xForce, yForce));
        }
    }

    void FixedUpdate(){
        
    }
}
