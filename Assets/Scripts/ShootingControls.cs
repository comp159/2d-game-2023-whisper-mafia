using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingControls : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject projectilePrefab;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //checks for left mouse button to be clicked to fire projectile
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
}
