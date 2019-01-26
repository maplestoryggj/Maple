using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialTutorial : MonoBehaviour
{

    public Transform maple;
    public float xMin = 0f;
    public float xMax = 0f;
    public float yPos = 0f;

    public float xMinForce = 0f;
    public float xMaxForce = 0f;
    public float yMinForce = 0f;
    public float yMaxForce = 0f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GerarMaples", 2.0f, 1.5f);
    }

    void GerarMaples()
    {
        int n = Random.Range(1, 5);

        for (int i = 0; i < n; i++)
        {
            float xPos = Random.Range(xMin, xMax);
            Transform mapleI = Instantiate(maple, new Vector2(xPos, yPos), Quaternion.identity);
            mapleI.GetComponent<Rigidbody2D>().AddForce(new Vector2(
                Random.Range(xMinForce, xMaxForce), 
                Random.Range(yMinForce, yMaxForce)));
        }
    }

}
