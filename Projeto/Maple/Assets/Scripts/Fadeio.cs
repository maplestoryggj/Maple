using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Fadeio : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int limitToFadeOut = 1;
    double timer = 0.0;
    double lastCalled = 0.0;

    // Use this for initialization
    void Start()
    {
        text.canvasRenderer.SetAlpha(0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= limitToFadeOut && lastCalled == 0.0) // Condicional para o texto aparecer
        {
            lastCalled = timer;
            text.text = "Apareci";
            FadeIn();
        }
        if (timer >= lastCalled + limitToFadeOut && lastCalled > 0.0)
        {
            FadeOut();
            lastCalled = 0.0;
            timer = 0.0;
        }
    }

    public void FadeIn()
    {
        text.CrossFadeAlpha(1.0f, 3.0f, true);
    }

    public void FadeOut()
    {
        text.CrossFadeAlpha(0.0f, 3.0f, true);
    }
}