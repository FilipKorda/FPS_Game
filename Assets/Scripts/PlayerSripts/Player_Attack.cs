using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour 
{

    private Weapon_Manager weapon_Manager;

    public float fireRate = 15f;
    private float nextTimeToFire;
    public float damage = 20f;

    private Animator zoomCameraAnim;
    private bool zoomed;

    private Camera mainCam;

    private GameObject crosshair;

    public float range = 30f;


    private bool is_Aiming;

    public GameObject Gun;

    public GameObject impact_effect;

    void Awake() 
    {
        weapon_Manager = GetComponent<Weapon_Manager>();
        mainCam = Camera.main;
    }

    // Use this for initialization
    void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        WeaponShoot();  
    }

    void WeaponShoot() {

        // if we have assault riffle
        if(weapon_Manager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE) {

            // if we press and hold left mouse click AND
            // if Time is greater than the nextTimeToFire
            if(Input.GetMouseButton(0) && Time.time > nextTimeToFire) {

                nextTimeToFire = Time.time + 1f / fireRate;

                weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                 BulletShoot();

            }


            // if we have a regular weapon that shoots once
        } else 
        {

            if(Input.GetMouseButtonDown(0)) 
            {

                // handle axe
                if(weapon_Manager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG) 
                {
                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();
                }

                // handle shoot
                if(weapon_Manager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET) 
                {

                    weapon_Manager.GetCurrentSelectedWeapon().ShootAnimation();

                    BulletShoot();

                }// else


            } // if input get mouse button 0

        } // else

    } // weapon shoot

    // if we need to zoom the weapon


    void BulletShoot() 
    {
        RaycastHit hit;

        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range)) 
        {
            Debug.Log(hit.transform.name);
            Enemy_Health enemyhealth = hit.transform.GetComponent<Enemy_Health>();

            if (enemyhealth != null) 
            {
                enemyhealth.ApplyDamage(damage);
            }

            GameObject impactGO = Instantiate(impact_effect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);

        }

    }

}

//if (hit.transform.tag == Tags.ENEMY_TAG) 