using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMovement : MonoBehaviour
{
    public string tagToCheck;
    RaycastHit hit;
    [SerializeField]
    float rayLength;
    public bool canMove = true;
    public bool isHittingObstacle = false;

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.up, out hit, rayLength) && hit.transform.tag == "ValidMove")
        {
            canMove = true;
        }
        else if (Physics.Raycast(transform.position, transform.up, out hit, rayLength) && hit.transform.tag == "Obstacle")
        {
            isHittingObstacle = true;
        }
        else
        {
            canMove = false;
            isHittingObstacle = false;
        }
    }
}
