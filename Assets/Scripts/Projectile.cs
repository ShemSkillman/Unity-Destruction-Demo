using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float maxLifeTime = 10f;

    private void Start()
    {
        StartCoroutine(LifeTimeTimer());
    }

    IEnumerator LifeTimeTimer()
    {
        yield return new WaitForSeconds(maxLifeTime);
        Destroy(gameObject);
    }
}
