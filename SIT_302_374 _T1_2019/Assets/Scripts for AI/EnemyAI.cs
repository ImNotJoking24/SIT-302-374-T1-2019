using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private float movementSpeed;
    private int spotRange;
    private GameObject Player;
    private float dist;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        spotRange = 50;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(this.transform.position, Player.transform.position);
        if (dist < spotRange)
        {
            this.transform.LookAt(Player.transform);
            RaycastHit hit;
            Ray objectRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.red);
            if (Physics.Raycast(objectRay, out hit))
            {

            }
            else
            {
               
            }
        }
    }
}
