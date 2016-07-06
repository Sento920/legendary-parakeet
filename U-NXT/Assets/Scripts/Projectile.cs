using UnityEngine;
using System.Collections;

/*
===============================================================================

	Projectile Class contains all the information needed to create a projectile.
        Also contains the enumeration used to explain Damage Types.
        The Soundbyte is played on Firing

===============================================================================
*/

public class Projectile : MonoBehaviour {
    [SerializeField]
    private AudioClip FireByte;
    [SerializeField]
    private AudioClip HitByte;
    [SerializeField]
    private AudioClip MidFlightByte;
    [SerializeField]
    public int DamageValue;
    public int DamageType;
    public float travelSpeed;
    public enum DAMAGE_TYPES { DEFAULT, LEMON , PLASMA , EXPLOSIVE };
    private Rigidbody2D rb2d;


    /*
====================
PlayX()

  Essentially getters for the audioClips.   
====================
*/

    public void PlayFire() {
        AudioSource.PlayClipAtPoint(FireByte, transform.position);
    }

    public void PlayMid() {
        AudioSource.PlayClipAtPoint(MidFlightByte,transform.position);
    }

    public void PlayHit() {
        AudioSource.PlayClipAtPoint(HitByte, transform.position);
    }


    public void Start() {
        rb2d = this.GetComponent<Rigidbody2D>();
    }

    public void Update() {
        rb2d.velocity = new Vector2( travelSpeed, 0f );
    }

}
