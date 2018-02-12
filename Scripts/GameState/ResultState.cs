using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DouduckGame;

public class ResultState : State {

	private ResultSet m_resultUI;

	private float m_score;

	public ResultState(float score) {
		m_score = score;
	}

	public override void StateBegin () {
		m_resultUI = DouduckGameCore.GetModule<GameObjectControlModule> ().GetGameObjectSet<ResultSet> ("Result");
		m_resultUI.Show ();
		m_resultUI.SetScore (m_score);

		m_resultUI.Events.OnButtonClick += OnButtonClick;
	}

	public override void StateEnd () {
		m_resultUI.Hide ();
	
		m_resultUI.Events.OnButtonClick -= OnButtonClick;
	}


	private void OnButtonClick(GameObject go, string name) {
		if (name == "BackMenu") {
			DouduckGameCore.GetModule<GameFlowModule> ().TransTo (new MainMenuState ());
		}
	}
}
