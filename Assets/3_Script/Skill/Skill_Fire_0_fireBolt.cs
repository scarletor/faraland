using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using DragonBones;
public class Skill_Fire_0_fireBolt : Skill_Base
{
    [GUIColor(0f, 1f, 1, 1f)]
    // skill thunderStrike
    public GameObject fireBolt, Muzzle, Explosion;
    public override void CastSkill()
    {


        _arm.RemoveDBEventListener(EventObject.COMPLETE, myCharacter.PlayIdle);

        _arm.animation.FadeIn("Skill3", 0.2f, 1, 1);


        var newBall = Instantiate(fireBolt, null);
        var pos2 = myBody.transform.position;
        pos2.x += 1 * dir;
        newBall.transform.transform.position = pos2;



        var pos = target.transform.position;
        pos.x -= 0.5f * dir;





        DOVirtual.DelayedCall(2, () =>
        {
            myCharacter.PlayIdle();


            newBall.transform.DOMove(pos, 1.2f).OnComplete(() =>
            {

                DamageTarget(40);

                Destroy(newBall);
                var newImpact = Instantiate(Explosion, null);
                newImpact.transform.position = target.transform.position;



            });
        });









        gameObject.SetActive(false);
        TurnManager.ins.NextTurn();

    }

















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
    //    var enemySidePos = target.transform.position;
    //    enemySidePos.x -= 2*dir;
    //    gokuBall.transform.DOMove(enemySidePos, .3f).OnComplete(() =>
    //    {
    //        gokuBall.transform.DOMove(target.transform.position, 3f);




    //        //create effect spell booom
    //        for (int i = 0; i < 10; i++)
    //        {
    //            var rd = target.transform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-2f, 2f));
    //            DOVirtual.DelayedCall(.2f * i, () =>
    //            {
    //                Instantiate(ReferenceAll.instant.effSpell[Random.Range(0, ReferenceAll.instant.effSpell.Count)], rd, Quaternion.identity, null);
    //                DamageTarget(2);





    //            });
    //        }



    //    });
    //    standWind.SetActive(false);


    //});




    //gameObject.SetActive(false);
}

