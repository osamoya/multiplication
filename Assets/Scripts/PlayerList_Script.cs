﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerList_Script : MonoBehaviour
{/// <summary>
/// ここにはリストが存在する
/// 基本的にすべてのボールはそこに入る
/// ただし、入れるものはGameObjectではない
/// 自作のクラス(というかスクリプト)を入れる
/// で、ここでは
/// </summary>

    List<BallZousyoku> list;

    // Start is called before the first frame update
    void Start()
    {
        GameObject firstball = GameObject.FindGameObjectWithTag("player");
        list.Add(firstball.GetComponent<BallZousyoku>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DOZousyokuAll()
    {
        int prenum = list.Count;//要素の数なので注意！
        for (int i=0;i<prenum;i++)
        {
            list[i].Zousyoku();
        }
    }
}