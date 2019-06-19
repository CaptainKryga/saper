using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCell : MonoBehaviour
{
    public bool mine;

    private void OnMouseDown()
    {
        Destroy(gameObject.transform.Find("green").gameObject);
        print("!!!!!");
    }
}
