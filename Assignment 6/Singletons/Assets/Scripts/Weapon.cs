/*
 * Benjamin Schuster
 * Singletons
 * Parent for weapons
 */
using UnityEngine;
using System.Collections;



public class Weapon: MonoBehaviour
{
    public int damageBonus;

    public Enemy holder;
    
    public void Recharge()
    {
        Debug.Log("Recharging Weapon");
    }

    private void Awake()
    {
        holder = gameObject.GetComponent<Enemy>();
        LoseWeapon(holder);
    }

    protected void LoseWeapon(Enemy enemy)
    {
        Debug.Log("Enemy lost weapon");
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
