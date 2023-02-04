using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private GameObject person;

    [Header("Characteristics")]
    [SerializeField] private int eyes = 0;
    [SerializeField] private int nose = 0;
    [SerializeField] private int ears = 0;

    [SerializeField] private int hair = 0;
    [SerializeField] private int makeup = 0;

    [SerializeField] private int frame = 0;

    [Header("Node Flags")]
    private bool isHidden = false;
    private bool isPlayer = false;
    private int depth = 0;

    [SerializeField] private SpriteRenderer sEyes;
    [SerializeField] private SpriteRenderer sNose;
    [SerializeField] private SpriteRenderer sEars;

    [SerializeField] private SpriteRenderer sHair;
    [SerializeField] private SpriteRenderer sMakeup;

    [SerializeField] private SpriteRenderer sFrame;

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
	/*
            case TraitNames.Traits.Hair:
                hair = (int)newHair;
                break;
            case TraitNames.Traits.Makeup:
                makeup = (int)newMakeup;
                break;
	*/
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
                return makeup;
            case TraitNames.Traits.Hair:
                return hair;
            case TraitNames.Traits.Frame:
                return frame;
            default:
                return 0;
        }
    }

    public void SetHair(TraitNames.Traits trait, TraitNames.Hair newHair) {
	hair = (int)newHair;
    }

    public void SetMakeup(TraitNames.Traits trait, TraitNames.Makeup newMakeup) {
	makeup = (int)newMakeup;
    }
    
    public void SetFrame(TraitNames.Traits trait, TraitNames.Frame newFrame){
    frame = (int)newFrame;
    }

    public void SetSprite(TraitNames.Traits trait, Sprite newSprite)
    {
        switch (trait)
        {
            case TraitNames.Traits.Ears:
                sEars.sprite = newSprite;
                break;
            case TraitNames.Traits.Nose:
                sNose.sprite = newSprite;
                break;
            case TraitNames.Traits.Eyes:
                sEyes.sprite = newSprite;
                break;
            case TraitNames.Traits.Makeup:
                sMakeup.sprite = newSprite;
                break;
            case TraitNames.Traits.Hair:
                sHair.sprite = newSprite;
                break;
            case TraitNames.Traits.Frame:
                sFrame.sprite = newSprite;
                break;
            default:
                break;
        }
    }

    public void SetOpacity()
    {
        if (isHidden)
        {
            person.SetActive(false);
        }
        else
        {
            person.SetActive(true);
        }

        Color color = sFrame.color;
        color.a = 0.25f;
        sFrame.color = color;
    }
}
