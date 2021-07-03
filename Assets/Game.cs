 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 
 public class Game : MonoBehaviour
{
    //
    public static Game instance = null;

    //変数
    public int score =0;
    private AudioSource audioSource = null; 
    //現在プレイ中のスコアとその処理（）
    public bool play_stage = true;
    public int stage_score = 0;
    public int stage_number = 0;
    public bool invincible;
    //ゲームモードの管理
    //ステップアップモード（以下の順番でステージが進行
    public int[] stage = {2,3,4,8,5,0,10,11,13,9,6,15,12,19,17,7,14,18,1,16};
    //0=ステップアップ　1=ランダム　2以上=練習
    public int mode_number = 0;



    private void Awake(){
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); 
        }
        else
        {
            Destroy(this.gameObject);
        }
         
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void init(){
        score =0;
        stage_number = 0;
        stage_score = 0;
        play_stage = true;
    }

    public void PlaySE(AudioClip clip){
        if (audioSource != null){
            audioSource.PlayOneShot(clip);
        }
        else{
            Debug.Log("オーディオソースが設定されていません");
        }   
    }

}