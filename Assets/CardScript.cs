using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 originalPos;
    private bool hovered;

    private float max = 50f;
    private void Start()
    {
        originalPos = transform.position;
    }

    private void Update()
    {
        if (hovered)
        {
           
            if(transform.position.y <= originalPos.y + max) 
            transform.position = Vector3.MoveTowards(transform.position,
             new Vector3(transform.position.x, transform.position.y + 50, transform.position.z), 10);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,
             new Vector3(originalPos.x, originalPos.y, originalPos.z), 10);
        }
    }

    public void SetHover(bool param)
    {
        hovered = param;
    }

    
}
