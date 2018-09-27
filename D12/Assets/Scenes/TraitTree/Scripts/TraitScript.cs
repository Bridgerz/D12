/// TraitScript.cs
/// D12 Team

using System.Collections;
using System.Collections.Generic;
using Assets.Classes.Traits;
using UnityEngine;
using UnityEngine.UI;

public class TraitScript : MonoBehaviour
{
    public Trait trait;

    public Text nameBox, descBox, costBox, activeBox;

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
        nameBox.text = trait.Name;
        descBox.text = trait.Desc;
        costBox.text = "EXP COST: " + trait.Cost.ToString();
        if(trait.Active)
        {
            activeBox.text = "ACTIVE";
            activeBox.color = Color.green;
        }
        else
        {
            activeBox.text = "LOCKED";
            activeBox.color = Color.red;
        }
    }
}
