using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class SlideBlock : MonoBehaviour{

    //インスペクターで設定する
    [Header("移動速度")]public float speed;
    [Header("重力")]public float gravity;
    public AudioClip seikaiSE;

    //変数
    public BlockGenerator blockPlacement;
    private Rigidbody2D rb = null;
    private string EndTag = "End";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == EndTag){
            Destroy(gameObject,1f);
            if(Game.instance.play_stage){
                Game.instance.PlaySE(seikaiSE);
                Game.instance.play_stage = false;
                Debug.Log(Game.instance.stage_score);
                Game.instance.score += Game.instance.stage_score;
            }
        }
    }

}

