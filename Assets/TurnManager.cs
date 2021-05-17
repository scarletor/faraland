using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TurnManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static TurnManager ins;
    private void Awake()
    {
        ins = this;
    }
    void Start()
    {
        if (GameManager.isDemo) return;

        Turn = TurnEnum.player;



    }

    // Update is called once per frame
    void Update()
    {

    }

    TurnEnum _turn;
    public GameObject pointer;
    public List<Button> action;
    public TurnEnum Turn
    {


        get { return _turn; }
        set
        {
            _turn = value;
            switch (value)
            {
                case TurnEnum.enemy:
                    Debug.LogError("WTF112222??");

                    foreach (Button btn in action)
                    {
                        btn.interactable = false;
                    }

                    pointer.transform.position = new Vector2(10, -8);
                    EnemyMove();


                    break;


                case TurnEnum.player:
                    Debug.LogError("WTF11??");
                    foreach (Button btn in action)
                    {
                        btn.interactable = true;
                    }
                    pointer.transform.position = new Vector2(-10, -8);


                    foreach (UnityEngine.Transform go in elementalWaitList)
                    {
                        go.gameObject.GetComponent<Skill_Base>().ElementalFire();
                        Skill_Base.canfire = true;
                    }

                    break;

            }


        }


    }

    public void NextTurn()
    {
        if (Turn == TurnEnum.player)
        {
            Turn = TurnEnum.enemy;
            return;
        }

        if (Turn == TurnEnum.enemy)
        {
            DOVirtual.DelayedCall(1, () =>
            {
                Turn = TurnEnum.player;

                return;

            });


           

        }
    }



    public List<Transform> elementalWaitList;
    public void EnemyMove()
    {

            var id = Random.Range(2, 6);

            CharacterControl.enemyFront.gameObject.transform.GetChild(id).gameObject.SetActive(true);



    }

    public void DisablePlayerBtn()
    {
        foreach (Button btn in action)
        {
            btn.interactable = false;
        }
    }

}
public enum TurnEnum
{
    enemy,
    player
}
