using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {
  public enum PotionTypes {
    ONE,
    TWO,
    THREE
  }
  public PotionTypes potionType;

  [System.Serializable] // Allows Unity to properly serialize and save this object
  public class PotionStats {
    public int hp = 0;
    public string potionName = "";

    public void Reset() {
      hp = 0;
      potionName = "";
    }
  }
  public PotionStats potionStats = new PotionStats();

  public static void CreatePotion(PotionTypes potionType, Transform parent = null) {
    GameObject potionObject = new GameObject("Potion", typeof(Potion));
    potionObject.GetComponent<Potion>().SetPotionStats(potionType);
    potionObject.transform.parent = parent;
  }

  private void OnValidate() {
    CheckPotionStats();
  }

  private void Start() {
    OnValidate();
  }

  public void CheckPotionStats() {
    potionStats.Reset();

    switch (potionType) {
      case PotionTypes.ONE:
        potionStats.hp += 1;
        potionStats.potionName += "One";
        break;
      case PotionTypes.TWO:
        potionStats.hp += 2;
        potionStats.potionName += "Two";
        break;
      case PotionTypes.THREE:
        potionStats.hp += 3;
        potionStats.potionName += "Three";
        break;
      default:
        Debug.Log("Tier Default");
        break;
    }
    potionStats.potionName += " Potion";
    gameObject.name = potionStats.potionName;
  }

  public void SetPotionStats(PotionTypes potionType) {
    this.potionType = potionType;
    CheckPotionStats();
  }
}
