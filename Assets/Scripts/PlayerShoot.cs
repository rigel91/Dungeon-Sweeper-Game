using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour
{
    //bullet prefabs
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletSpawnPosition;
    //ammo text
    public Text ammoText;

    //bullet force
    [SerializeField]
    private float shootForce, upwardForce;

    //----------------Gun stats---------------------------
    [SerializeField]
    private float timeBetweenShooting, spread, reloadTime;
    //time between shots if multiple shots
    [SerializeField]
    private float timeBetweenShots;
    
    //size of clip
    [SerializeField]
    private int magSize;
    
    //number of bullets shot per shot
    [SerializeField]
    private int bulletsPerTap;
    
    //checks if we want to hold down mouse
    bool allowButtonHold = true;

    //in game variables
    int bulletsLeft, bulletsShot;
    bool shooting, readyToShoot, reloading;

    //camera
    [SerializeField]
    private Camera cam;

    // Start is called before the first frame update
    void Awake()
    {
        bulletsLeft = magSize;
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        //display ammo text
        ammoText.text = (bulletsLeft / bulletsPerTap).ToString() + " / " + (magSize / bulletsPerTap).ToString();
    }

    private void PlayerInput()
    {
        if (allowButtonHold)
        {//hold down to shoot
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {//tap to shoot
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        //reload
        if(Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading)
        {
            Reload();
        }
        //reload automatically
        if(readyToShoot && shooting && !reloading && bulletsLeft <= 0)
        {
            Reload();
        }

        //player is shooting
        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //find the distance between bullet spawn point and the middle of the camera where the bullet wants to go
        //send ray out from middle of camera
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        Vector3 targetPoint;

        if(Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        //get distance depending on spread
        Vector3 direction = targetPoint - bulletSpawnPosition.position; ;
        if(spread > 0)
        {
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);
            direction = direction + new Vector3(x, y, 0);
        }

        //Instantiate object
        GameObject b = Instantiate(bullet, bulletSpawnPosition.position, Quaternion.identity);
        //change direction of bullet
        b.transform.forward = direction.normalized;

        //add force to bullet
        b.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
        //to add upward force for heavier bullets
        //b.GetComponent<Rigidbody>().AddForce(cam.transform.up * upwardForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot++;

        //shot is reset after shooting and will shoot again when time is done
        Invoke("ResetShot", timeBetweenShooting);
                  
        //if more than one bullet is being shot at once, repeat shoot function
        if(bulletsShot < bulletsPerTap && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magSize;
        reloading = false;
    }
}
