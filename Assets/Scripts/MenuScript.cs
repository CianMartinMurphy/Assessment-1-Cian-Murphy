using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void loadMenu(){
        SceneManager.LoadScene("Menu");
    }
    public void loadGame(){
        SceneManager.LoadScene("Level");
    }
}
