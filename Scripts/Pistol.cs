using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    RaycastHit hit;
    public Text ammoCounter;
    public Image hitmarker;
    Animator anim;
    public GameObject projectilePrefab;

    //Damages Enemy
    [SerializeField]
    float damageEnemy = 30f;

    [SerializeField]
    Transform ShootPoint;

    [SerializeField]
    int maxAmmo;

    [SerializeField]
    int currentAmmo;

    [SerializeField]
    bool isHitscan;

    private bool isReloading = false;


    //WEAPON EFFECTS
    //MuzzleFlash
    [SerializeField]
    private ParticleSystem muzzleflash;


    //AUDIO EFFECTS
    AudioSource gunAS;
    public AudioClip drawWeapon;
    public AudioClip shootAC;
    public AudioClip reloadRifleOutOfAmmo;

    //Rate of Fire
    [SerializeField]
    private float rateOfFire;
    float nextFire = 0;

    [SerializeField]
    float reloadTime = 3.3f;

    [SerializeField]
    float weaponRange;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        //Stops gun from flashing on startup
        muzzleflash.Stop();
        //Makes hitmarker disappear
        hitmarker.enabled = false;
        gunAS = GetComponent<AudioSource>();
        gunAS.PlayOneShot(drawWeapon);
        //maxAmmo = 60;
        updateAmmo();
    }

    void OnEnable()
    {
        isReloading = false;
        updateAmmo();
    }

    void Update()
    {
        if (isReloading)
        {
            return;
        }

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if(Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
        {
            StartCoroutine(Reload());
        }

            if (Input.GetButton("Fire1") && currentAmmo > 0)
            {
                if (isHitscan)
                {
                    Shoot();
                }
                else
                {
                    ShootProjectile();
                }
            }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        anim.Play("Reload Out Of Ammo", 0, 0f);
        gunAS.PlayOneShot(reloadRifleOutOfAmmo);
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
        updateAmmo();
    }

    void Shoot()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;

            currentAmmo--;

            gunAS.PlayOneShot(shootAC);
            anim.Play("Fire", 0, 0f);
            StartCoroutine(weaponEffects());
            updateAmmo();

            if (Physics.Raycast(ShootPoint.position, ShootPoint.forward, out hit, weaponRange))
            {
                if(hit.transform.tag == "Enemy")
                {
                    Debug.Log("Hit Enemy");
                    EnemyHealth enemyHealthScript = hit.transform.GetComponent<EnemyHealth>();
                    enemyHealthScript.deductHealth(damageEnemy);
                    
                }
                else
                {
                    Debug.Log("Hit Other");
                }
            }
        }
    }

    void ShootProjectile()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + rateOfFire;
            currentAmmo--;
            Instantiate(projectilePrefab, ShootPoint.position, ShootPoint.rotation);
            gunAS.PlayOneShot(shootAC);
            anim.Play("Fire", 0, 0f);
            StartCoroutine(weaponEffects());
            updateAmmo();
        }
    }

    //Coroutine
    IEnumerator weaponEffects()
    {
        muzzleflash.Play();
        yield return new WaitForEndOfFrame();
        muzzleflash.Stop();
        hitmarker.enabled = false;
    }

     void updateAmmo()
    {
        ammoCounter.text = currentAmmo.ToString()  + " | " + maxAmmo.ToString();
    }
}
