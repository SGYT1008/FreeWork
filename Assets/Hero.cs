using UnityEngine;
using System.Collections;

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
    public  GameObject objTri;

    private float speed;
    Rigidbody2D rigid;
    Animator animator;
    void Start()
    {
       rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerRun();
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

    private void PlayerRun()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            //向前运动
            Debug.Log("按下D建");
            //transform.position = 
            rigid.velocity = new Vector2(2,rigid.velocity.y);
            animator.SetBool("Run",true);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            //向后运动
            Debug.Log("按下A建");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //向上运动
            Debug.Log("按下空格");
        }
    }
}
