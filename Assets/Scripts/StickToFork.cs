using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToFork : MonoBehaviour
{
    public GameObject fork;
    void Update()
    {
        transform.position = fork.transform.position;
    }
}
