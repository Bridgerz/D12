/// TraitScript.cs
/// D12 Team

using System.Collections;
using System.Collections.Generic;
using Assets.Classes.Traits;
using UnityEngine;

public class TraitScript : MonoBehaviour
{

    public GameObject character;

    public Trait trait;

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
        Debug.Log(trait.Name);
    }
}
