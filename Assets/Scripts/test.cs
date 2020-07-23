using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                StartCoroutine(ScaleMe(hit.transform));
                StartCoroutine(ColorMe(hit.transform.GetComponent<MeshRenderer>().material));
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
            }
        }


    }

    IEnumerator ScaleMe(Transform objTr)
    {
        objTr.DOScale(new Vector3(objTr.localScale.x * 4, objTr.localScale.y * 3, objTr.localScale.z * 2), 1f);
        yield return new WaitForSeconds(1f);
        objTr.DOScale(new Vector3(objTr.localScale.x / 4, objTr.localScale.y / 3, objTr.localScale.z / 2), 1f);
        yield return new WaitForSeconds(1f);
        objTr.DOScale(new Vector3(objTr.localScale.x * 5, objTr.localScale.y / 0.75f, objTr.localScale.z * 1.5f), 1f);
        yield return new WaitForSeconds(1f);
        objTr.DOScale(new Vector3(objTr.localScale.x / 5, objTr.localScale.y * 0.75f, objTr.localScale.z / 1.5f), 1f);
    }

    IEnumerator ColorMe(Material matTr){
        matTr.DOColor(Color.blue, 1f);
        yield return new WaitForSeconds(1f);
        matTr.DOColor(Color.red, 1f);
        yield return new WaitForSeconds(1f);
        matTr.DOColor(Color.green, 1f);
        yield return new WaitForSeconds(1f);
        matTr.DOColor(Color.white, 1f);
    }
}
