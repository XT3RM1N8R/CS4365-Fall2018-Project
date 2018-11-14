using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

  public enum FactionTypes {
    AXIS,
    ALLIES,
    REPUBLIC
  }
  public FactionTypes factionType;

  public enum JobTypes {
    RANGER,
    MAGE,
    MELEE
  }
  public JobTypes jobType;

  [System.Serializable]
  public class UnitStats {
    public int attack;
    public int damage;
    public int evade;
    public int hp;
    public int movementPoints;
    public string unitName;

    public void Reset() {
      attack = 0;
      damage = 0;
      evade = 0;
      hp = 0;
      movementPoints = 10;
      unitName = null;
    }
  }
  public UnitStats unitStats = new UnitStats();

  public Weapon weapon;
  public Armor armor;
  public Potion potion;

  public static void CreateUnit(FactionTypes factionType, JobTypes jobType, Transform parent = null) {
    GameObject unitObject = new GameObject("Unit", typeof(Unit));
    unitObject.GetComponent<Unit>().SetUnitStats(factionType, jobType);
    unitObject.transform.parent = parent;
  }

  private void OnValidate() { // Editor-only; Called on Inspector change and script start
    CheckUnitStats(); // Update unit stats with latest values
  }

  private void Start() {  // Called at script start by Unity
    OnValidate(); 	// Forces proper initialization in builds
  }

  public void CheckUnitStats() { // Hardcoding constants for now; this could be optimized later by use of arrays and enum indexes
    unitStats.Reset();

    if (factionType == FactionTypes.AXIS) {
      unitStats.unitName += "Axis ";

      if (jobType == JobTypes.RANGER) {
        unitStats.hp += 3;
      } else if (jobType == JobTypes.MAGE) {
        unitStats.damage += 2;
      } else if (jobType == JobTypes.MELEE) {
        unitStats.attack += -2;
      }
    } else if (factionType == FactionTypes.ALLIES) {
      unitStats.unitName += "Allied ";

      if (jobType == JobTypes.RANGER) {
        unitStats.attack += 4;
      } else if (jobType == JobTypes.MAGE) {
        unitStats.hp += -1;
      } else if (jobType == JobTypes.MELEE) {
        unitStats.damage += -1;
      }
    }

    if (jobType == JobTypes.RANGER) {
      unitStats.unitName += "Ranger";
      unitStats.attack += 5;
      unitStats.evade += 16;
      unitStats.hp += 14;
      unitStats.damage += 0;
    } else if (jobType == JobTypes.MAGE) {
      unitStats.unitName += "Mage";
      unitStats.attack += 3;
      unitStats.evade += 11;
      unitStats.hp += 9;
      unitStats.damage += 3;
    } else if (jobType == JobTypes.MELEE) {
      unitStats.unitName += "Melee";
      unitStats.attack += 1;
      unitStats.evade += 13;
      unitStats.hp += 20;
      unitStats.damage += 4;
    }

    if (weapon) {
      unitStats.attack += (int) weapon.weaponType;
      Debug.Log("Weapon: " + weapon.weaponType.ToString());
    }

    if (potion) {
      unitStats.hp += 1;
      Debug.Log("Potion");
    }

    if (armor) {
      unitStats.evade += 1;
      Debug.Log("Armor");
    }
  }

  public void SetUnitStats(FactionTypes factionType, JobTypes jobType) {
    this.factionType = factionType;
    this.jobType = jobType;
    CheckUnitStats();
  }
  /*
  void OnMouseOver(???) {
    // handles visual feedback for Mouse Hover events
  }

  void OnClick(???) {
    // handles visual feedback for Mouse Click events
  }
  */
}
