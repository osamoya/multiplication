using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallZousyoku : MonoBehaviour
{/// <summary>
/// ボールを増殖させるスクリプト
/// コピった奴はリストに追加する
/// 2倍増だけ考える
/// このスクリプトを複製みたいな感じでやる
/// 親を考えると結局どこかで重い処理が挟まる気がするので考えたくない
/// </summary>
    PlayerList_Script playerlist_;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("誕生しました！");
        playerlist_ = GameObject.Find("playerList").GetComponent<PlayerList_Script>();//正しく動いたらタグに修正
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Zousyoku()
    {
        //PlayerList_Script.list.Add(new BallZousyoku());
        playerlist_.list.Add(new BallZousyoku());
    }
}
