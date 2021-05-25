using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{
    public bool active;
    public Button b;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        
        b = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active == true && Input.GetButton("Submit"))
        {
            b.onClick.Invoke();
            
        }
    }


    public void PointerEnter()
    {
        active = true;
    }

    public void PointerExit()
    {
        active = false;
    }
}
