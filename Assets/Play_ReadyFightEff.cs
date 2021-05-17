using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Play_ReadyFightEff : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        StartReadyFightEff();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public SpriteRenderer readySprite, fightSprite;


    public void StartReadyFightEff()
    {


        fightSprite.transform.localScale = new Vector2(4, 4);
        readySprite.gameObject.SetActive(true);
        readySprite.color = new Color(1, 1, 1, 0);
        readySprite.DOFade(1, 1).OnComplete(() =>
        {

            DOVirtual.DelayedCall(1, () =>
            {

                readySprite.DOFade(0, .3f).
                OnComplete(() =>
                {
                    fightSprite.gameObject.SetActive(true);

                    fightSprite.DOFade(1, 1).
                    OnComplete(() =>
                    {

                        fightSprite.DOFade(0, .3f);
                        fightSprite.transform.DOScale(new Vector2(10, 10), .3f);
                    });


                });



            });
        });

    }

}
