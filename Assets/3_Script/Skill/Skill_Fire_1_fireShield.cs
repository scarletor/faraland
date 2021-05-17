using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using DragonBones;
public class Skill_Fire_1_fireShield : Skill_Base
{
    [GUIColor(0f, 1f, 1, 1f)]
    // skill thunderStrike
    public GameObject fireShield;
    public override void CastSkill()
    {


        _arm.RemoveDBEventListener(EventObject.COMPLETE, myCharacter.PlayIdle);

        _arm.animation.FadeIn("Skill3", 0.2f, 1, 1);


        var newBall = Instantiate(fireShield,myBody.transform);
        var pos2 = myBody.transform.position;
        pos2.x += .01f* dir;
        newBall.transform.transform.position = pos2;






        DOVirtual.DelayedCall(2, () =>
        {
            myCharacter.PlayIdle();


         
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

