using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private bool firstPush = false;

    public void PressTitle(){
        if (!firstPush){
            firstPush = true;

            SceneManager.LoadScene("Title");
        }
    }

    public void PressGameOver(){
        if (!firstPush){
            firstPush = true;

            SceneManager.LoadScene("GameOvar");
        }
    }
}