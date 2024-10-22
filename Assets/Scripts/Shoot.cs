using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireSpeed;
    [SerializeField] AudioSource audioSource;

    public void Fire()
    {
        audioSource = GetComponent<AudioSource>();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();
        rigidbody.velocity = bullet.transform.forward * fireSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Map"))
        {
            GunRespown gunRespown = FindObjectOfType<GunRespown>();
            gunRespown.DropTheGun();
            Destroy(gameObject, 5f);
        }
    }

    private void PlayDamageSound()
    {
        // 사운드를 재생
        audioSource.Play();
    }
}
