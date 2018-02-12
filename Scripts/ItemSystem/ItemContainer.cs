using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ItemContainer : MonoBehaviour {

	private Image m_container;

	[SerializeField]
	private Vector2 m_hidingPosition = new Vector2(0, -1000);
	[SerializeField][ReadOnly]
	private int m_usingItemIndex;
	public int Index {
		get {
			return m_usingItemIndex;
		}
	}

	public bool isActive {
		get {
			return m_usingItemIndex != -1;
		}
	}

	void Awake () {
		m_container = GetComponent<Image> ();

	}

	public void NewItem (int index, Sprite sprite, Vector2 startPos) {
        m_usingItemIndex = index;
		m_container.sprite = sprite;
		m_container.transform.localPosition = startPos;
	}

	public void RemoveItem () {
		this.transform.localPosition = m_hidingPosition;
        m_usingItemIndex = -1;
	}

	public void Moving (Vector2 speed) {
		this.transform.Translate (speed * Time.deltaTime, Space.Self);
	}

	public void MoveTo (Vector2 position) {
		this.transform.localPosition = position;
	}

	public bool IsInRange (Vector3 center, float range) {
		center -= this.transform.localPosition;
		return center.sqrMagnitude < range * range;
	}

	public bool IsOver (float level) {
		return this.transform.localPosition.y > level;
	}
}
