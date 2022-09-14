using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormHole : MonoBehaviour
{
    public Transform pairWormHole;
    public float resetDelay;

    [HideInInspector]public bool canTeleport = true;
    private Transform playerTransform;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canTeleport)
        {
            playerTransform = collision.transform;
            playerTransform.position = pairWormHole.position;
            pairWormHole.GetComponent<WormHole>().canTeleport = false;
            StartCoroutine(Teleport());
        }
    }

    private IEnumerator Teleport()
    {
        yield return new WaitForSeconds(resetDelay);
        pairWormHole.GetComponent<WormHole>().canTeleport = true;
    }
}
