using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour{

    public GameObject player;
    public float fanForce;
    public float gravityTemp;

    private void OnTriggerEnter(Collider other){
        
        playerScript collisionReferance = player.GetComponent<playerScript>();
        gravityTemp = collisionReferance.gravityForce;
        collisionReferance.gravityForce= fanForce;
        
        collisionReferance.isGrounded = false;
        collisionReferance.velocity= collisionReferance.velocity / 1.2f;


    }
    private void OnTriggerExit(Collider other){

        playerScript collisionReferance = player.GetComponent<playerScript>();
        collisionReferance.gravityForce = gravityTemp;
    }
}
