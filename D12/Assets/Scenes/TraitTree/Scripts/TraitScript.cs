/// TraitScript.cs
/// D12 Team

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Classes.Traits;
using UnityEngine;
using UnityEngine.UI;

public class TraitScript : MonoBehaviour
{
    public Trait trait;

    public Text nameBox, descBox, costBox, activeBox;

    public GameObject driver;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick()
    {
        // set the selected trait
        driver.GetComponent<TraitTreeDriver>().selectedTrait = trait;

        nameBox.text = trait.Name;
        descBox.text = trait.Desc;
        costBox.text = "EXP COST: " + trait.Cost.ToString();

        // if the trait is active and all of its children are inactive, display active
        if (trait.Active && trait.children.All(i => !i.Active))
        {
            activeBox.text = "ACTIVE";
            activeBox.color = Color.green;
        }
        // if trait is active but has an active child, it has been purchased already
        else if (trait.Active && trait.children.Any(i => i.Active))
        {
            activeBox.text = "PURCHASED";
            activeBox.color = Color.grey;
        }
        // if trait is inactive, has an active parent, and no active siblings
        else if(!trait.Active && trait.parents.Any(i => i.Active) && trait.parents.All(i => i.children.All(t => !t.Active)))
        {
            activeBox.text = "PURCHASABLE";
            activeBox.color = Color.yellow;
        }
        else
        {
            activeBox.text = "LOCKED";
            activeBox.color = Color.red;
        }
    }
}
