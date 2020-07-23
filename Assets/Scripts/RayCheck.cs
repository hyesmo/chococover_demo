using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCheck : MonoBehaviour
{
    public ParticleSystem splashParticle;
    RaycastHit hit;
    [SerializeField]
    float rayLength;
    public bool didHit;
    public bool didPlay = false;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.up * rayLength, Color.green);
        if(Physics.Raycast (transform.position, transform.up, out hit, rayLength) && hit.transform.tag == "Chocolate"){
            didHit = true;
            PlayParticle();
            Debug.Log("i hit chocolate. " + gameObject.name);
        }
        if(Physics.Raycast (transform.position, transform.up, out hit, rayLength) && hit.transform.tag == "Obstacle"){
            canMove = false;
            Debug.Log("i hit an obstacle. " + gameObject.name);
        }
        else{
            canMove = true;
        }
    }
    
    void PlayParticle(){
        if(!didPlay && didHit){
            splashParticle.Play();
            didPlay = true;
        }
    }
}
