/// TraitTreeDriver.cs
/// D12 Team

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Classes.Character;
using Assets.Classes.Traits;
using UnityEngine;

public class TraitTreeDriver : MonoBehaviour
{

    // Character in context of the scene. The scene should reflect the character's internal TraitSystem.
    public BaseCharacter character;

    public GameObject ling1, ling2, ling3, ling4, ling5, multilinguist, transcriber, archlinguist, globalLinguist;

    public Trait selectedTrait;

    // Use this for initialization
    void Start()
    {

        // will need to modify this when saving is implemented
        character = new BaseCharacter();

        // link up all the gameobjects and traits
        var tree = character.TraitTrees.AccumenTree;

        ling1.GetComponent<TraitScript>().trait = tree.linguist1;
        ling2.GetComponent<TraitScript>().trait = tree.linguist2;
        ling3.GetComponent<TraitScript>().trait = tree.linguist3;
        ling4.GetComponent<TraitScript>().trait = tree.linguist4;
        ling5.GetComponent<TraitScript>().trait = tree.linguist5;
        multilinguist.GetComponent<TraitScript>().trait = tree.multilinguist;
        transcriber.GetComponent<TraitScript>().trait = tree.transcriber;
        archlinguist.GetComponent<TraitScript>().trait = tree.archlinguist;
        globalLinguist.GetComponent<TraitScript>().trait = tree.globalLocal;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TryPurchase()
    {
        if (selectedTrait.parents.Any(i => i.Active == true))
        {

            selectedTrait.Active = true;
        }
    }
}
