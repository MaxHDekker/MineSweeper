using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public GameObject retry;

    public bool mine;

    [SerializeField]
    private Sprite[] emptytextures;

    [SerializeField]
    private Sprite minetextures;

    void Start()
    {
        mine = Random.value < 0.15;

        int x = (int)transform.position.x;
        int y = (int)transform.position.y;
        GridButCooler.elements[x, y] = this;
    }

    public void loadTexture(int count)
    {
        if (mine)
        {
            GetComponent<SpriteRenderer>().sprite = minetextures;
        }
        else GetComponent<SpriteRenderer>().sprite = emptytextures[count];
    }

    public bool isCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "default";
    }

    void OnMouseUpAsButton()
    {

        if (mine)
        {
            GridButCooler.UncoverMines();
            return;
        }
        else
        {
            int x = (int)transform.position.x;
            int y = (int)transform.position.y;
            loadTexture(GridButCooler.adjacentMines(x, y));

            GridButCooler.floodfill(x, y, new bool[GridButCooler.w, GridButCooler.h]);
        }
    }
}

