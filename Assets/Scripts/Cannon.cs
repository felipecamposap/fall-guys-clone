using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject bala;
    [SerializeField] private float firerate;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InvokeShooting",firerate,firerate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShootRoutine()
    {
         Instantiate(bala,transform.position,transform.rotation);
        yield return new WaitForSeconds(0);
       
    }
    public void InvokeShooting()
    {
        StartCoroutine (ShootRoutine());
    }
}
