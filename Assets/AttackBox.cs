using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class AttackBox : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.LogError(gameObject);
    }

    public PlayerMoveController control;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogError(gameObject+"HITT");

        if (collision.gameObject.name == "@hitBoxCol" && gameObject.name == "@atackHitBoxCol") 
        {

            collision.gameObject.transform.parent.parent.parent.GetComponent<PlayerMoveController>().GetHit();
            transform.parent.parent.DOPause();
            
            if (isCritical)
                collision.gameObject.transform.parent.parent.parent.GetComponent<PlayerMoveController>().GetCriticalStrike();


                DOVirtual.DelayedCall(.1f, () =>
                {
                    var part = Instantiate(ReferenceAll.instant.effHit[1]);
                    part.transform.parent = null;
                    part.transform.position = spawnAttackParticlePos[3].transform.position;
                });

        }
       


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.LogError(gameObject + "HITT");

    }
    public List<GameObject> spawnAttackParticlePos;
    public int attackIndex;
    public bool isCritical;
}
