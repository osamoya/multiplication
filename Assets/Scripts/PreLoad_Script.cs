using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreLoad_Script : MonoBehaviour
{
    [SerializeField] GameObject ballpre;
    [SerializeField] GameObject Pool;
    [SerializeField] int teisuu;
    [SerializeField] int baisuu;
    public GameObject[] BallPool;
    int Theoretical_num;
    Vector2 pool_v;
    // Start is called before the first frame update
    void Start()
    {
        //Ç±Ç±Ç≈êîéöÇê›íËÇµÇƒÇ‡ÇÊÇ¢
        Theoretical_num = (1 + teisuu*5) * (int)Mathf.Pow(2,baisuu)-1;
        pool_v = Pool.transform.position;
        pool_v.y += 5;
        PreSet();
    }

    void PreSet()
    {
        Debug.Log("PreSet:"+Theoretical_num+"ê›íËÇµÇ‹Ç∑");
        BallPool = new GameObject[Theoretical_num];
        for (int i=0;i<Theoretical_num;i++)
        {
            Vector2 diff=new Vector2(Random.Range(-5,5), 0);
            GameObject tmp = Instantiate(ballpre,diff+pool_v, Quaternion.identity);
            
            BallPool[i] = tmp;
            
        }
    }


}
