using UnityEngine;
using System.Collections;

public class MonoSingletion<T>: MonoBehaviour where T : new ()
{       
//private static string SingleName = "SingleRoot";
//private static GameObject SingleRoot;
private static T instance;
public static T Instance
{
    get
    {
    //  if (SingleRoot == null)
    //  {
    //      SingleRoot = GameObject.Find(SingleName);
    //      if (SingleRoot == null)
    //      {
    //          SingleRoot = new GameObject();
    //          SingleRoot.name = SingleName;
    //      }
    //  }
        if (instance == null)
        {
            //instance = SingleRoot.GetComponent<T>();
            instance = new T ();
          //  if (instance == null)
          //  {
          //      instance = SingleRoot.AddComponent<T>();
          //  }
        }
        return instance;
    }
 }
  //  private void Awake()
  //  {
  //      instance = this;
  //  }
}


//public abstract class MonoSingletion<T> : MonoBehaviour where T : MonoBehaviour
//{
//
//    private static string rootName = "MonoSingletionRoot";
//    private static GameObject monoSingletionRoot;
//
//    private static T instance;
//    public static T Instance
//    {
//        get
//        {
//            if (monoSingletionRoot == null)
//            {
//                monoSingletionRoot = GameObject.Find(rootName);
//                if (monoSingletionRoot == null) Debug.Log("please create a gameobject named " + rootName);
//            }
//            if (instance == null)
//            {
//                instance = monoSingletionRoot.GetComponent<T>();
//                if (instance == null) instance = monoSingletionRoot.AddComponent<T>();
//            }
//            return instance;
//        }
//    }
//
//}
//




