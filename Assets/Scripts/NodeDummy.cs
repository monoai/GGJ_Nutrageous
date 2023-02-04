using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeDummy : MonoBehaviour
{
    // Only purpose is to do things while the proper actual node object hasnt been implemented yet

    [Header("Traits")]
    [SerializeField] private int eyes = 0;
    [SerializeField] private int nose = 0;
    [SerializeField] private int mouth = 0;
    [SerializeField] private int ears = 0;

    [Header("Personality")]
    [SerializeField] private int girlBoss = 0;
    [SerializeField] private int poopPoster = 0;

    public void SetTrait(TraitNames.Traits trait, TraitNames.Attributes attrib) {
	// A large if-statement going through all the traits to assign this node the proper trait and attribute.
	//trait = newVal;
    }

    // Work in Progress
    public void SetPersonality(int newVal){
	//personality = newVal;
    }
}
