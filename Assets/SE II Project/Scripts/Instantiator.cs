using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour { // Delete this class after testing is over
  
	void Start () {
    Weapon.CreateWeapon(Weapon.WeaponTypes.BOW, Weapon.WeaponTiers.ADAMANTINE, transform);
  }
}
