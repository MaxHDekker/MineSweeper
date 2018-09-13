using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridButCooler : MonoBehaviour
{
    public static int w = 20;
    public static int h = 20;
    public static Element[,] elements = new Element[w, h];
    private int checkMine = 8;

    public static void UncoverMines()
    {
        foreach (Element elem in elements)
        {
            if (elem.mine)
            {
                elem.loadTexture(0);
            }
        }
    }

    public static int adjacentMines(int x, int y)
    {
        int count = 0;

        if (mineAt(x, y + 1))
        {
            ++count;
        }
        if (mineAt(x + 1, y + 1))
        {
            ++count;
        }
        if (mineAt(x + 1, y))
        {
            ++count;
        }
        if (mineAt(x + 1, y - 1))
        {
            ++count;
        }
        if (mineAt(x, y - 1))
        {
            ++count;
        }
        if (mineAt(x - 1, y - 1))
        {
            ++count;
        }
        if (mineAt(x - 1, y))
        {
            ++count;
        }
        if (mineAt(x - 1, y + 1))
        {
            ++count;
        }

        return count;
    }

    public static bool mineAt(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            return elements[x, y].mine;
        }
        return false;
    }

    public static void floodfill(int x, int y, bool[,] visited)
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            if (visited[x, y])
            {
                return;
            }

            elements[x, y].loadTexture(adjacentMines(x, y));

            if (adjacentMines(x, y) > 0)
            {
                return;
            }

            visited[x, y] = true;

            floodfill(x - 1, y, visited);
            floodfill(x + 1, y, visited);
            floodfill(x, y - 1, visited);
            floodfill(x, y + 1, visited);

        }
    }
}