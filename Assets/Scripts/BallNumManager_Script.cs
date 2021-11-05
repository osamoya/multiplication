using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallNumManager_Script : MonoBehaviour
{
    int now;
    [SerializeField]PreLoad_Script PreLoad_;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void start()
    {
        now = 1;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onTriggerTeisuu(transform.position);
        gameObject.SetActive(false);
    }
    void onTriggerTeisuu(Vector2 itemPos)
    {
        for (int i=0;i<5;i++,now++)
        {
            Vector2 rand = new Vector2(Random.Range(-1, 1), Random.Range(-1, 1));
            PreLoad_.BallPool[now].transform.position = itemPos+rand;
        }

    }
}
