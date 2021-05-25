using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class ShowMenu : MonoBehaviour
{
    public GameObject menu;
    private bool isShowing=false;

    private static readonly int key_count = 15;
    private readonly string[] js_buttons = new string[key_count];

    public Button Move;
    public Button Rotate;
    public Button ChangeColor;
    public Button ClearAction;
    public Button Exit;

    [SerializeField] private float speed;
    [SerializeField] private Vector3 axis = new Vector3(1, 1, 0);
    private bool isOriginalColor = true;

    private bool move;
    private bool rotate;
    private bool changeColor;
    //private bool clearAction;
    //private bool exit;
    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(isShowing);
        if (gameObject != null)
        {
            gameObject.GetComponent<Outline>().enabled = false;
        }
    }

    void enable()
    {
        Move.onClick.AddListener(() => moveCallBack()); 
        Rotate.onClick.AddListener(() => rotateCallBack());
        ChangeColor.onClick.AddListener(() => changeColorCallBack());
        ClearAction.onClick.AddListener(() => clearActionCallBack());
        Exit.onClick.AddListener(() => exitCallBack());
    }

    

    private void moveCallBack() 
    {
        move = true;
        rotate = false;
        changeColor = false;
        
        //isShowing = !isShowing;
        menu.SetActive(false);
    }

    private void rotateCallBack()
    {
        move = false;
        rotate = true;
        changeColor = false;
        
        //isShowing = !isShowing;
        menu.SetActive(false);
    }

    private void changeColorCallBack()
    {
        move = false;
        rotate = false;
        changeColor = true;
        
        //isShowing = !isShowing;
        menu.SetActive(false);
    }

    private void clearActionCallBack() 
    {
        move = false;
        rotate = false;
        changeColor = false;
        
        //isShowing = !isShowing;
        menu.SetActive(false);
    }

    private void exitCallBack() 
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (Input.GetKeyDown("escape"))
        //{
        //    isShowing = !isShowing;
        //    menu.SetActive(isShowing);
        //}

        

        if (Input.GetButton("Fire1"))
        {
            isShowing = !isShowing;
            menu.SetActive(isShowing);
        }

        if (Input.GetButton("Submit"))
        {
            //mapCallbacks();
        }

        if (move) 
        {
            gameObject.transform.position += new Vector3(speed, 0, 0);
        }
        if (rotate)
        {
            gameObject.transform.Rotate(axis, speed);
        }

        if (Input.anyKey)
        {
            
            for (int i = 0; i < js_buttons.Length; i++)
            {
                if (Input.GetButton(js_buttons[i]))
                {
                    Debug.Log(string.Format("joystick button {0}\n", i)) ;
                }
            }
        }
    }


    public void PointerDown()
    {
        if (move)
        {
            speed = .003F;
        }
        if (rotate)
        {
            speed = .3F;
        }
    }

    public void PointerUp()
    {
        if (move == true || rotate == true)
        {
            speed = 0;
        }
    }

    public void PointerExit()
    {
        gameObject.GetComponent<Outline>().enabled = false;
        if (move == true || rotate == true)
        {
            speed = 0;
        }
    }
    public void PointerEnter()
    {
        gameObject.GetComponent<Outline>().enabled = true;
    }

    public void PointerClick()
    {
        if (changeColor == true)
        {
            if (isOriginalColor)
            {
                gameObject.GetComponent<Renderer>().material.color = Random.ColorHSV();
                isOriginalColor = false;
            }
            else
            {
                gameObject.GetComponent<Renderer>().material.color = Color.white;
                isOriginalColor = true;
            }
        }
    }
}
