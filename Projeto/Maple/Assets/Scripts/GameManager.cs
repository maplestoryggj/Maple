using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private Transform transform;

    [Header("About the Player")]
    public PlayerAtrib playerAtrib;

    [Header("About the PlayButton")]
    public Animator playButtonAnim;

    [Header("About as frases")]
    public TextMeshProUGUI fraseText;
    public List<string> frases = new List<string>();
    public List<float> tempoAcaba = new List<float>(); // Tempo para começar a sumir
    public List<float> tempoProxima = new List<float>(); // Tempo para mostrar a próxima
    private int fraseIndex = -1;
    private float xPosToAdd = 20f;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        fraseText.canvasRenderer.SetAlpha(0.0f);
        playerAtrib.XForce = 100;
        playerAtrib.YForce = 50;
        playerAtrib.CanMove = false; // Não deixa você controlar o player
        playerAtrib.CanEnd = false;
    }


    public void StartGame()
    {
        playButtonAnim.SetBool("Clicked", true); // Anima o botão

        Invoke("ShowText", 3f);

    }

    private void ShowText()
    {
        if(fraseIndex == frases.Count-1) // Mostrou tudo
        {
            fraseIndex = 4; // Começa a repetir
        }
        else
        {
            fraseIndex++;
        }
        if(fraseIndex == 4)
        {
            playerAtrib.CanMove = true; // Você você controlar o player
        }else if(fraseIndex == 9)
        {
            playerAtrib.CanEnd = true;
        }

        fraseText.text = frases[fraseIndex];
        StartCoroutine("FadeIn");
    }

    IEnumerator FadeIn()
    {
        fraseText.CrossFadeAlpha(1.0f, 3f, true);

        yield return new WaitForSeconds(tempoAcaba[fraseIndex]);

        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        fraseText.CrossFadeAlpha(0.0f, 3f, true);

        if(tempoProxima[fraseIndex] > 0f)
        {
            yield return new WaitForSeconds(tempoProxima[fraseIndex]);
            ShowText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ShowText();

            transform.position = new Vector2(transform.position.x + xPosToAdd, transform.position.y);
        }
    }
}
