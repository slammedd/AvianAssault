using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScroll : MonoBehaviour
{
    public float parrallax;
    public Transform player;

    private MeshRenderer meshRend;
    private Material mat;
    private Vector2 offset;

    private void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
        mat = meshRend.material;
        offset = mat.mainTextureOffset;
    }

    private void Update()
    {
        offset.x = player.position.x / player.localScale.x / parrallax;
        offset.y = player.position.y / player.localScale.y / parrallax;
        mat.mainTextureOffset = offset;
    }
}
