using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // enum/int Traits
    // List of connections
    [Header("Traits")]
    private int eyes = 0;
    private int nose = 0;
    private int ear = 0;

    [SerializeField] private Sprite sEye;
    [SerializeField] private Sprite sNose;
    [SerializeField] private Sprite sEar;

    public List<GameObject> Connections = new List<GameObject> ();
    public GameObject Parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTrait(Sprite newEye)
    {
        sEye = newEye;
    }

    public Sprite GetEye()
    {
        return sEye;
    }

}
