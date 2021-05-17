using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using DragonBones;
public class Skill_Thunder_0_LightningStrike : Skill_Base
{
    [GUIColor(0f, 1f, 1, 1f)]
    // skill thunderStrike
    public GameObject thunder, castSpellPart, castSpellMuzzle;
    public override void CastSkill()
    {



        //casting spell for 1s

        _arm.RemoveDBEventListener(EventObject.COMPLETE, myCharacter.PlayIdle);

        _arm.animation.FadeIn("CastSpell", 0.2f, 1, 1);



        var newCastSpellPart = Instantiate(castSpellPart);
        var pos = transform.position;
        pos.x += 1.2f * dir;
        pos.y += -1.28f;



        newCastSpellPart.transform.position = pos;








        //fire spell


        DOVirtual.DelayedCall(2, () =>
        {
            pos.x += 1 * dir;
            pos.y += 1;

            newCastSpellPart.transform.DOMove(pos, 0.3f).OnComplete(() =>
            {

                Destroy(newCastSpellPart);
                var newMuzzle = Instantiate(castSpellMuzzle);
                newMuzzle.transform.position = pos;




                var newThunder = Instantiate(thunder);
                newThunder.transform.position = target.transform.position;
                DamageTarget(30);




            });

            _arm.animation.FadeIn("FireSpell", 0.1f, 1, 1);





        });




        DOVirtual.DelayedCall(3, () =>
        {
            myCharacter.PlayIdle();
            _arm.AddDBEventListener(EventObject.COMPLETE, myCharacter.PlayIdle);



        });

        TurnManager.ins.NextTurn();




        gameObject.SetActive(false);
    }





}
