using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitch : MonoBehaviour
{

    public GameObject cam1;
    public GameObject cam2;
    bool cam1Bool;
    bool cam2Bool;


    // Start is called before the first frame update

    void Start()
    {

        cam1.SetActive(true);
        cam2.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
           
            cam1.SetActive(!cam1.activeInHierarchy);
            cam2.SetActive(!cam2.activeInHierarchy);

        }

    }
}
