using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using DG.Tweening;
using UnityEngine.UI;
public class Skill_Base : MonoBehaviour
{
    public bool isPlayer;
    public int dir;


    public UnityArmatureComponent _arm;
    public CharacterControl myCharacter;

    private void Awake()
    {
       

    }


    private void Start()
    {
    }

    public GameObject target, myBody;
    public void InitSpellForPlayerOrEnemy()
    {
        if (gameObject.transform.parent == null) return;
        if (gameObject.transform.parent.name == "Player0" ||
           gameObject.transform.parent.name == "Player1" ||
           gameObject.transform.parent.name == "Player2")
            isPlayer = true;
        else isPlayer = false;



        if (isPlayer)
        {
            target = CharacterControl.enemyFront.gameObject;
            myBody = CharacterControl.playerFront.gameObject;
            dir = 1;
        }
        if (!isPlayer)
        {
            target = CharacterControl.playerFront.gameObject;
            myBody = CharacterControl.enemyFront.gameObject;
            dir = -1;
        }

        myCharacter = transform.parent.GetComponent<CharacterControl>();
        _arm = myCharacter._arm;


    }



    private void OnEnable()
    {
        InitSpellForPlayerOrEnemy();
        CastSkill();
    }

    private void OnDisable()
    {

    }

    public virtual void CastSkill()
    {

    }


    public void CreateSpellImpact()
    {
        var pos = target.transform.position;
        for (int i = 0; i < 10; i++)
        {
            var rd = pos + new Vector3(Random.Range(-1f, 1f), Random.Range(-2f, 2f));
            DOVirtual.DelayedCall(.2f * i, () =>
            {
                Instantiate(ReferenceAll.instant.effSpell[Random.Range(0, ReferenceAll.instant.effSpell.Count)], rd, Quaternion.identity, null);
            });
        }
    }



    public void CreateSpellImpactTarget2()
    {
        var pos = target.transform.position;
        for (int i = 0; i < 5; i++)
        {
            var rd = pos + new Vector3(Random.Range(-1f, 1f), Random.Range(-2f, 2f));
            Instantiate(ReferenceAll.instant.effSpell[Random.Range(0, ReferenceAll.instant.effSpell.Count)], rd, Quaternion.identity, null);
        }
    }


    public static bool canfire = true;

    public void DamageTarget(int value)
    {
        if (target == null) return;
        var damage = value;
        var pos = target.transform.position;
        pos.y += 4;
        var hpEff = Instantiate(ReferenceAll.instant.damageEff, pos, Quaternion.identity, null);
        hpEff.GetComponent<Text>().text = "" + damage;





        target.GetComponent<CharacterControl>().myHP -= damage;
    }


    public virtual void ElementalFire()
    {

    }
}
