using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 5f);
        }      
    }
}
