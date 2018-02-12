using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DouduckGame;

public class InGameState : State {

	private InGameSet m_inGameUI;
	private ItemManager m_ItemManager;

	private readonly float GAME_TIME = 60f;
	private readonly float ITEM_PERIOD = 0.3f;
	private readonly float SCORE_FAC = 130f; // TODO: add effect score

    private float m_LastTime;
    private float m_itemTimer;

	public override void StateBegin () {
        DouduckGameCore.GetSystem<AudioInterface> ().PlayBGM (BGMAudio.InGame);
        m_inGameUI = DouduckGameCore.GetModule<GameObjectControlModule> ().GetGameObjectSet<InGameSet> ("InGame");
		m_inGameUI.Show ();

		m_ItemManager = DouduckGameCore.GetSystem<ItemManager> ();
		m_ItemManager.Reset ();

		m_LastTime = GAME_TIME;
        m_itemTimer = 0f;
		m_inGameUI.timerText.text = string.Format("{0:###.}", m_LastTime);
    }

    public override void StateEnd () {
        DouduckGameCore.GetSystem<AudioInterface> ().PlayBGM (BGMAudio.Menu);
		m_inGameUI.Hide ();
    }

	public override void StateUpdate () {
		m_itemTimer -= Time.deltaTime;
		m_LastTime -= Time.deltaTime;
		m_inGameUI.timerText.text = string.Format("{0:###.}", m_LastTime);

		if (m_LastTime < 0) {
			this.TransTo (new ResultState (m_ItemManager.GetScore () * SCORE_FAC));
		}

		if (m_itemTimer < 0) {
			m_itemTimer = ITEM_PERIOD;
			m_ItemManager.GenerateNewItem ();
		}
	}
}
