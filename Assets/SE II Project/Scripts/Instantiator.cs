using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour { // Delete this class after testing is over
  
	void Start () {
    Unit.CreateUnit(Unit.FactionTypes.ALLIES, Unit.JobTypes.MAGE);
    Weapon.CreateWeapon(Weapon.WeaponTypes.BOW, Weapon.WeaponTiers.ADAMANTINE, transform);
  }
}
