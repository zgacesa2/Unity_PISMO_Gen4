using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("Ammo:")]
    public int maxAmmo; //iznos koliko imamo na početku municije
    int currentAmmo; //Koliko u ovom trenutku imamo municije
    public Text ammoText; //prikaz koliko imamo metaka

    [Header("About weapon:")]
    public float fireRate; //Koliki je vremenski razmak između metaka
    float fireRateRestart; //Resetira pocetno vrijeme za fireRate
    public float accuracy; //Preciznost oružja u pikselima
    public float reloadTime; //Brzina mjenjanaj municije
    float reloadTimeRestart; //Restart vremena mjenjanja municije
    public float recoil; // Trzaj - Ne koristimo
    public Camera scopeCamera;
    public Camera mainCamera;

    [Header("Fire mode: *Single Fire mode is default*")]
    public bool singleFire; //Pucamo jedan metak po kliku - num 0
    public bool automaticFire; //Pucamo metke dok god držimo klik miša - num 1
    public bool burstFire; //Pucamo po 3 metka po kliku miša - num 2
    int fireMode = 0; // numerirana vrsta pucanja 

    [Header("Bullet info:")]
    public Rigidbody bullet; //Prefab metka kojeg puca ta puška
    public Transform bulletSpawnPoint; //Mjesto gdje se metak stvara (najčešće izlaz cijevi na oružju)
    AudioSource shootSound; //Zvuk ispucaja - mora komponenta biti na oružju
    Bullet bulletScript;

    private void Start()
    {
        currentAmmo = maxAmmo; //Postavljamo da na početku imamo maksimalni iznos metaka
        ammoText.text = currentAmmo + "/" + maxAmmo; //Prikazuje na UI iznos metaka
        shootSound = GetComponent<AudioSource>(); //Dodjeljujemo komponentu audioSource
        fireRateRestart = fireRate; //Postavljamo restart vrijednost za fireRate
        reloadTimeRestart = reloadTime; //Postavljamo vrijednost za reload
        bulletScript = bullet.gameObject.GetComponent<Bullet>();

        if(singleFire == true)
        {
            fireMode = 0;
        }
        else if(automaticFire == true)
        {
            fireMode = 1;
        }
        else if(burstFire == true) //DZ
        {
            fireMode = 2;
        }
    }

    private void Update()
    {
        fireRate -= Time.deltaTime;
        reloadTime -= Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && fireMode == 0 && currentAmmo > 0 && fireRate <= 0)
        {
            Fire();
            fireRate = fireRateRestart;
        }

        if(Input.GetMouseButton(0) && fireMode == 1 && currentAmmo > 0 && fireRate <= 0)
        {
            Fire();
            fireRate = fireRateRestart;
        }

        if(Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo && reloadTime <= 0)
        {
            currentAmmo = maxAmmo;
            reloadTime = reloadTimeRestart;
            ammoText.text = currentAmmo + "/" + maxAmmo;
        }
        if(Input.GetMouseButtonDown(1))
        {
            mainCamera.enabled = false;
            scopeCamera.enabled = true;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            mainCamera.enabled = true;
            scopeCamera.enabled = false;
        }
    }

    void Fire()
    {
        float x = Screen.width / 2;
        float y = Screen.height / 2;

        float x_Acc = Random.Range(x - accuracy, x + accuracy);
        float y_Acc = Random.Range(y - accuracy, y + accuracy);

        var ray = Camera.main.ScreenPointToRay(new Vector3(x_Acc, y_Acc, 0));

        Rigidbody cloneBullet;
        if(fireMode == 0) //Single fire
        {
            currentAmmo--;
            ammoText.text = currentAmmo + "/" + maxAmmo;
            shootSound.Play();
            cloneBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            cloneBullet.velocity = bulletScript.speed * ray.direction;
        }
    }
}
