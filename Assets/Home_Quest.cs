using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Home_Quest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OnClickDaily();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public GameObject dailyBtn, achievementBtn, dailyScrollView, achievementScrollView, coinPref, coinUIPos;


    public void OnClickDaily()
    {
        dailyBtn.GetComponent<CanvasGroup>().alpha = 1f;
        achievementBtn.GetComponent<CanvasGroup>().alpha = .4f;
        dailyScrollView.SetActive(true);
        achievementScrollView.SetActive(false);

    }

    public void OnClickAchievement()
    {
        dailyBtn.GetComponent<CanvasGroup>().alpha = .4f;
        achievementBtn.GetComponent<CanvasGroup>().alpha = 1f;
        dailyScrollView.SetActive(false);
        achievementScrollView.SetActive(true);

    }

    public void OnClickClaim(GameObject btn)
    {
        Debug.LogError("CLICK CLAM");

        for (int i = 0; i < 10; i++)
        {
            Debug.LogError("CLICK CLAM22");

            DOVirtual.DelayedCall(.1f * i, () =>
            {
                var newCoinEff = Instantiate(coinPref, btn.transform.position, Quaternion.identity, transform.parent);
                newCoinEff.transform.DOJump(new Vector2(btn.transform.position.x + Random.Range(-3, 3), btn.transform.position.y + Random.Range(-3, 3)), 1, 1, .5f, false).OnComplete(() =>
                    {
                        newCoinEff.transform.DOMove(coinUIPos.transform.position, 1).OnComplete(() =>
                        {
                            Destroy(newCoinEff);


                        }); ;
                    })


                ;
            });
        }
    }












}




