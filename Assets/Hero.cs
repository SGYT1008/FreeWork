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
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
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
}
