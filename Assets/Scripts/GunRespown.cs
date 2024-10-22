using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRespown : MonoBehaviour
{
    public bool gunExist = true;
    [SerializeField] Transform gunRespown;
    [SerializeField] GameObject gunPrefab;
    public void DropTheGun()
    {
        gunExist = false;
    }

    public void SpownGun()
    {
        Debug.Log("√— º“»Ø");
        if (!gunExist)
        {
            Instantiate(gunPrefab, gunRespown.position, gunRespown.rotation);
            gunExist = true;
        }
    }
}
