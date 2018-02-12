using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DouduckGame;

public class ResultSet : GameObjectSet {

    [SerializeField]
	private Text scoreText;
    [SerializeField]
    private Text descriptionText;

    [ReadOnly]
	public InputEventReciever Events;

	void Awake () {
		Events = this.gameObject.AddComponent<InputEventReciever> ();
	}

	public void SetScore (float score) {
		scoreText.text = string.Format("{0:0.#}%", score);
        if (score > 90f) {
            descriptionText.text = "煉金達人!!";
        } else if (score > 80f) {
            descriptionText.text = "好棒棒的拉";
        } else if (score > 70f) {
            descriptionText.text = "勉勉強強";
        } else if (score > 60f) {
            descriptionText.text = "加油好嗎?";
        } else if (score > 50f) {
            descriptionText.text = "動點腦筋比較好喔";
        } else if (score > 40f) {
            descriptionText.text = "我阿罵都比你行";
        } else if (score > 30f) {
            descriptionText.text = "別亂丟好嗎?";
        } else if (score > 20f) {
            descriptionText.text = "....恩";
        } else {
            descriptionText.text = "色盲阿你?";
        }
    }
}
