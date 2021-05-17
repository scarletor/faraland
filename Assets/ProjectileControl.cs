using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ProjectileControl : MonoBehaviour
{

    public float speed;
    public GameObject myImpact;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }

    public void OnImpactTarget()
    {
        var newImpact = Instantiate(myImpact, transform.position, Quaternion.identity);
        gameObject.transform.GetChild(0).GetComponent<ParticleSystemRenderer>().enabled = false;
        gameObject.transform.GetChild(1).GetComponent<ParticleSystemRenderer>().enabled = false;
        gameObject.transform.GetChild(2).GetComponent<ParticleSystemRenderer>().enabled = false;
        gameObject.transform.GetChild(3).GetComponent<ParticleSystemRenderer>().enabled = false;
        speed = 0;

        DOVirtual.DelayedCall(3f, () =>
        {
            Destroy(newImpact);
            Destroy(gameObject);

        });
    }










}
