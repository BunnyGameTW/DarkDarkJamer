using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PotController : MonoBehaviour {

	private readonly float COLOR_RATIO = 0.1f;

	private Image potImg;
	public Color color {
		get {
			return potImg.color;
		}
	}

	public Image[] _childImg = new Image[3];
	public int _childNum;
	public int _effectNum;

	public Color testColor,testAddcolor,testEffectColor;
	public string testImageStr;
	// Use this for initialization
	void Awake () {
		potImg = GetComponent<Image> ();//get pot image
		for(int i=0;i<3;i++){//get childs
			_childImg [i] = transform.GetChild (i).GetComponent<Image> ();
		}
		_childNum = 0;//set child num
	}
	//設定顏色
	public void SetColor(Color color){
		potImg.color = color;

	}
	//加入顏色
	public void Addcolor(Color color){
		potImg.color= Color.Lerp (potImg.color, color, COLOR_RATIO);
	}
	//設定子圖片 顏色
	public void SetEffect(int i,string imageName,Color color){
		_childImg [i].sprite = Resources.Load <Sprite>(imageName);
		_childImg [i].color = color;
	}
	//加入新子圖片
	public void AddEffect(string imageName,Color color){
		
		SetEffect (_childNum, imageName, color);
		_childNum++;
		_childNum = _childNum % 3;
		//_childNum= _childNum++ % 3;
		Debug.Log (_childNum);
	}
	//清除子圖片
	public void ClearEffect(){
		for (int i = 0; i < 3; i++) {
			_childImg [i].sprite = null;
			Color clearColor=new Color(0,0,0,0);
			_childImg [i].color=clearColor;
			_childNum = 0;
		}
	}

	public void RandomSetting () {
		//TODO: bug?
		SetColor (new Color (Random.Range (0.1f, 1.0f), Random.Range (0.1f, 1.0f), Random.Range (0.1f, 1.0f)));
		// RandomEffect();
	}

	void RandomEffect(){
		int ran = Random.Range (0, 100);
		if (ran <= 40) {//1種效果 40%
			_effectNum = 0;
		} 
		else if (ran <= 90) {//2種效果 50%
			_effectNum = 1;
		}
		else if (ran <= 100) {//3種效果 10%
			_effectNum = 2;
		}
		SetStatus (_effectNum + 1);
	}

	void SetStatus(int num){
		for (int i = 0; i < num; i++) {
			int ranStatus = Random.Range (0, 7);
			SetImage (ranStatus);
		}

	}

	void SetImage(int i){ //imageNum ,status
		string imageName="";
		switch (i){//TODO: 要換黨名
		case 0:
			imageName="idle";
			break;
		case 1:
			imageName="areaIcon";
			break;
		case 2:
			imageName="idle";
			break;
		case 3:
			imageName="areaIcon";
			break;
		case 4:
			imageName="idle";
			break;
		case 5:
			imageName="areaIcon";
			break;
		case 6:
			imageName="idle";
			break;
		case 7:
			imageName="areaIcon";
			break;
		}
		_childImg [_effectNum].sprite = Resources.Load <Sprite>(imageName);
	}

	public float Compare(PotController target){
		float score=0.0f;
		//鍋子液體 70%
		//狀態 1 2 3 各10%
		//比較顏色 R G B
		Vector3 potColorV = new Vector3(potImg.color.r, potImg.color.g, potImg.color.b);
		Vector3 topicPotColorV = new Vector3(target.color.r, target.color.g, target.color.b);

		float dis = Mathf.Clamp(Vector3.Distance(potColorV,topicPotColorV),0,1);
		float potScore = 1 - dis;
		float statusScore = 0.0f;
		for(int i = 0;i < _effectNum; i++){
			// TODO: a bug
			if (target._childImg [i].sprite != null && target._childImg [i].sprite.name == _childImg [i].sprite.name) {
				statusScore+=1.0f;
			}
		}
		if(statusScore != 0) statusScore = statusScore / (float)_effectNum;
		score=potScore*0.7f+ statusScore*0.3f;

		return score;
	}
}
