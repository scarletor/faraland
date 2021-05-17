using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CameraControl : MonoBehaviour
{

    public static CameraControl instant;
    private void Awake()
    {
        instant = this;
        canMoveCamera = true;
    }
    void Start()
    {
       
    }

    public void ShakeCamera()
    {
        gameObject.transform.DOShakePosition(.3f,.4f,4,33,false);
    }
    Camera _Cam;
    GameObject player, enemy;
    public GameObject posLeft, posRight, posUp, posDown, middle;
    Vector3 smoothPos;
    float cameraSpeed;
    public bool touchUp, touchDown, touchLeft, touchRight, enemyTouchCorner, playerTouchCorner;

    float speedScaleCamera = .05f;
    public bool canMoveCamera;

    // Update is called once per frame
    void FixedUpdate()
    {
        return;
        if (canMoveCamera == false) return;
        Debug.DrawLine(player.transform.position, enemy.transform.position);
        middle.transform.position = (enemy.transform.position + player.transform.position) / 2;

        var pos = Vector3.Lerp(transform.position, middle.transform.position, Time.deltaTime * 4);
        pos.z = -100;
        transform.position = pos;
        if (player.transform.position.x <= posLeft.transform.position.x ||
            player.transform.position.x > posRight.transform.position.x ||
            player.transform.position.y > posUp.transform.position.y ||
            player.transform.position.y < posDown.transform.position.y)
        {

            playerTouchCorner = true;
        }
        else
            playerTouchCorner = false;





        if (enemy.transform.position.x <= posLeft.transform.position.x ||
            enemy.transform.position.x >= posRight.transform.position.x ||
            enemy.transform.position.y >= posUp.transform.position.y ||
            enemy.transform.position.y <= posDown.transform.position.y)
        {
            enemyTouchCorner = true;
        }
        else
            enemyTouchCorner = false;



        //zoom out when move to corner
        if (enemyTouchCorner && playerTouchCorner && _Cam.orthographicSize < 18)
        {

            _Cam.orthographicSize += speedScaleCamera;
            gameObject.transform.localScale = new Vector3(_Cam.orthographicSize, _Cam.orthographicSize, _Cam.orthographicSize);
        }

        //zoom in when move to corner

        if (enemyTouchCorner == false && playerTouchCorner == false && _Cam.orthographicSize > 10)
        {
            _Cam.orthographicSize -= speedScaleCamera;
            gameObject.transform.localScale = new Vector3(_Cam.orthographicSize, _Cam.orthographicSize, _Cam.orthographicSize);
        }
    }

    int cameraSize=7;
    public void FocusCamera(bool isPlayer)
    {


        // change camera to player who casting the spell 
        // total time of this phase is 4 second
        // time casting spell is 2 second
        // after 2 second focus on playercast, camera change to center of 2 player in 2 second then this function is complete 


        //ZoomIn
        canMoveCamera = false;
        var target = isPlayer == true ? ReferenceAll.instant.player : ReferenceAll.instant.enemy;
        var pos = target.transform.position;
        pos.z = -100;
        transform.DOMove(pos, .5f);
        //call 20 times, each call increase 1/20 of amount
        amountChangePerCall = (_Cam.orthographicSize - cameraSize) / 20;
        InvokeRepeating("TweenCameraSizeZoomIn", 0, .02f);
        opacityBG.DOColor(new Color(0, 0, 0, .9f), .5f);
        wrapParticle1.SetActive(true);


        //zoomOut
        amountChangePerCallZoomOut = (_Cam.orthographicSize - cameraSize) / 20;
        lastSizeCamera = _Cam.orthographicSize;
        lastPosCamera = gameObject.transform.position;
        DOVirtual.DelayedCall(2, () =>
        {
            InvokeRepeating("TweenCameraSizeZoomOut", 0, .02f);
            gameObject.transform.DOMove(lastPosCamera, .5f);

        });




        DOVirtual.DelayedCall(4, () =>
        {
            opacityBG.DOColor(new Color(0, 0, 0, 0), 1f);
            canMoveCamera = true;

        });


    }
    public SpriteRenderer opacityBG;
    float amountChangePerCall;
    public void TweenCameraSizeZoomIn()
    {
        _Cam.orthographicSize -= amountChangePerCall;
        
        if (_Cam.orthographicSize <= cameraSize) CancelInvoke("TweenCameraSizeZoomIn");

        Debug.LogError("TWEENIN");
    }


    float amountChangePerCallZoomOut, lastSizeCamera;
    Vector3 lastPosCamera;
    public void TweenCameraSizeZoomOut()
    {
        _Cam.orthographicSize += amountChangePerCallZoomOut;

        if (_Cam.orthographicSize >= lastSizeCamera)
        {
            Debug.LogError(_Cam.orthographicSize);
            CancelInvoke("TweenCameraSizeZoomOut");
        }

        Debug.LogError("TWEENOUT");
    }

    public GameObject wrapParticle1;
}
