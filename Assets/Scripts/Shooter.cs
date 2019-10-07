using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectile;
    [SerializeField] float fireForce = 1000f;

    [SerializeField] float reloadTime = 0.4f;
    bool isReloaded = true;

    void FixedUpdate()
    {
        if (Input.GetAxis("Fire1") != 0 && isReloaded)
        {
            Fire();
        }
    }

    private void Fire()
    {
        Projectile instance = Instantiate(projectile, Camera.main.transform.position, Quaternion.identity);
        instance.GetComponent<Rigidbody>().AddForce(Camera.main.transform.TransformVector(Vector3.forward) * fireForce);

        isReloaded = false;
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
            yield return new WaitForSeconds(reloadTime);
            isReloaded = true;
    }
}
