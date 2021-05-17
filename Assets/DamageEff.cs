using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DamageEff : MonoBehaviour
{
    void Start()
    {
        transform.DOMoveY(transform.position.y+1, 1);


        InvokeRepeating("DecreaseAlphaUpdate", 0, Time.deltaTime);

        canvas = gameObject.GetComponent<CanvasGroup>();


        var newPos = Random.Range(1f, -1f);
        transform.position = new Vector2(transform.position.x + newPos, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void DecreaseAlphaUpdate()
    {
        canvas.alpha -=.02f;
        if (canvas.alpha <= 0) Destroy(gameObject);
    }

    CanvasGroup canvas;
    float alpha=1;
    public int HPShow;









}
