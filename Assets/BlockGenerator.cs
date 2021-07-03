using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BlockGenerator : MonoBehaviour {

    public GameObject Block;
    public GameObject[] tagObjects;
    public int[,,] BlockPlacement;
    public int NowNumber;

    //変数
    private float up = 4.0f;
    private float left = -16.2f; 

	void Start () {
        init();
        if(Game.instance.mode_number > 1){//mode_numberが2以上（プラクティスモードでステージを選択している）ならそのステージへ
            Game.instance.invincible = true;
            NowNumber = Game.instance.stage[Game.instance.mode_number-2];
        }
        else{//mode_numberが1(ランダム)か0(ステップアップ)ならステージナンバーを抽出
            if(Game.instance.mode_number == 1){
                Game.instance.invincible = false;
            }
            else if(Game.instance.mode_number == 0){
                Game.instance.invincible = true;
            }
            GetStageNumber();
        }
        Placement(NowNumber);
	}
	
	void Update() {
        tagObjects = GameObject.FindGameObjectsWithTag("Enemy_Block");
        if ( tagObjects.Length < 1 ){
            if(Game.instance.mode_number > 1){//mode_numberが2以上（プラクティスモードでステージを選択している）なら変更なし
            }
            else{//mode_numberが1(ランダム)か0(ステップアップ)ならステージナンバーを抽出
                GetStageNumber();
            }
            Placement(NowNumber);
        }
	}

    void Generate(int x,int y){
        Vector2 obj = new Vector2(left + (1.3f * x), (up - (1.3f * y)));
        var parent = this.transform;
        Instantiate (Block, obj, Quaternion.identity, parent);
    }

    void Placement(int number){
        Debug.Log(number+"を作成");
        int n=0;
        while(n < 5){
            int j=0;
            while(j < 5){
                if(BlockPlacement[number,n,j] == 1){
                    Generate(j,n);
                }
                ++j;
            }
            ++n;
        }
        Game.instance.stage_score = BlockPlacement[number,5,0];
        Game.instance.play_stage = true;
    }

    void GetStageNumber(){
        if(Game.instance.mode_number == 1){
            NowNumber = Random.Range(0,20);
        }
        else if(Game.instance.mode_number == 0){
            if(Game.instance.stage_number>20){
                SceneManager.LoadScene("GameOvar");
            }
            Game.instance.stage_number += 1;
            NowNumber = Game.instance.stage[Game.instance.stage_number-1];
        }
    }


    void init(){
        BlockPlacement = new int[,,]{
            {
                {0,0,0,0,1},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,1},
                {450,0,0,0,0}
            },//穴あき０
            {
                {1,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,1,1,1,0},
                {2000,0,0,0,0}
            },//幅跳び１
            {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,0,0},
                {100,0,0,0,0}
            },//一番ふつう２
            {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,1,1,1,0},
                {300,0,0,0,0}
            },//横長３
            {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {200,0,0,0,0}
            },//縦長弱４
            {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {400,0,0,0,0}
            },//縦長強５
            {
                {1,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,1,1},
                {600,0,0,0,0}
            },//幅跳び弱6
            {
                {1,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,1,1},
                {1200,0,0,0,0}
            },//幅跳び中7
            {
                {0,1,0,0,0},
                {0,1,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {100,0,0,0,0}
            },//フェイク8
            {
                {1,0,0,0,0},
                {0,0,0,0,0},
                {1,0,1,0,1},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {200,0,0,0,0}
            },//ふぇいく９
            {
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,0,1,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {150,0,0,0,0}
            },//フェイク10
            {
                {1,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,1},
                {0,0,0,0,1},
                {400,0,0,0,0}
            },//ちょい幅飛び11
            {
                {1,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,1,0},
                {0,0,0,1,1},
                {1500,0,0,0,0}
            },//ちょい幅跳び強12
            {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,0,1,1,0},
                {0,0,1,1,1},
                {500,0,0,0,0}
            },//階段13
            {
                {0,0,0,0,0},
                {0,1,0,0,0},
                {0,0,1,0,0},
                {0,0,0,1,0},
                {0,0,0,0,1},
                {1200,0,0,0,0}
            },//階段14
            {
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,1,0,0},
                {0,1,1,0,0},
                {1,1,1,0,0},
                {300,0,0,0,0}
            },//逆階段15
            {
                {0,0,0,0,1},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,1,0,0,0},
                {0,0,0,0,1},
                {2500,0,0,0,0}
            },//2だん構え16
            {
                {1,1,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {1,1,0,0,0},
                {1000,0,0,0,0}
            },//中抜き強17
            {
                {0,0,0,0,1},
                {0,0,0,0,0},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {1,0,0,0,0},
                {2000,0,0,0,0}
            },//逆幅跳び18
            {
                {0,0,0,0,0},
                {0,0,0,1,0},
                {0,0,0,0,0},
                {0,0,0,0,0},
                {1,0,0,0,0},
                {500,0,0,0,0}
            },//逆幅跳び弱19
        };
    }
}