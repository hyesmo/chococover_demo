using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class camIntro : MonoBehaviour
{
    public Transform playDest;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOMove(playDest.position, 1f, false);
    }
}
