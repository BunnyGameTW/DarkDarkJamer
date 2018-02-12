using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData {
    public KeyCode[,] player;
    public Color[] iconColor;
	// Use this for initialization
	public PlayerData() {
        player = new KeyCode[4,5];
        iconColor = new Color[4];

        iconColor[0] = Color.blue;
        iconColor[1] = Color.red;
        iconColor[2] = Color.green;
        iconColor[3] = Color.yellow;

        player[0, 0] = KeyCode.UpArrow;
        player[0, 1] = KeyCode.DownArrow;
        player[0, 2] = KeyCode.LeftArrow;
        player[0, 3] = KeyCode.RightArrow;
        player[0, 4] = KeyCode.RightControl;
        
        player[1, 0] = KeyCode.I;
        player[1, 1] = KeyCode.K;
        player[1, 2] = KeyCode.J;
        player[1, 3] = KeyCode.L;
        player[1, 4] = KeyCode.B;

        player[2, 0] = KeyCode.T;
        player[2, 1] = KeyCode.G;
        player[2, 2] = KeyCode.F;
        player[2, 3] = KeyCode.H;
        player[2, 4] = KeyCode.N;

        player[3, 0] = KeyCode.W;
        player[3, 1] = KeyCode.S;
        player[3, 2] = KeyCode.A;
        player[3, 3] = KeyCode.D;
        player[3, 4] = KeyCode.C;
    }
	
}
