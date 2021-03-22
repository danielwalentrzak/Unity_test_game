using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoryer : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WaitAndDestroy());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        Destroy(collision.gameObject);
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);
    }
}
