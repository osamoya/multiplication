using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallNumManager_Script : MonoBehaviour
{
    
    static int now;
    [SerializeField] bool isAddItem;
    [SerializeField] bool isMultiItem;
    [SerializeField]PreLoad_Script PreLoad_;
    bool canGet = true;
    // Start is called before the first frame update
    void Start()
    {
        start();
    }
    public void start()
    {
        now = 1;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!canGet) return;
        canGet = false;
        gameObject.SetActive(false);
        if (isAddItem) onTriggerTeisuu(transform.position);
        if (isMultiItem) onTriggerBaisuu();
        Debug.Log("���݂̌��́F"+now);
        
    }
    void onTriggerTeisuu(Vector2 itemPos)
    {
        Debug.Log("�萔����");
        Debug.Log("now="+now);
        for (int i=0;i<5;i++,now++)
        {
            Vector2 rand = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
            PreLoad_.BallPool[now].transform.position = itemPos+rand;
            Debug.Log("��"+now+"��");
        }

    }
    void onTriggerBaisuu()
    {
        Debug.Log("�{������");


        for (int i=0;i<now;i++)
        {
            Vector2 origin=PreLoad_.BallPool[i].transform.position;
            Vector2 rand = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
            PreLoad_.BallPool[now + i].transform.position = origin+rand;
            Debug.Log(now+i+"�Ԗڂ�"+i+"�ԖڂɌĂ�");
        }
        now *= 2;
        
    }
}
