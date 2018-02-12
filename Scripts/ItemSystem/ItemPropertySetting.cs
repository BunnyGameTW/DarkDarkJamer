using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemPropertySetting", menuName = "Custom/ItemPropertySetting", order = 1)]
public class ItemPropertySetting : ScriptableObject {

	[System.Serializable]
	public struct ItemProperty {
		public string name;
		public Sprite sprite;
		public Color color;
		public PotEffect effect;
	}

	[SerializeField]
	private List<ItemProperty> m_itemPropertyList = new List<ItemProperty>();

    public int itemTypeAmount {
        get {
            return m_itemPropertyList.Count;
        }
    }

    public ItemProperty this[int key] {
        get {
            return m_itemPropertyList[key];
        }
    }
}