/// CharacterDataViewer.cs
/// D12 Team
/// Script to test BaseCharacter class

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterDataViewer : MonoBehaviour {

    private BaseCharacter character;
    public InputField NameField;
    public GameObject NameDisplay;
    public GameObject WeightDisplay;
    public GameObject VolumeDisplay;

	// Use this for initialization
	void Start () {
        character = new BaseCharacter();
	}
	
	// Update is called once per frame
	void Update () {
        character.Info.Name = NameField.text;
        NameDisplay.GetComponent<Text>().text = "Name: " + character.Info.Name;
        WeightDisplay.GetComponent<Text>().text = "Weight: " + character.Inventory.CurrentWeight.ToString() + " kg";
        VolumeDisplay.GetComponent<Text>().text = "Volume: " + character.Inventory.CurrentVolume + " / " + character.Inventory.MaxVolume;
	}

    public void AddItem()
    {
        character.Inventory.Add(new BaseItem("name", 0.37, 10, System.Guid.NewGuid()));
    }

    public void RemoveItem()
    {
        var list = character.Inventory.Items;
        if (list.Count > 0)
            character.Inventory.Remove(list[0].UniqueId);
    }
}
