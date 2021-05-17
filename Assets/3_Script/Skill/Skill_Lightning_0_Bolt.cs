using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Skill_Lightning_0_Bolt : Skill_Base
{


    // skill keng khi big ball

    public GameObject lightningEff;
    public override void CastSkill()
    {

        _arm.animation.FadeIn("Skill1", 0.2f, 1, 1);













        //var standWind = Instantiate(ReferenceAll.instant.gokuEff_1[1]);
        //var posStandWin = transform.position;
        //posStandWin.y -=6;

        //standWind.transform.position = posStandWin;
        //standWind.transform.eulerAngles = _arm.transform.eulerAngles;
        //standWind.transform.localScale = new Vector3(1, 1 * _arm.transform.localScale.y, 1);


        //var gokuBall = Instantiate(ReferenceAll.instant.gokuEff_1[0]);
        //var posGokuBall = transform.position;
        //posGokuBall.y += 6;
        //gokuBall.transform.localPosition = posGokuBall;


        //DOVirtual.DelayedCall(2f, () =>
        //{
        //    var enemySidePos = CharacterControl.enemyFront.transform.position;
        //    enemySidePos.x -= 2;
        //    gokuBall.transform.DOMove(enemySidePos, .3f).OnComplete(() =>
        //    {
        //        gokuBall.transform.DOMove(CharacterControl.enemyFront.transform.position, 3f);




        //        //create effect spell booom
        //        for (int i = 0; i < 10; i++)
        //        {
        //            var rd = CharacterControl.enemyFront.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-2f, 2f));
        //            DOVirtual.DelayedCall(.2f * i, () =>
        //            {
        //                Instantiate(ReferenceAll.instant.effSpell[Random.Range(0, ReferenceAll.instant.effSpell.Count)], rd, Quaternion.identity, null);
        //                DamageEnemy(2);





        //            });
        //        }



        //    });
        //    standWind.SetActive(false);


        //});
    

        //DOVirtual.DelayedCall(4.4f, () =>
        //{
        //    gokuBall.active = false;
        //    _arm.animation.FadeIn("Idle", 0.2f, 1, 1);
        //    var lastBoom= Instantiate(ReferenceAll.instant.bigNova, CharacterControl.enemyFront.transform.position, Quaternion.identity, null);

        //});


        gameObject.SetActive(false);
    }





}
