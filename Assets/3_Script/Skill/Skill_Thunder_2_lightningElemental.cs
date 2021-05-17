using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using DragonBones;
public class Skill_Thunder_2_lightningElemental : Skill_Base
{
    [GUIColor(0f, 1f, 1, 1f)]
    // skill thunderStrike
    public GameObject elemental;
    public bool isElemental;
    public override void CastSkill()
    {



        if (isElemental) return;
        //casting spell for 1s

        _arm.RemoveDBEventListener(EventObject.COMPLETE, myCharacter.PlayIdle);

        _arm.animation.FadeIn("CastSpell", 0.2f, 1, 1);


        var pos = transform.position;
        pos.x += 1.2f * dir;
        pos.y += -1.28f;

        var newCastSpellPart = Instantiate(elemental,pos,Quaternion.identity);






        TurnManager.ins.elementalWaitList.Add(newCastSpellPart.transform);




        //fire spell


        DOVirtual.DelayedCall(2, () =>
        {
            pos.x += 13 * dir;
            pos.y += 7;

            newCastSpellPart.transform.DOMove(pos, 1f).OnComplete(() =>
            {



            });



            myCharacter.PlayIdle();
            _arm.AddDBEventListener(EventObject.COMPLETE, myCharacter.PlayIdle);


        });

        TurnManager.ins.NextTurn();



    }



    int attackCount = 0;
    public override void ElementalFire()  
    {
        if (CharacterControl.enemyFront.gameObject == null) return;
        if (target == null) return;

        attackCount++;
        transform.GetChild(5).gameObject.SetActive(true);
        GetComponent<Skill_Base>().target = CharacterControl.enemyFront.gameObject;

        DOVirtual.DelayedCall(.5f, () =>
        {
            for (int i = 0; i < 4; i++)
            {
                DOVirtual.DelayedCall(.5f * i, () =>
                {
                    if (target == null) return;

                    DamageTarget(5);

                });
            }
        });

      

        DOVirtual.DelayedCall(2, () =>
        {
            if (target == null) return;

            transform.GetChild(5).gameObject.SetActive(false);

            if (attackCount == 4)
            {
                TurnManager.ins.elementalWaitList.Remove(gameObject.transform);
                Destroy(gameObject);
            }

        });
    }





}
