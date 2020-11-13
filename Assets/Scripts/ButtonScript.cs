using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;


public class ButtonScript : MonoBehaviour{

    public GameObject door;
    private bool isDoorOpen = false;

    private Vector3 doorClosedPostion;
    private Vector3 doorOpenPostion;
    private bool buttonPressed;

    
    private void Start(){

       doorClosedPostion = door.transform.position;
       doorOpenPostion = doorClosedPostion;
       doorOpenPostion.y = doorOpenPostion.y-4.5f;
    }

    void OnMouseOver(){ 
       buttonPressed = true; 
    }

    void OnMouseExit(){ 
        buttonPressed = false;
    }

    void OnMouseDown(){

        if (isDoorOpen == false)
        {
            door.transform.position = doorOpenPostion;
            isDoorOpen = true;
        }
        else if((isDoorOpen == true))
        {
            door.transform.position = doorClosedPostion;
            isDoorOpen = false;
        }

    }
    void OnGUI(){
        if (buttonPressed == true){
            GUI.Box(
                new Rect(
                    Screen.width / 2 - 100,
                    Screen.height / 2 - 25,
                    100,
                    20),
                "Press Button");
        }
    }

}
