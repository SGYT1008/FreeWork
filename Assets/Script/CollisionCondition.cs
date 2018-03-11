using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CollisionCondition : MonoBehaviour
{
    private static CollisionCondition instance;

    public static CollisionCondition Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CollisionCondition();
                return instance;
            }
            return instance;
        }
    }
    private void Awake()
    {
        instance = this;
    }

    private GameObject go;
    public GameObject objCollider;//用来接受hero中的碰撞检测的物体
    public GameObject objTrigger;//用来接受hero中的触发碰撞检测的物体
    public GameObject objTriExit;
    private Transform tempObj;
    // public UnityEvent OnConllisionHandler;
    //
    // void OnConllisiOnEnter2D(Collision2D collision)
    // {
    //     Debug.Log("发生了碰撞");
    //     OnConllisionHandler.Invoke();
    // }
    //public GameObject RoatObj;
    private void Start()
    {
        tempObj = gameObject.transform.Find("Decoration/collider_ci").gameObject.GetComponent<Transform>();
        if (tempObj.gameObject != null)
        {
            Debug.LogError("obj.name=" + "123");
            tempObj.gameObject.SetActive(false);
        }
      
        objCollider = Hero.Instance.objColl;
        objTrigger = Hero.Instance.objTri;

        if (objCollider != null)
        {
            JudgeColliderObj(objCollider);
        }
    }

    private void Update()
    {
        if (objCollider != null && objCollider.name != "RectangleObject1")
        {
            JudgeColliderObj(objCollider);
        }
        if (objTrigger != null)
        {
            JudgeColliderObj(objTrigger);
        }
        if (objTriExit != null)
        {
            ShowWallByName(objTriExit);
        }
    }


  //该方法用来判断所碰撞或触发碰撞物体
  private void JudgeColliderObj(GameObject obj)
    {
        if (obj.name == "RectangleObject1")
        {
           
        }
     
        if (obj.name == "RectangleObj")
        {
            #region
            if (obj.transform.childCount==0)
            {
                go = GameObject.Instantiate(Resources.Load("Prefab/Pass/Pass1_1/Collider_girl")) as GameObject;
                go.name = "Collider_girl";
                go.transform.localPosition = new Vector3(160,26,1);
                go.transform.SetParent(obj.transform, false);
                go.transform.localScale = new Vector3(100, 100, 1);
                go.SetActive(true);
            }
            else
            {
                return;
            }
          
        }
        #endregion
        if (obj.name == "RectangleObj2")
        {
            if (obj.transform.childCount == 0)
            {
                go = GameObject.Instantiate(Resources.Load("Prefab/Pass/Pass1_1/Wall")) as GameObject;
                go.name = "Wall";
                go.transform.SetParent(obj.transform, false);
                go.transform.localScale = new Vector3(100, 100, 1);
                go.transform.localPosition = new Vector3(140,53,0);
                go.SetActive(true);
                go.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0);
            }
            else
            {
                return;
            }
        }
        if (obj.name == "Wall")
        {
           // Debug.LogWarning("Wall==obj.name=" + obj.name);
            go.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        if (obj.name == "Tile_source_grass")
        {
           // Debug.LogWarning("Tile_source_grass==obj.name=" + obj.name);
            if (tempObj.gameObject != null)
            {
                tempObj.gameObject .SetActive(true);
            }
        }
        if (obj.name == "yaoshi")
        {
            Debug.Log("yaoshi.name=" + obj.name);
            obj.transform.Find("rightBotany").gameObject.SetActive(true);
            obj.transform.Find("leftBotany").gameObject.SetActive(true);
        }
        if (obj.name == "Spr_Save")
        {
            Debug.Log("播放特效音乐");
        }
        if (obj.name == "RectangleLong")
        {
            if (obj.transform.childCount == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    go = GameObject.Instantiate(Resources.Load("Prefab/Pass/Pass1_1/UnSure")) as GameObject;
                    go.name = "UnSure" + i;
                    go.transform.SetParent(obj.transform, false);
                    go.transform.localScale = new Vector3(100, 100, 1);
                    go.transform.localPosition = new Vector3(-217+i*47, 10, 0);
                    go.SetActive(true);
                    go.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
                }
            }
            else
            {
                return;
            }
        }
      

 }

    private void ShowWallByName(GameObject obj)
    {
        if (obj.name == "UnSure0")
        {
            if (obj.transform.childCount == 0)
            {
                obj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                go = GameObject.Instantiate(Resources.Load("Prefab/Pass/Pass1_1/Wall")) as GameObject;
                go.transform.SetParent(obj.transform, false);
                go.transform.localScale = new Vector3(100, 100, 1);
                go.SetActive(true);
                SpriteRenderer spriteRen = go.GetComponent<SpriteRenderer>();
                spriteRen.sortingOrder = obj.GetComponent<SpriteRenderer>().sortingOrder + 1;
            }
            else
            {
                return;
            }

        }

        if (obj.name == "UnSure1")
        {
            if (obj.transform.childCount == 0)
            {
                //Invoke(MakeInvoke(obj),1f);

                obj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                go = GameObject.Instantiate(Resources.Load("Prefab/Pass/Pass1_1/Wall")) as GameObject;
                go.transform.SetParent(obj.transform, false);
                go.transform.localScale = new Vector3(100, 100, 1);
                go.SetActive(true);
                SpriteRenderer spriteRen = go.GetComponent<SpriteRenderer>();
                spriteRen.sortingOrder = obj.GetComponent<SpriteRenderer>().sortingOrder + 1;
            }
            else
            {
                return;
            }

        }

        if (obj.name == "UnSure2")
        {
            if (obj.transform.childCount == 0)
            {
                obj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                go = GameObject.Instantiate(Resources.Load("Prefab/Pass/Pass1_1/Wall")) as GameObject;
                go.transform.SetParent(obj.transform, false);
                go.transform.localScale = new Vector3(100, 100, 1);
                go.SetActive(true);
                SpriteRenderer spriteRen = go.GetComponent<SpriteRenderer>();
                spriteRen.sortingOrder = obj.GetComponent<SpriteRenderer>().sortingOrder + 1;
            }
            else
            {
                return;
            }
        }

        if (obj.name == "UnSure3")
        {
            if (obj.transform.childCount == 0)
            {
                obj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                go = GameObject.Instantiate(Resources.Load("Prefab/Pass/Pass1_1/Wall")) as GameObject;
                go.transform.SetParent(obj.transform, false);
                go.transform.localScale = new Vector3(100, 100, 1);
                go.SetActive(true);
                SpriteRenderer spriteRen = go.GetComponent<SpriteRenderer>();
                spriteRen.sortingOrder = obj.GetComponent<SpriteRenderer>().sortingOrder + 1;
            }
            else
            {
                return;
            }
        }


        if (obj.name == "UnSure4")
        {
            if (obj.transform.childCount == 0)
            {
                obj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                go = GameObject.Instantiate(Resources.Load("Prefab/Pass/Pass1_1/Wall")) as GameObject;
                go.transform.SetParent(obj.transform, false);
                go.transform.localScale = new Vector3(100, 100, 1);
                go.SetActive(true);
                SpriteRenderer spriteRen = go.GetComponent<SpriteRenderer>();
                spriteRen.sortingOrder = obj.GetComponent<SpriteRenderer>().sortingOrder + 1;
            }
            else
            {
                return;
            }
        }

    }

   

    private void MakeInvoke(GameObject obj)
    {
        obj.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
       // return "1";
    }

}
