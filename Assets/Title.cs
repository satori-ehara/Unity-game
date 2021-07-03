using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Title : MonoBehaviour
{
    private bool firstPush = false;
    public ToggleGroup toggleGroup;
    public Dropdown dropdown;
    public int n;

    public void PressStart(){
        if (!firstPush){
            firstPush = true;

            string selectedtoggle = toggleGroup.ActiveToggles().FirstOrDefault().name;
            CheckMode(selectedtoggle);
            if(Game.instance != null){
                Game.instance.mode_number = n;
            }          
            else{
                Destroy(this);
            }
            Debug.Log(n);
            Game.instance.init();

            SceneManager.LoadScene("SampleScene");
        }
    }

    public void CheckMode(string name){
        if(name == "toggle-Stepup"){
            n = 0;
        }
        else if(name == "toggle-Random"){
            n = 1;
        }
        else if(name == "toggle-Practice"){
            n = dropdown.value + 2;
        }
    }


}
