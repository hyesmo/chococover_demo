using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject distA;
    public GameObject distB;
    Vector3 targetPos;
    [SerializeField]
    float distance;
    public bool canPlay = true;
    public CheckMovement rayL;
    public CheckMovement rayR;
    public CheckMovement rayF;
    public CheckMovement rayB;
    public CheckMovement forkR1;
    public CheckMovement forkR2;
    public CheckMovement forkL1;
    public CheckMovement forkL2;
    public TextMeshProUGUI moveText;
    public TextMeshProUGUI moveText2;
    public GameObject levelFailedText;

    public int moveCount = 15;

    // Start is called before the first frame update
    void Start()
    {
        distance = Vector3.Distance(distB.transform.position, distA.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (canPlay)
        {
            //main movement
            if (Input.GetKeyDown(KeyCode.A) && rayL.canMove && !forkL1.isHittingObstacle && !forkL2.isHittingObstacle)
            {
                moveCount -= 1;
                transform.DOMove(new Vector3(transform.position.x, transform.position.y, transform.position.z - distance), .3f, false);
                DOTween.Sequence().Append(transform.DORotate(new Vector3(-90, 0, 0), .3f, RotateMode.LocalAxisAdd)).Append(transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), .3f));
            }
            if (Input.GetKeyDown(KeyCode.D) && rayR.canMove && !forkR1.isHittingObstacle && !forkR2.isHittingObstacle)
            {
                moveCount -= 1;
                transform.DOMove(new Vector3(transform.position.x, transform.position.y, transform.position.z + distance), .3f, false);
                DOTween.Sequence().Append(transform.DORotate(new Vector3(90, 0, 0), .3f, RotateMode.LocalAxisAdd)).Append(transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), .3f));
            }
            if (Input.GetKeyDown(KeyCode.W) && rayF.canMove)
            {
                moveCount -= 1;
                DOTween.Sequence().Append(transform.DOMove(new Vector3(transform.position.x - distance, transform.position.y, transform.position.z), 0.3f)).Append(transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), .2f));
            }
            if (Input.GetKeyDown(KeyCode.S) && rayB.canMove)
            {
                moveCount -= 1;
                DOTween.Sequence().Append(transform.DOMove(new Vector3(transform.position.x + distance, transform.position.y, transform.position.z), 0.3f)).Append(transform.DOPunchScale(new Vector3(0.1f, 0.1f, 0.1f), .3f));
            }

            //cant move anims
            if (Input.GetKeyDown(KeyCode.A) && forkL1.isHittingObstacle || forkL2.isHittingObstacle)
            {
                DOTween.Sequence().Append(transform.DORotate(new Vector3(-20, 0, 0), .1f, RotateMode.LocalAxisAdd)).Append(transform.DORotate(new Vector3(20, 0, 0), .1f, RotateMode.LocalAxisAdd));
            }
            if (Input.GetKeyDown(KeyCode.D) && forkR1.isHittingObstacle || forkR2.isHittingObstacle)
            {
                DOTween.Sequence().Append(transform.DORotate(new Vector3(20, 0, 0), .1f, RotateMode.LocalAxisAdd)).Append(transform.DORotate(new Vector3(-20, 0, 0), .1f, RotateMode.LocalAxisAdd));
            }

        }


    }
}
