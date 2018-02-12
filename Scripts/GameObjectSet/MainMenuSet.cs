using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DouduckGame;

public class MainMenuSet : GameObjectSet {

    [SerializeField]
    private GameObject m_tutorialObject;

	[ReadOnly]
	public InputEventReciever Events;

	void Awake () {
		Events = this.gameObject.AddComponent<InputEventReciever> ();
	}

    void OnEnable () {
        SetTutorialActive (false);
    }

    public void SetTutorialActive (bool value = true) {
        m_tutorialObject.SetActive (value);
    }
}
