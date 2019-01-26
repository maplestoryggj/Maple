using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour{

    
    private Rigidbody2D rb;
    Camera camera;

    bool isBlowing = false;

    void Start(){
        camera = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            BlowWind();
        }
        else if (Input.GetMouseButtonUp(0)){
            StopBlowWind();
        }

        if(isBlowing){
            updateWindTrail();
        }

    }
    void updateWindTrail(){
        rb.position = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    public void BlowWind(){
        isBlowing = true;
    }
    public void StopBlowWind(){
        isBlowing = false;
    }
}
