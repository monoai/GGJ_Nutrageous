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
    private int ears = 0;

    [SerializeField] private Sprite sEyes;
    [SerializeField] private Sprite sNose;
    [SerializeField] private Sprite sEars;

    public List<Node> Connections = new List<Node> ();
    public GameObject Parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTrait(TraitNames.Traits trait, TraitNames.Attributes attribute)
    {
        switch (trait)
        {
            case TraitNames.Traits.Ears:
                ears = (int)attribute;
                break;
            case TraitNames.Traits.Nose:
                nose = (int)attribute;
                break;
            case TraitNames.Traits.Eyes:
                eyes = (int)attribute;
                break;
            default:
                break;
        }
    }

    public int GetTraits(TraitNames.Traits trait)
    {
        switch (trait)
        {
            case TraitNames.Traits.Ears:
                return ears;
            case TraitNames.Traits.Nose:
                return nose;
            case TraitNames.Traits.Eyes:
                return eyes;
            default:
                return 0;
        }
    }

}
