using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTest : MonoBehaviour
{
    private NavMeshAgent nav;
    [SerializeField] private Transform destination;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
