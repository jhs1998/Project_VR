using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletRerfab;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireSpeed;

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletRerfab, firePoint.position, firePoint.rotation); ;
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.velocity = bullet.transform.forward * fireSpeed;
    }
}
