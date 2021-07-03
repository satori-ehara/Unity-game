using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   private Text scoreText = null;
   private int oldScore = 0;

  // Start is called before the first frame update
  void Start(){
    scoreText = GetComponent<Text>();
    if(Game.instance != null){
            scoreText.text = "Score：" + Game.instance.score;
    }
    else{
        Destroy(this);
    }
  }

   // Update is called once per frame
   void Update(){
        if(oldScore != Game.instance.score){
            scoreText.text = "Score " + Game.instance.score;
            oldScore = Game.instance.score;
        }
   }
}