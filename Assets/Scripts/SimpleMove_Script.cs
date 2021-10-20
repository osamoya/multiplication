using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// 非常にシンプルなスクリプト
/// 多少挙動不審(主にジャンプ面)なので
/// 良い感じに調整する必要あり
/// </summary>
public class SimpleMove_Script : MonoBehaviour
{
    static public bool canMove = true;
    [SerializeField] GameObject Player_;
    [Header("速さ(addforce)")]
    [SerializeField] float speed_f;
    [Header("ジャンプ(addforce)")]
    [SerializeField] float jump_f;
    Rigidbody2D rb;

    bool jump = false;
    bool canStepPlayer = false;
    bool canStepWall = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove&&Input.anyKey)
        {
            moveForce();
        }
    }

    void moveForce()
    {
        if (Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.D))
        {
            //Debug.Log("R");
            rb.AddForce(new Vector2(speed_f, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //Debug.Log("L");
            rb.AddForce(new Vector2(-speed_f, 0));
        }
        //if (Input.GetKeyUp(KeyCode.RightArrow)) Debug.Log("---R---");
        //if (Input.GetKeyUp(KeyCode.LeftArrow)) Debug.Log("---L---");

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (!canStepPlayer && !canStepWall) return;
            //Debug.Log("JUMP");
            rb.AddForce(new Vector2(0, jump_f));
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //Debug.Log("RETRY");
        }

    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("接地！");
            if (gameObject.transform.position.y > col.gameObject.transform.position.y)
            {
                canStepPlayer = true; return;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            canStepPlayer = false;
            //Debug.Log("離れた");
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall_tag")
        {
            //Debug.Log("接地！");
            if (gameObject.transform.position.y >= col.gameObject.transform.position.y)
            {
                canStepWall = true; return;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall_tag")
        {
            canStepWall = false;
            //Debug.Log("離れた");
        }
    }



}
