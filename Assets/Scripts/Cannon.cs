using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private GameObject bala;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ShootRoutine()
    {
         Instantiate(bala,transform.position,transform.rotation);
        yield return new WaitForSeconds(4.0f);
        StartCoroutine(ShootRoutine());
    }
}
