/// TraitTreeDriver.cs
/// D12 Team

using System.Collections;
using System.Collections.Generic;
using Assets.Classes.Character;
using UnityEngine;

public class TraitTreeDriver : MonoBehaviour {

    // Character in context of the scene. The scene should reflect the character's internal TraitSystem.
    public BaseCharacter character;

    public GameObject ling1, ling2, ling3, ling4, ling5, multilinguist, transcriber, archlinguist, globalLinguist;

	// Use this for initialization
	void Start () {
        character = new BaseCharacter();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
