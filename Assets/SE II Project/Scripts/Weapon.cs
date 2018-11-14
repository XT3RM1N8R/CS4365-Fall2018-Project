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

  [System.Serializable] // Allows Unity to properly serialize and save this object
  public class WeaponStats {
    [System.Serializable]
    public class DamageDie {
      public int count = 0;
      public int sides = 0;

      public DamageDie(int count, int sides) {
        this.count = count;
        this.sides = sides;
      }

      public void Set(int count, int sides) {
        this.count = count;
        this.sides = sides;
      }

      public void Reset() {
        count = 0;
        sides = 0;
      }
    }
    public DamageDie damageDie = new DamageDie(0, 0);

    public int attack = 0;
    public int damage = 0;
    public int range = 0;
    public string weaponName = "";

    public void Reset() {
      damageDie.Reset();
      attack = 0;
      damage = 0;
      range = 0;
      weaponName = "";
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
        weaponStats.attack += 1;
        weaponStats.weaponName += "Steel ";
        break;
      case WeaponTiers.ADAMANTINE:
        weaponStats.attack += 3;
        weaponStats.weaponName += "Adamantine ";
        break;
      case WeaponTiers.MASTERWORK:
        weaponStats.attack += 5;
        weaponStats.weaponName += "Masterwork ";
        break;
      default:
        Debug.Log("Tier Default");
        break;
    }
    switch (weaponType) {
      case WeaponTypes.AXE:
        weaponStats.damageDie.Set(1, 8);
        weaponStats.weaponName += "Axe";
        break;
      case WeaponTypes.BOW:
        weaponStats.damageDie.Set(1, 6);
        weaponStats.weaponName += "Bow";
        break;
      case WeaponTypes.STAFF:
        weaponStats.damageDie.Set(1, 6);
        weaponStats.weaponName += "Staff";
        break;
      default:
        Debug.Log("Type Default");
        break;
    }
    gameObject.name = weaponStats.weaponName;
  }

  public void SetWeaponStats(WeaponTypes weaponType, WeaponTiers weaponTier) {
    this.weaponType = weaponType;
    this.weaponTier = weaponTier;
  }
}
