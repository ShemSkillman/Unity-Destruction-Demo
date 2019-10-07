using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int hitpoints = 50;
    [SerializeField] ParticleSystem destroyEffect;
    [SerializeField] AudioClip[] destroyAudio;

    private void OnCollisionEnter(Collision collision)
    {
        hitpoints -= Mathf.RoundToInt(collision.relativeVelocity.magnitude);
        DestroyObj();
    }

    private void DestroyObj()
    {
        if (hitpoints > 0) return;

        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(destroyAudio[Random.Range(0, destroyAudio.Length)], transform.position);
        Destroy(gameObject);
    }
}
