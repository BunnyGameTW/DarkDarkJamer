using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DouduckGame;

public class ButtonEventSender : InputEventSender {

    public Text m_text;
    public float m_ColdDownTime = 0.5f;

    private float m_fColdDownTimer;

    void Awake () {
        if (m_text == null) {
            m_text = GetComponentInChildren<Text> (true);
        }

        Image img = transform.GetComponent<Image> ();
        if (img != null) {
            img.raycastTarget = true;
        } else if (m_text != null) {
            m_text.raycastTarget = true;
        }

        EventTriggerListener.Get (this.gameObject).onClick = OnButtonClick;
    }

    void Update () {
        if (m_fColdDownTimer > 0) {
            m_fColdDownTimer -= Time.deltaTime;
        }
    }

    public void SetText (string btnText) {
        if (m_text != null) {
            m_text.text = btnText;
        }
    }

    public void Touch () {
        OnButtonClick (this.gameObject);
    }

    private void OnButtonClick (GameObject go) {
        if (m_fColdDownTimer <= 0.0f) {
            if (m_text != null) {
                this.EventReciever.ButtonClick (m_text.text);
            } else {
                this.EventReciever.ButtonClick (this.name);
            }
            m_fColdDownTimer = m_ColdDownTime;
        }
    }
}
