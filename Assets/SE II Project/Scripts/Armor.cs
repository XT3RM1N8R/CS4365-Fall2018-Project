using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : MonoBehaviour {
  public enum ArmorTypes {
    ONE,
    TWO,
    THREE
  }
  public ArmorTypes armorType;

  [System.Serializable] // Allows Unity to properly serialize and save this object
  public class ArmorStats {
    public int evade = 0;
    public int hp = 0;
    public string armorName = "";

    public void Reset() {
      evade = 0;
      hp = 0;
      armorName = "";
    }
  }
  public ArmorStats armorStats = new ArmorStats();

  public static void CreateArmor(ArmorTypes armorType, Transform parent = null) {
    GameObject armorObject = new GameObject("Armor", typeof(Armor));
    armorObject.GetComponent<Armor>().SetArmorStats(armorType);
    armorObject.transform.parent = parent;
  }

  private void OnValidate() {
    CheckArmorStats();
  }

  private void Start() {
    OnValidate();
  }

  public void CheckArmorStats() {
    armorStats.Reset();

    switch (armorType) {
      case ArmorTypes.ONE:
        armorStats.evade += 1;
        armorStats.hp += 1;
        armorStats.armorName += "One";
        break;
      case ArmorTypes.TWO:
        armorStats.evade += 2;
        armorStats.hp += 2;
        armorStats.armorName += "Two";
        break;
      case ArmorTypes.THREE:
        armorStats.evade += 3;
        armorStats.hp += 3;
        armorStats.armorName += "Three";
        break;
      default:
        Debug.Log("Tier Default");
        break;
    }
    armorStats.armorName += " Armor";
    gameObject.name = armorStats.armorName;
  }

  public void SetArmorStats(ArmorTypes armorType) {
    this.armorType = armorType;
    CheckArmorStats();
  }
}
