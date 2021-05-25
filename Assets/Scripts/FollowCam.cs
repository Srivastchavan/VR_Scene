using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowCam : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas canvas;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //canvas.transform.position = Camera.main.transform.position + camera.forward * distace;
        //canvas.transform.rotation = Camera.main.transform.rotation;
    }
}
