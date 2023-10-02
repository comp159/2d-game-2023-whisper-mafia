using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingControls : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject gameState;

    private GameManager gameManager;

    private const int maxProjectilesOnScreen = 5; //Maximum number of projectiles allowed on screen

    private GameManager gm;

    void Start()
    {
        gameManager = gameState.GetComponent<GameManager>();
    }
    
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
        projectileScript.Initialize(shootingDirection, gameManager);
        gameManager.ArrowShot(); //Decrements currentArrowCount by 1
    }

    private int BulletCount()
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        return projectiles.Length;
    }
}
