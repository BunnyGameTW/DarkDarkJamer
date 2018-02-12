using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class InfinityScroller : MonoBehaviour {

	public Vector2 direction;
	public float speed;

	private RawImage m_rawImage;

	void Awake () {
		m_rawImage = this.GetComponent<RawImage> ();
	}

	void Update () {
		Rect rect_ = m_rawImage.uvRect;
		rect_.x = (rect_.x + direction.x * speed * Time.deltaTime) % 1f;
		rect_.y = (rect_.y + direction.y * speed * Time.deltaTime) % 1f;
		m_rawImage.uvRect = rect_;
	}
}
