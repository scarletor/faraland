using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DragonBones;
public class Skill_Normal_0 : Skill_Base
{


    // skill FIREBALL
    public GameObject myProjectile;
    public override void CastSkill()
    {
        Debug.LogError("CAST SKILL NORMAL ATTACK__00000" + target);


        var newBall = Instantiate(myProjectile, null);
        var pos2 = myBody.transform.position;
        pos2.x += 1 * dir;
        newBall.transform.transform.position = pos2;



        var pos = target.transform.position;
        pos.x -= 0.5f*dir;
        pos.z = -10 *dir;




        newBall.transform.DOMove(pos, .7f).OnComplete(()=> {

            newBall.GetComponent<ProjectileControl>().OnImpactTarget();
            DamageTarget(10);





        });

        _arm.animation.FadeIn("Skill3", 0.2f, 1, 1);



        DOVirtual.DelayedCall(.5f, () => {

            TurnManager.ins.NextTurn();

            myCharacter.PlayIdle();

        });


        gameObject.SetActive(false);

    }





}
