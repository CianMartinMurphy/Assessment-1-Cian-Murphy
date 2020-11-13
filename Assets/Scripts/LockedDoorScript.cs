using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoorScript : MonoBehaviour{

    [SerializeField]
    private GameObject collisionPoint;
    private bool playerPostionChecked;

    [SerializeField]
    private GameObject door;
    [SerializeField]
    private bool isDoorOpen = false;
    [SerializeField]
    private string answerText;

    private Vector3 doorClosedPostion;
    private Vector3 doorOpenPostion;
    private bool buttonPressed;


    private void Start(){

        doorClosedPostion = door.transform.position;
        doorOpenPostion = doorClosedPostion;
        doorOpenPostion.y = doorOpenPostion.y - 4.5f;
    }
    private void FixedUpdate(){

        // playerPostionChecked = lockedDoor.GetComponent("isPlayerInLookPostion");
        //playerPostionChecked = GameObject.Find("Cube").GetComponent("isPlayerInLookPostion");
        //playerPostionChecked = lockedDoor.gameObject.GetComponent("isPlayerInLookPostion");
        //testing other variants of the code below
        
        LookCollisionCheck collisionReferance = collisionPoint.GetComponent<LookCollisionCheck>();
        playerPostionChecked = collisionReferance.isPlayerInLookPostion;
        
    }

    void OnMouseOver(){ 
        buttonPressed = true; }

    void OnMouseExit(){ 
        buttonPressed = false; }

    void OnMouseDown(){
        if (isDoorOpen == false && playerPostionChecked == true){

            door.transform.position = doorOpenPostion;
            isDoorOpen = true;
        }
        else if ((isDoorOpen == true && playerPostionChecked == true)){

            door.transform.position = doorClosedPostion;
            isDoorOpen = false;
        }
    }
    void OnGUI(){
        if (buttonPressed == true && playerPostionChecked == true){

            GUI.Box(
                new Rect(
                    Screen.width / 2 - 25,
                    Screen.height / 2 - 25,
                    25,
                    20),
                answerText);
        }
    }
}
