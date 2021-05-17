using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmatureFadeOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<MeshRenderer>() == null)
        {
            isMesh = false;
        }
        else isMesh = true;

        if (isMesh)
            _mesh = transform.GetComponent<MeshRenderer>();
        else
            sprite = GetComponent<SpriteRenderer>();

        rd1 = Random.Range(0, 2f);
        rd2 = Random.Range(0, 2f);
        rd3 = Random.Range(0, 2f);

    }
    MeshRenderer _mesh;
    float tempAlpha = 1;
    // Update is called once per frame
    float rd1, rd2, rd3;

    SpriteRenderer sprite;
    bool isMesh;
    void Update()
    {
        if (isMesh)
        {

            _mesh.material.color = new Color(rd1,rd2,rd3, tempAlpha);
            tempAlpha -= Time.deltaTime * .8f;
            if (tempAlpha <= .05f) Destroy(gameObject);
        }
        else
        {
            sprite.color = new Color(rd1,rd2,rd3, tempAlpha);
            tempAlpha -= Time.deltaTime * .8f;
            if (tempAlpha <= .05f) Destroy(gameObject);
        }




    }





}
