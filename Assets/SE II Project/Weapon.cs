using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
  public enum weaponTypes {
    AXE,
    BOW,
    STAFF
  }
  public weaponTypes weaponType;

  public enum weaponTiers {
    STEEL,
    ADAMANTINE,
    MASTERWORK
  }
  public weaponTiers weaponTier;

  [System.Serializable]
  public class WeaponStats {
    public int attack = 0;
    public int damage = 0;
    public int range = 0;
    public string weaponName = "Default";
  }
  public WeaponStats weaponStats;

  private void OnValidate() {
    CheckWeaponStats();
  }

  private void CheckWeaponStats() {
    weaponStats.attack = 0;
    weaponStats.damage = 0;
    weaponStats.range = 0;
    weaponStats.weaponName = null;

    switch (weaponTier) {
      case weaponTiers.STEEL:
        Debug.Log("Steel");
        break;
      case weaponTiers.ADAMANTINE:
        Debug.Log("Adamantine");
        break;
      case weaponTiers.MASTERWORK:
        Debug.Log("Masterwork");
        weaponStats.weaponName = "Tier ";
        break;
      default:
        Debug.Log("Tier Default");
        break;
    }
    switch (weaponType) {
      case weaponTypes.AXE:
        Debug.Log("Axe");
        break;
      case weaponTypes.BOW:
        Debug.Log("Bow");
        break;
      case weaponTypes.STAFF:
        Debug.Log("Staff");
        weaponStats.weaponName += "Type.";
        break;
      default:
        Debug.Log("Type Default");
        break;
    }
    Debug.Log(weaponStats.weaponName);
  }
}
