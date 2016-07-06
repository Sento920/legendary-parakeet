using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*
===============================================================================

	Player UI is the master controller of the UI. 
            It will display the Player's Health, along with the current Ammunition type selected.
            This class will also have the public g/s methods attached to it for the Player Controller to call.

===============================================================================
*/
    
    //Information Acquired from Ammo type
    public Text CurrAmmoType;
    public Image CurrAmmoImage;
    //Information Provided by Player
    //public Image HealthBar;
    //public Image CurrentHealth;
    
    
    /*
    ====================
    setAmmo( GameObject Munition )
        This method is called in the player controller every ammo change.
        It gets the Projectile game object, which the UI then updates.
        NOTE: This method should ONLY be called when the ammo is SWITCHED OUT.
    ====================
    */
    
    public void setAmmo(GameObject Munition){
        Projectile temp = Munition.GetComponent<Projectile>();
        CurrAmmoType.text = temp.Name;
        int id = temp.DamageType;
        //This ID is the universal DAMAGE_TYPE enum type.
    }


