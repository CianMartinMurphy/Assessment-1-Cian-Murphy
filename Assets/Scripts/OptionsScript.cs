using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsScript : MonoBehaviour{
   public float PlayerSensitvity;
    public  float testc;
    public bool isHard = true;
   public void SensitivityChange(float sensitivity){

        PlayerSensitvity = sensitivity;
    }
    private void Awake(){
        DontDestroyOnLoad(gameObject);        
    }
    public void setDifficulty(bool difficulty){
       
        isHard = difficulty;
    }
}
