using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferenceAll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        instant = this;
    }
    public static ReferenceAll instant;
    // Update is called once per frame
    void Update()
    {
        
    }
    public List<GameObject> SkillList;

    public List<GameObject> effHit,effSpell;
    public GameObject player, enemy,bigNova,attackSkill,damageEff;

    public List<GameObject> gokuEff_1;
    public List<GameObject> projectile;

}
