using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPlayer : MonoBehaviour{

    public PlayerAtrib playerAtrib;
    Vector2 startPos, endPos, direction;

    void Start(){
        
    }

    void Update(){
        if(playerAtrib.CanMove){
            transform.Rotate(Vector3.up * Time.deltaTime * 360, Space.World);
        }
        //-10 ~ 35
    }
}
