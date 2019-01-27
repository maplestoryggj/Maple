using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour{
    private Rigidbody2D rb; // Rigidbody do personagem
    private Transform tr; // Transform do personagem 
    private float height = 0f; // Altura do personagem

    [Header("Movimento")]
    public PlayerAtrib playerAtrib;
    private float xForce = 0f;
    private float yForce = 0f;

    public Image theDarkFear;
    private Color darkColor;

    [Header("Sobre o Fim")]
    public TextMeshProUGUI fraseText;
    public string fraseFinal;

    private Plane plane = new Plane(Vector3.up, Vector3.zero);

    Vector2 startPos, endPos, direction;
 

    // Start is called before the first frame update
    void Start(){
        fraseText.canvasRenderer.SetAlpha(0.0f);
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        height = tr.position.y;
        darkColor = theDarkFear.color;
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
           
            rb.AddForce(new Vector2(xForce, yForce));
        }
    }

    void LateUpdate(){
        if (playerAtrib.CanMove)
        {
            Color tempColor = darkColor;
            float yPos = tr.position.y;
            if(yPos > 2) // Maior que 2
            {
                tempColor.a = 0;
            }else if(yPos > 0 && yPos <= 2) // Maior que 0 e menor igual a 2
            {
                tempColor.a = 0.5f - (yPos * .25f);
            }
            else
            {
                yPos = yPos * -1;
                tempColor.a = 0.5f + (0.135f * yPos);
            }
            theDarkFear.color = tempColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("TopCollider"))
        {
            Vector2 newVel = new Vector2(rb.velocity.x, -1*rb.velocity.y);
            rb.velocity = newVel;
        }else if (collision.gameObject.CompareTag("BotCollider"))
        {
            if (playerAtrib.CanEnd)
            {
                playerAtrib.CanMove = false; // Não deixa você controlar o player
                rb.velocity = Vector2.zero;
                Invoke("TheBegin", 5f);
            }
            else
            {
                Vector2 newVel = new Vector2(rb.velocity.x, -1 * rb.velocity.y);
                rb.velocity = newVel;
            }
        }
    }

    private void TheBegin()
    {

        fraseText.text = fraseFinal;
        Debug.Log("Animação virando arvorinha");
        fraseText.CrossFadeAlpha(1.0f, 20f, true);

        theDarkFear.CrossFadeAlpha(0.0f, 15f, true);
    }
}
