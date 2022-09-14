using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScaleFadeIn : MonoBehaviour
{
    public float scale;
    public float scaleSpeed;
    public float fadeSpeed;

    private SpriteRenderer sR;

    private void Start()
    {
        GetComponent<SpriteRenderer>().DOFade(255, fadeSpeed);
       
        transform.DOScale(new Vector3(scale, scale, scale), scaleSpeed);
    }

    private void Update()
    {

        if(transform.localScale == new Vector3(scale, scale, scale))
        {
            GetComponent<Collider2D>().enabled = true;
        }
    }
}
