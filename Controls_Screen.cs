using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controls_Screen : MonoBehaviour
{
    public GameObject continueButton;
    
    // Start is called before the first frame update
    void Start()
    {
        continueButton.SetActive(false);
        StartCoroutine(Wait());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene(3);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        continueButton.SetActive(true);
    }
}
