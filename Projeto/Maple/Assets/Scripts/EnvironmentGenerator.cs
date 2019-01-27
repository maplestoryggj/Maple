using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour{
//descontinuado! problema ja foi resolvido em outro arquivo
    Camera camera;
    bool flag = true;

    void Start(){
        camera = Camera.main;
    }

    void Update(){
        int center = (int)camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, camera.nearClipPlane)).x;
        if(center % 15 == 0 && flag)
            GenerateGrass();
    }

    void GenerateGrass(){
        flag = false;
        int numbGrass = Random.Range(3, 4);
    }
}
