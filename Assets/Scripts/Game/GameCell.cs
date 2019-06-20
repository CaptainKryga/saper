using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCell : MonoBehaviour
{
    public bool mine, open;
    public int x, y;

    public bool mouse;
    public void Start()
    {
        open = false;
    }
    private void OnMouseDown()
    {
        if (!open && transform.Find("green").GetComponent<SpriteRenderer>().sprite.name == "green" &&
            gameObject.transform.Find("green").gameObject)
        {
            Destroy(gameObject.transform.Find("green").gameObject);
            if (mine)
            {
                GameObject.Find("GameController").GetComponent<GameController>().text.text = "You dead";
                GameObject.Find("GameController").GetComponent<GameController>().GameOver = true;
            }
            open = true;
            if (gameObject.transform.Find("number").GetComponent<TextMesh>().text == "0")
                isOpen(x, y);
        }
        if (check_win() == GameObject.Find("GameController").GetComponent<GameStart>().mines)
        {
            GameObject.Find("GameController").GetComponent<GameController>().text.text = "You win";
            GameObject.Find("GameController").GetComponent<GameController>().GameOver = true;
        }
        print("click to cell");
    }

    private int check_win()
    {
        int flags = 0; 
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                if (GameObject.Find("GameController").GetComponent<GameStart>().map[y, x].GetComponent<GameCell>().open == false)
                    flags++;
            }
        }
        return (flags);
    }
    
    void isOpen(int x, int y)
    {
        int xx, yy;
        xx = -1;
        yy = 1;
        while (yy > -2)
        {
            xx = -1;
            while (xx < 2)
            {
                if (y + yy >= 0 && y + yy < 5 && x + xx >= 0 && x + xx < 5)
                {
                    if (!GameObject.Find("GameController").GetComponent<GameStart>().map[y + yy, x + xx].GetComponent<GameCell>().open &&
                        GameObject.Find("GameController").GetComponent<GameStart>().map[y + yy, x + xx].transform.Find("number").GetComponent<TextMesh>().text == "0")
                    {
                        Destroy(GameObject.Find("GameController").GetComponent<GameStart>().map[y + yy, x + xx].transform.Find("green").gameObject);
                        GameObject.Find("GameController").GetComponent<GameStart>().map[y + yy, x + xx].GetComponent<GameCell>().open = true;
                        isOpen(x + xx, y + yy);
                    }
                    else if (!GameObject.Find("GameController").GetComponent<GameStart>().map[y + yy, x + xx].GetComponent<GameCell>().open)
                    {
                        Destroy(GameObject.Find("GameController").GetComponent<GameStart>().map[y + yy, x + xx].transform.Find("green").gameObject);
                        GameObject.Find("GameController").GetComponent<GameStart>().map[y + yy, x + xx].GetComponent<GameCell>().open = true;
                    }
                }
               
                xx++;
            }
            yy--;
        }
    }
    

}
