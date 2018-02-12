using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DouduckGame;

public class AppUtil : GameSystemMono {

	public void GameSystemSetup () {
		DouduckGameCore.AddModule<GameObjectControlModule> ();
	}

	public void GameStart () {
		GameObjectControlModule controller_ = DouduckGameCore.GetModule<GameObjectControlModule> ();
		GameObjectSet[] sets_ = GameObject.FindObjectsOfType<GameObjectSet> ();
		for (int i = 0; i < sets_.Length; i++) {
			controller_.AddGameObjectSet (sets_[i]);
			sets_[i].Hide ();
		}

		DouduckGameCore.AddModule<GameFlowModule> ().TransTo (new MainMenuState ());
	}

}
