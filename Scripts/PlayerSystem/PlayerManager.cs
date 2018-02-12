using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DouduckGame;

public class PlayerManager : GameSystemMono, IInitializable {
    public GameObject playerfabs;
    public GameObject newplayer;
    public int playerNum;
    public int playerNumMax;
    PlayerData data;
    List<PlayerAction> playerList;

	public void Initialize () {
		playerNum = 0; 
		playerNumMax = 4;
		data = new PlayerData();
		playerList = new List<PlayerAction>();
	}

	public void Uninitialize () {

	}

	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftShift)&& playerNum <playerNumMax )
        {
            Addplayer();
        }
        if (Input.GetKeyDown(KeyCode.P) && playerNum>0)
        {
            Delplayer();
        }
    }

    public void Addplayer() {
        newplayer=Instantiate(playerfabs,this.transform);
        PlayerAction action = newplayer.GetComponent<PlayerAction>();
        playerList.Add(action);
        
    
        action.up = data.player[playerNum, 0];
        action.down = data.player[playerNum, 1];
        action.left = data.player[playerNum, 2];
        action.right = data.player[playerNum, 3];
        action.hold = data.player[playerNum, 4];
        action.normal.color = data.iconColor[playerNum];

        playerNum++;
    }

    public void Delplayer() {
        Transform latest = transform.GetChild(playerNum-1);
        Destroy(latest.gameObject);
        playerNum--;
    }
}
