using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerAction : MonoBehaviour {
    public Sprite onPressed;
    public Sprite onReleased;
    public KeyCode hold, up, down, left, right;
    public float speed;
    
    public Image normal;
    Sprite icon;
	// Use this for initialization
	void Start () {
        normal = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        ChangeIcon();
        Move();
    }

    void ChangeIcon()
    {
        if (Input.GetKey(hold))
        {
            GetComponent<Image>().sprite = onPressed;
        }
        else GetComponent<Image>().sprite = onReleased;
    }

    void Move()
    {
        if (Input.GetKey(up))
        {
            this.transform.position += new Vector3(0, speed, 0);
        }
        if (Input.GetKey(down))
        {
            this.transform.position -= new Vector3(0, speed, 0);
        }
        if (Input.GetKey(left))
        {
            this.transform.position -= new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(right))
        {
            this.transform.position += new Vector3(speed, 0, 0);
        }
    }
    
}
