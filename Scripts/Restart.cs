using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{ 
    [SerializeField]
    private Color startcolor;
    [SerializeField]
    private Renderer renderer;

    void OnMouseEnter()
    {
        startcolor = renderer.material.color;
        renderer.material.color = Color.red;
    }
    void OnMouseExit()
    {
        renderer.material.color = startcolor;
    }

    void OnMouseDown()
    {
        Application.LoadLevel(0);
    }
}
