using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintButtonScript : MonoBehaviour { 

    private bool isSelected;
    void OnMouseOver(){
        isSelected = true;
    }

    void OnMouseExit(){
        isSelected = false;
    }
    void OnGUI(){
        if (isSelected == true){
            GUI.Box(
                new Rect(
                    Screen.width / 2 - 100,
                    Screen.height / 2 - 25,
                    200,
                    20),
                "Find O,P,E,N shapes");
        }
    }
}
