using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleanup : MonoBehaviour
{
    public float lifetime;

    private void Start()
    {
        Invoke("Destroy", lifetime);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
