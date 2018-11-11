using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
  public enum WeaponTypes {
    AXE,
    BOW,
    STAFF
  }
  public WeaponTypes weaponType;

  public enum WeaponTiers {
    STEEL,
    ADAMANTINE,
    MASTERWORK
  }
  public WeaponTiers weaponTier;

  [System.Serializable]
  public class WeaponStats {
    public int attack = 0;
    public int damage = 0;
    public int range = 0;
    public string weaponName = "Default";

    public void Reset() {
      attack = 0;
      damage = 0;
      range = 0;
      weaponName = null;
    }
  }
  public WeaponStats weaponStats = new WeaponStats();

  public static void CreateWeapon(WeaponTypes weaponType, WeaponTiers weaponTier, Transform parent = null) {
    GameObject weaponObject = new GameObject("Weapon", typeof(Weapon));
    weaponObject.GetComponent<Weapon>().SetWeaponStats(weaponType, weaponTier);
    weaponObject.transform.parent = parent;
  }

  private void OnValidate() {
    CheckWeaponStats();
  }

  private void Start() {
    OnValidate();
  }

  private void CheckWeaponStats() {
    weaponStats.Reset();

    switch (weaponTier) {
      case WeaponTiers.STEEL:
        Debug.Log("Steel");
        break;
      case WeaponTiers.ADAMANTINE:
        Debug.Log("Adamantine");
        break;
      case WeaponTiers.MASTERWORK:
        Debug.Log("Masterwork");
        weaponStats.weaponName = "Tier ";
        break;
      default:
        Debug.Log("Tier Default");
        break;
    }
    switch (weaponType) {
      case WeaponTypes.AXE:
        Debug.Log("Axe");
        break;
      case WeaponTypes.BOW:
        Debug.Log("Bow");
        break;
      case WeaponTypes.STAFF:
        Debug.Log("Staff");
        weaponStats.weaponName += "Type.";
        break;
      default:
        Debug.Log("Type Default");
        break;
    }
    Debug.Log(weaponStats.weaponName);
  }

  public void SetWeaponStats(WeaponTypes weaponType, WeaponTiers weaponTier) {
    this.weaponType = weaponType;
    this.weaponTier = weaponTier;
  }
}
