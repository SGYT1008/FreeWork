using UnityEngine;
using System.Collections;
using System;

public class GetCollider : MonoSingletion<GetCollider>
{


   public bool OnColliderEnter(Collision other)
    {
        if (other.collider.tag == "Hero")
        {
            return true;
        }
        return false;
    }
}
