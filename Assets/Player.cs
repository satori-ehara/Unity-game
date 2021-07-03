using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 public class Player : MonoBehaviour
 {
    //インスペクターで設定する
    public float speed; //速度
    public float gravity; //重力
    public float jumpSpeed; //ジャンプの速度
    public float jumpHeight; //ジャンプの高さ制限
    public AudioClip bubuSE;
    public AudioClip jumpSE;

    //変数
    private Rigidbody2D rb = null;
    private float jumpPos = 0.0f;
    private double groundY = -0.5;
    private bool Jumping = false;
    private string enemyTag = "Enemy_Block";

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        float verticalKey = Input.GetAxis("Vertical");
        float ySpeed = -gravity;
        if(transform.position.y < groundY){
            if (verticalKey > 0){
                jumpPos = transform.position.y;
                Debug.Log(jumpPos);
                ySpeed = jumpSpeed;
                Jumping = true;
                Game.instance.PlaySE(jumpSE);
            }
            else{
                Jumping = false;
            }
        }
        else if(Jumping){
            if (verticalKey > 0 && jumpPos + jumpHeight > transform.position.y){
                 ySpeed = jumpSpeed;
            }
            else{
                 Jumping = false;
            }
        }

        rb.velocity = new Vector2(rb.velocity.x, ySpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.tag == enemyTag){
            Game.instance.PlaySE(bubuSE);
            Game.instance.play_stage = false;
            if(Game.instance.invincible){
                Debug.Log("敵と接触した！");
            }
            else{
                Invoke("Ending", 0.5f);
            }
        }
    }

    private void Ending(){
        SceneManager.LoadScene("GameOvar");
    }

 }