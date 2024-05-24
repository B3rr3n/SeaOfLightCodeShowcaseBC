using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPHide : MonoBehaviour
{

    public GameObject PostP;
    
    // Start is called before the first frame update
    void Start()
    {
        PostP.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        PostP.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        PostP.SetActive(false);
    }
}
