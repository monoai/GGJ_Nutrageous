using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinCondition : MonoBehaviour
{
    public GameObject winningNode;

    public UnityEvent winEvent;
    public UnityEvent loseEvent;

    public void CheckNode(GameObject node)
    {
        if (node == winningNode)
        {
            winEvent?.Invoke();
            Debug.Log("Win");
        }
        else
        {
            Debug.Log("Lose");
            loseEvent?.Invoke();
        }
    }
}
