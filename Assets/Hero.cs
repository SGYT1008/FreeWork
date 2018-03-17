using UnityEngine;
using System.Collections;
using System;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //向前运动
            Debug.Log("按下D建");
            ani.SetBool("right", true);
            transform.Translate(Vector2.right * Time.deltaTime);
            //rigid.velocity = new Vector2(2,rigid.velocity.y);
            //transform.Translate(Vector2.right*10*Time.deltaTime);
            //transform.position += new Vector2(Vector2.right * 20,transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //向后运动
            Debug.Log("按下A建");
            ani.SetBool("left", true);
            transform.Translate(Vector2.left * Time.deltaTime);
            //transform.Translate(Vector2.left * 10*Time.deltaTime);
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
                rigid.AddForce(Vector2.up * 250);
                jumpTimes++;
                Debug.Log("jumpTimes : " + jumpTimes);
            }
        }
    }
    public void ChangeBool()
    {
        if (ani.GetBool("left") == true)
        {
            ani.SetBool("left", false);
        }
        if (ani.GetBool("right") == true)
        {
            ani.SetBool("right", false);
        }
    }
    //  private void LateUpdate()
    //  {
    //      if (gameObject.transform.Find("Main Camera").gameObject != null)
    //      {
    //          this.transform.LookAt(this.gameObject.transform.position);
    //      }
    //  }
    void OnCollisionEnter2D(Collision2D other)
    {

        CollisionCondition.Instance.objCollider = other.gameObject;
        if (other.gameObject.name== "RectangleObject1")
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
