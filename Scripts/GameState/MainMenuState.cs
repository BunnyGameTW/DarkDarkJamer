using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DouduckGame;

public class MainMenuState : State {

	private MainMenuSet m_menu;

	public override void StateBegin () {
		m_menu = DouduckGameCore.GetModule<GameObjectControlModule> ().GetGameObjectSet<MainMenuSet> ("MainMenu");
		m_menu.Show ();

		m_menu.Events.OnButtonClick += OnButtonClick;
	}

	public override void StateEnd () {
		m_menu.Hide ();

		m_menu.Events.OnButtonClick -= OnButtonClick;
	}

	private void OnButtonClick(GameObject go, string name) {
		if (name == "Start") {
            m_menu.SetTutorialActive ();
        } else {
            DouduckGameCore.GetModule<GameFlowModule> ().TransTo (new InGameState ());
        }
	}
}
