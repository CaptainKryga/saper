using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlag : MonoBehaviour
{
    private bool mouse;

    void Start()
    {
        mouse = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && mouse)
        {
            if (transform.Find("green").GetComponent<SpriteRenderer>().sprite.name == "green")
                transform.Find("green").GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameController").GetComponent<GameStart>().flag;
            else
                transform.Find("green").GetComponent<SpriteRenderer>().sprite = GameObject.Find("GameController").GetComponent<GameStart>().green;
        }
    }
    void OnMouseEnter()
    {
        mouse = true;
    }
    void OnMouseExit()
    {
        mouse = false;
    }
}
