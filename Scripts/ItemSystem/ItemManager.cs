using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DouduckGame;

public class ItemManager : GameSystemMono, IInitializable {

	[SerializeField]
	private float m_holdRange = 2500f;
	[SerializeField]
	private float m_kettleRange = 28900f;
	[SerializeField]
	private Vector2 m_hidingPosition = new Vector2(0, -1000);

	[SerializeField]
	private Transform m_beltTrans;
	[SerializeField]
	private Vector2 m_beltSpeed = new Vector2(10f, 0f);
	private Vector2 m_beltStartPosition = new Vector2(-100 - Screen.width / 2f, Screen.height / 2f - 50f);
	private float BELT_BOTTOM = Screen.height / 2f - 100f;

	private int ITEM_TYPE_COUNT;
	private readonly int COUNTAINER_COUNT = 20;

	[SerializeField]
	private Transform m_itemArchor;
	[SerializeField]
	private GameObject m_itemPrefab;
	private List<ItemContainer> m_itemContainerList = new List<ItemContainer>();
	private Dictionary<int, ItemContainer> m_holdingItemList = new Dictionary<int, ItemContainer>();

	[SerializeField]
	private PotController m_PotController;
    private Vector2 m_potPosition;
    [SerializeField]
	private PotController m_TargetPotController;

	//[SerializeField]
	//private List<ItemProperty> m_itemPropertyList = new List<ItemProperty>();
	[SerializeField]
	private ItemPropertySetting m_itemProperties;

    private AudioInterface m_AudioInterface;
    public Text itemNameText;

    public void Initialize () {
		ITEM_TYPE_COUNT = m_itemProperties.itemTypeAmount;
        m_potPosition = m_PotController.transform.localPosition;


        for (int i = 0; i < COUNTAINER_COUNT; i++) {
			ItemContainer item_ = Instantiate (m_itemPrefab, m_itemArchor).GetComponent<ItemContainer> ();
			m_itemContainerList.Add (item_);
		}
	}

	public void Uninitialize () {

	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			PickItem (1, Input.mousePosition - new Vector3(480, 270));
		}

		if (Input.GetMouseButton (0)) {
			UpdateItemPosition (1, Input.mousePosition - new Vector3(480, 270));
		}

		if (Input.GetMouseButtonUp (0)) {
			ReleaseItem (1);
		}

		MoveItemOnBelt ();
	}

	public void Reset () {
		m_PotController.ClearEffect ();
		m_PotController.SetColor (Color.white);

		m_TargetPotController.RandomSetting ();

        for (int i = 0; i < COUNTAINER_COUNT; i++) {
			m_itemContainerList[i].RemoveItem ();
		}

        m_AudioInterface = DouduckGameCore.GetSystem<AudioInterface> ();
        itemNameText.text = "";
    }

    public float GetScore () {
		return m_PotController.Compare (m_TargetPotController);
	}

	[InvokeButton]
	public void GenerateNewItem () {
		ItemContainer empty_ = GetEmptyContainer ();
		if (empty_ != null) {
            int idx = Random.Range (0, ITEM_TYPE_COUNT);
			empty_.NewItem (idx, m_itemProperties[idx].sprite, m_beltStartPosition);
		}
	}

	private void MoveItemOnBelt () {
		for (int i = 0; i < COUNTAINER_COUNT; i++) {
			if (m_itemContainerList[i].isActive && m_itemContainerList[i].IsOver(BELT_BOTTOM)) {
                m_itemContainerList[i].Moving (m_beltSpeed * Time.deltaTime);
				if (m_itemContainerList [i].transform.localPosition.x > -m_beltStartPosition.x) {
					m_itemContainerList [i].RemoveItem ();
				}
			}
		}
	}

	public void PickItem (int player, Vector2 pos) {
		for (int i = m_itemContainerList.Count - 1; i >= 0; i--) {
			if (m_itemContainerList[i].isActive && TryToHold (pos, m_itemContainerList [i].transform)) {
				m_holdingItemList.Add (player, m_itemContainerList [i]);
				return;
			}
		}
	}

	public void ReleaseItem (int player) {
		if (m_holdingItemList.ContainsKey (player)) {
			if (TryToDropIn (m_holdingItemList [player].transform.localPosition)) {
				int index = m_holdingItemList [player].Index;
				m_PotController.Addcolor (m_itemProperties[index].color);
				m_holdingItemList [player].RemoveItem ();
                m_AudioInterface.PlaySound ((EffectAudio)Random.Range (0, 4));
                itemNameText.text = m_itemProperties[index].name;
            }
			m_holdingItemList.Remove (player);
		}
	}

	public void UpdateItemPosition (int player, Vector2 pos) {
		if (m_holdingItemList.ContainsKey (player)) {
			m_holdingItemList [player].transform.localPosition = pos;
		}
	}

	private bool TryToHold (Vector2 pos, Transform item) {
		Vector2 diff_ = item.localPosition;
		diff_ -= pos;
		return diff_.sqrMagnitude < m_holdRange;
	}

	private bool TryToDropIn (Vector2 pos) {
		Vector2 diff_ = m_potPosition - pos;
		return diff_.sqrMagnitude < m_kettleRange;
	}

	private ItemContainer GetEmptyContainer () {
		for (int i = 0; i < COUNTAINER_COUNT; i++) {
			if (!m_itemContainerList [i].isActive) {
				return m_itemContainerList [i];
			}
		}
		return null;
	}

}
