using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ChocolateScript : MonoBehaviour
{
    public GameObject greatText;
    public GameObject greatText2;
    public GameObject FaceL;
    public GameObject FaceR;
    public GameObject FaceF;
    public GameObject FaceB;

    public RayCheck rayL;
    public RayCheck rayR;
    public RayCheck rayF;
    public RayCheck rayB;

    public ParticleSystem starExplosion;
    public PlayerController playerCont;
    public GameObject fork;
    public bool didPlay;
    public Transform exitLocation;
    public GameObject cam;
    public Transform cameraDest;

    void Update()
    {
        if (!rayL.didHit || !rayB.didHit || !rayR.didHit || !rayF.didHit)
        {
            playerCont.moveText.text = playerCont.moveCount + " Moves Left";
            playerCont.moveText2.text = playerCont.moveCount + " Moves Left";
            if (playerCont.moveCount <= 0)
            {
                playerCont.canPlay = false;
                playerCont.levelFailedText.SetActive(true);
            }
        }


        FaceL.SetActive(rayL.didHit);
        FaceR.SetActive(rayR.didHit);
        FaceF.SetActive(rayF.didHit);
        FaceB.SetActive(rayB.didHit);

        if (rayL.didHit && rayB.didHit && rayR.didHit && rayF.didHit)
        {
            StartCoroutine(Ending());
            playerCont.canPlay = false;
            playerCont.moveText.text = "";
            playerCont.moveText2.text = "";
        }

    }

    IEnumerator Ending()
    {

        if (!didPlay && !playerCont.canPlay)
        {
            didPlay = true;
            greatText.SetActive(true);
            greatText2.SetActive(true);
            fork.GetComponent<Rigidbody>().isKinematic = true;
            DOTween.Sequence()
            .Append(fork.transform.DOMove(new Vector3(fork.transform.position.x, fork.transform.position.y + 1, fork.transform.position.z), 0.5f))
            .Append(fork.transform.DORotate(new Vector3(990, 0, 0), 1f, RotateMode.LocalAxisAdd))
            .Append(fork.transform.DOMove(exitLocation.position, 1f));
            Instantiate(starExplosion, fork.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
            greatText.SetActive(false);
            greatText2.SetActive(false);
            cam.transform.DOMove(cameraDest.position, 1f);
        }
    }
}
