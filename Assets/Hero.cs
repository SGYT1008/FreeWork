using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class Hero : MonoBehaviour
{
    private static Hero instance;

    public static Hero Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Hero();
                return instance;
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }
    public GameObject objColl;
    public GameObject objTri;
    public int jumpTimes;
    private float speed;
    Rigidbody2D rigid;
    Animator ani;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }
    float t;
    void Update()
    {
        
        if (Input.GetKey(KeyCode.D))
        {
            //向前运动
            Debug.Log("常按D建");
            ani.CrossFade("LoopRightState", 0.01f);
            transform.Translate(Vector2.right * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            ani.SetBool("loopRight", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //向后运动
            Debug.Log("按下A建");
            ani.CrossFade("LoopLeftState", 0.01f);
            transform.Translate(Vector2.left * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            ani.SetBool("loopLeft", true);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpTimes == 3)
            {
                return;
            }
            else
            {
                //向上运动
                Debug.Log("按下空格");
                rigid.AddForce(Vector2.up * 300);
                jumpTimes++;
                Debug.Log("jumpTimes : " + jumpTimes);
            }
        }
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {

        CollisionCondition.Instance.objCollider = other.gameObject;
        if (other.gameObject.name == "RectangleObject1")
        {
            jumpTimes = 0;
        }
        Debug.LogError(CollisionCondition.Instance.objCollider.name);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        CollisionCondition.Instance.objTrigger = other.gameObject;

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        CollisionCondition.Instance.objTriExit = other.gameObject;
    }
}
