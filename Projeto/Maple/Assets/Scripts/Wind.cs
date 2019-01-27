using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour{

    [Header("WindPrefab")]
    public GameObject newWindTrail;
    private GameObject WindTrail;

    private Rigidbody2D rb;
    Camera camera;

    void Start(){
        camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        rb.position = camera.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
            BlowWind();
        else if (Input.GetMouseButtonUp(0))
            StopBlowWind();
    }

    public void BlowWind(){
        WindTrail = Instantiate(newWindTrail, transform);
    }
    public void StopBlowWind(){
        WindTrail.transform.SetParent(null);
        Destroy(WindTrail, 0.2f);
    }
}
