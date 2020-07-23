using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class RotateChoco : MonoBehaviour
{
    public GameObject lpText;
    public GameObject lpText2;
    public GameObject cam;
    public GameObject camPos;
    Animator anim;
    bool didPlay;
    public ParticleSystem fallParticle;
    public ParticleSystem confetti;
    public ParticleSystem starParticle;
    public ParticleSystem risingSun;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.DORotate(new Vector3(0,2,0), 0.1f, RotateMode.LocalAxisAdd);
        if(cam.transform.position == camPos.transform.position && !didPlay){
            StartCoroutine(EndAnimSeq());
        }
    }

    IEnumerator EndAnimSeq(){
        didPlay = true;
        fallParticle.Play();
        yield return new WaitForSeconds(4f);
        anim.SetBool("camOnPos", true);
        yield return new WaitForSeconds(1.24f);
        anim.SetBool("camOnPos", false);
        starParticle.Stop();
        lpText.SetActive(true);
        lpText2.SetActive(true);
        risingSun.Play();
    }

    void PlayConfetti(){
        confetti.Play();
    }
}
