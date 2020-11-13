using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCollisionCheck : MonoBehaviour{

    public bool isPlayerInLookPostion;
    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "Player" || other.gameObject.layer == 9){

            isPlayerInLookPostion = true;
            //Debug.Log("player is near");
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "Player"||other.gameObject.layer==9){

            isPlayerInLookPostion = false;
       // Debug.Log("player is no longer near");
        }
    }
}
