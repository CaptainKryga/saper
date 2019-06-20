using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Xml.Linq;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject cell;
    public Sprite mine;
    public Sprite floor;
    public Sprite green;
    public Sprite flag;

    public int mines = 5;

    public GameObject[,] map = new GameObject[5,5];
    // Start is called before the first frame update
    void Start()
    {
        int x, y, bomb;
        for (y = 0; y < 5; y++)
        {
            for (x = 0; x < 5; x++)
            {
                map[y, x] = Instantiate(cell);
                map[y, x].transform.position = new Vector2(x * 1.5f, y * -1.5f);
                map[y, x].GetComponent<GameCell>().x = x;
                map[y, x].GetComponent<GameCell>().y = y;
            }
        }

        bomb = mines;
        while (bomb > 0)
        {
            x = Random.Range(0, 5);
            y = Random.Range(0, 5);
            if (map[y, x].GetComponent<GameCell>().mine == false)
            {
                map[y, x].GetComponent<SpriteRenderer>().sprite = mine;
                map[y, x].GetComponent<GameCell>().mine = true;
                map[y, x].transform.Find("number").gameObject.SetActive(false);
                bomb--;
            }
        }

        for (y = 0; y < 5; y++)
        {
            for (x = 0; x < 5; x++)
            {
                map[y,x].transform.Find("number").GetComponent<TextMesh>().text = "" + checkMines(x, y);
            }
        }
    }

    int checkMines(int x, int y)
    {
        int xx, yy, mine;
        mine = 0;
        xx = -1;
        yy = 1;
        while (yy > -2)
        {
            xx = -1;
            while (xx < 2)
            {
                if (y + yy >= 0 && y + yy < 5 && x + xx >= 0 && x + xx < 5 &&
                    map[y + yy, x + xx].GetComponent<GameCell>().mine)
                    mine++;
                xx++;
            }
            yy--;
        }
        return (mine);
    }
    
}
