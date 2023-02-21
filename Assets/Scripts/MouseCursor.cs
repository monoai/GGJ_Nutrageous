using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public Texture2D cursor;
    public Animator animator;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        ChangeCursor(cursor);
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        ChangeCursor(cursor);
        if (Input.GetMouseButton(0))
        {
            //play flick animation
            animator.SetBool("isClick", true);
        }
        else
        {
            animator.SetBool("isClick", false);
        }
    }

    private void ChangeCursor(Texture2D cursorType)
    {
        //Vector2 hotspot = new Vector2(cursor.width, cursor.height/2);
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }
}
