using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyChangerScript : MonoBehaviour{

    private GameObject Settings;
    private bool isSelected;
    void Start(){
        Settings = GameObject.Find("Setting");
        if (Settings.GetComponent<OptionsScript>().isHard == true){

            gameObject.SetActive(false);
        }
    }
  

}
