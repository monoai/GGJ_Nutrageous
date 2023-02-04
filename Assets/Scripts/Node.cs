using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    // enum/int Traits
    // List of connections
    [Header("Characteristics")]
    private int eyes = 0;
    private int nose = 0;
    private int ears = 0;

    private int hair = 0;
    private int makeup = 0;

    private int frame = 0;

    [Header("Node Flags")]
    private bool isHidden = false;
    private bool isPlayer = false;
    private int depth = 0;

    [SerializeField] private Sprite sEyes;
    [SerializeField] private Sprite sNose;
    [SerializeField] private Sprite sEars;

    [SerializeField] private Sprite sHair;
    [SerializeField] private Sprite sMakeup;

    [SerializeField] private Sprite sFrame;

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

    public void SetHidden(bool newBool)
    {
        isHidden = newBool;
    }

    public void SetDepth(int newDepth)
    {
        depth = newDepth;
    }

    public void SetPlayerFlag(bool newBool)
    {
        isPlayer = newBool;
    }

    public bool GetPlayerFlag()
    {
        return isPlayer;
    }

    public void SetTrait(TraitNames.Traits trait, TraitNames.Attributes attribute, TraitNames.Hair newHair, TraitNames.Makeup newMakeup)
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
            case TraitNames.Traits.Hair:
                hair = (int)newHair;
                break;
            case TraitNames.Traits.Makeup:
                makeup = (int)newMakeup;
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
            case TraitNames.Traits.Makeup:
                return hair;
            case TraitNames.Traits.Hair:
                return makeup;
            default:
                return 0;
        }
    }

}
