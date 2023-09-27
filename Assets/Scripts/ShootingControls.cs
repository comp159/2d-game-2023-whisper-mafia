using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingControls : MonoBehaviour
{
    //UPDATE NOTES - 27 SEPT 2023: Limit the number of projectiles on screen to five --> Completed [I'm open to increase the limit or remove this all together]
    //UPDATE (Continued): Add player momentum to projectile speed for a faster projectile
    //UPDATE (Continued): Allow projectile to ONLY bounce once on a 2D collider object and then the next 2D collider destroy the projectile
    
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject projectilePrefab;

    private const int maxProjectilesOnScreen = 5; //Maximum number of projectiles allowed on screen
    
    void Update()
    {
        //checks for left mouse button to be clicked to fire projectile
        //also checks if more than 5 projectiles are on screen
        if (Input.GetMouseButtonDown(0) &&  BulletCount() < maxProjectilesOnScreen)
        {
            Shoot();
        } 
    }

    private void Shoot()
    {
        //Get the direction of the cursor's position
        Vector3 mousePositionScreen = Input.mousePosition;
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);
        mousePositionWorld.z = 0;
        Vector3 shootingDirection = (mousePositionWorld - shootingPoint.position).normalized;

        //Create an instance of the projectile being fired in the direction of the cursor
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.Initialize(shootingDirection);
    }

    private int BulletCount()
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        return projectiles.Length;
    }
}
