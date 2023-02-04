using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Casilla
{
    empty,
    rock,
    greenRoot,
    redRoot,
    blueRoot,
    greenWater,
    redWater,
    blueWater,
    redTree,
    greenTree,
    blueTree
}

public class Roots : MonoBehaviour
{
    public int numX, numY;
    public GameObject rock;
    public GameObject redRoot, greenRoot, blueRoot;
    public GameObject redTree, greenTree, blueTree;
    public GameObject redWater, greenWater, blueWater;
    public Casilla[,] roots;

    public List<GameObject> mapItems;


    private void Awake()
    {
        roots = new Casilla[numX, numY];
        for (int i = 0; i < numX; i++)
        {
            for (int j = 0; j < numY; j++)
            {
                roots[i,j] = Casilla.empty;
            }
        }

        mapItems = new List<GameObject>();
    }

    public void Expand( Casilla tipe )
    {
        Debug.Log("eo1");
        bool[,] toExpand = new bool[numX, numY];
        for ( int i = 0; i < numX; i++ )
        {
            for (int j = 0; j < numY; j++)
            {
                if(roots[i,j] == Casilla.empty && AdyacentOfColor( i,  j, tipe) )
                {
                    Debug.Log("eo2");
                    toExpand[i, j] = true;
                }
            }
        }

        for (int i = 0; i < numX; i++)
        {
            for (int j = 0; j < numY; j++)
            {
                if (toExpand[i, j] == true)
                {
                    Debug.Log("eo3");
                    roots[i, j] = tipe;
                    placeTile(i, j, tipe);
                }
            }
        }
    }

    private bool AdyacentOfColor(int x, int y, Casilla tipe)
    {
        bool adyacent = false;
        Casilla c;

        if (x - 1 >= 0)
        {
            c = roots[x - 1, y];
            if (c == tipe)
                adyacent = true;

        }
        if (y - 1 >= 0)
        {
            c = roots[x, y - 1];
            if (c == tipe)
                adyacent = true;
        }
        if (x + 1 < numX)
        {
            c = roots[x + 1, y];
            if (c == tipe)
                adyacent = true;
        }
        if (y + 1 < numY)
        {
            c = roots[x, y + 1];
            if (c == tipe)
                adyacent = true;
        }

        return adyacent;
    }

    public GameObject placeTile( int i, int j, Casilla tipe, bool setTransparent = false )
    {
        GameObject newObj = new GameObject();

        if (tipe == Casilla.rock)
        {
            newObj = Instantiate(rock, transform.position + new Vector3(i, j, 0), transform.rotation);
        }

        if ( tipe == Casilla.redRoot)
        {
            newObj = Instantiate(redRoot, transform.position + new Vector3(i, j, 0), transform.rotation);
            mapItems.Add(newObj);
        }

        if (tipe == Casilla.greenRoot)
        {
            newObj = Instantiate(greenRoot, transform.position + new Vector3(i, j, 0), transform.rotation);
            mapItems.Add(newObj);
        }

        if (tipe == Casilla.blueRoot)
        {
            newObj = Instantiate(blueRoot, transform.position + new Vector3(i, j, 0), transform.rotation);
            mapItems.Add(newObj);
        }

        if (tipe == Casilla.redTree)
        {
            newObj = Instantiate(redTree, transform.position + new Vector3(i, j, 0), transform.rotation);
            newObj.GetComponent<TreeScript>().initRoots(this);
        }

        if (tipe == Casilla.greenTree)
        {
            newObj = Instantiate(greenTree, transform.position + new Vector3(i, j, 0), transform.rotation);
            newObj.GetComponent<TreeScript>().initRoots(this);
        }

        if (tipe == Casilla.blueTree)
        {
            newObj = Instantiate(blueTree, transform.position + new Vector3(i, j, 0), transform.rotation);
            newObj.GetComponent<TreeScript>().initRoots(this);
        }

        if (tipe == Casilla.redWater)
        {
            newObj = Instantiate(redWater, transform.position + new Vector3(i, j, 0), transform.rotation);
        }

        if (tipe == Casilla.greenWater)
        {
            newObj = Instantiate(greenWater, transform.position + new Vector3(i, j, 0), transform.rotation);
        }

        if (tipe == Casilla.blueWater)
        {
            newObj = Instantiate(blueWater, transform.position + new Vector3(i, j, 0), transform.rotation);
        }


        if ( setTransparent )
        {
            newObj.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        }

        return newObj;
    }


}
