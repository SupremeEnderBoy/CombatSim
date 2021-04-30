using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    [SerializeField] private Animator myAnimCont;

    public float speed;
    private float waitTime;
    public float startWaitTime;
    

    public Transform[] moveSpots;
    private int randomSpot;

    // Start is called before the first frame update
    void Start()
    {
        myAnimCont.SetBool("walk", true);
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        FaceTarget();

        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                myAnimCont.SetBool("walk", true);
                
            }
            else
            {
                waitTime -= Time.deltaTime;
                myAnimCont.SetBool("walk", false);
            }
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (moveSpots[randomSpot].position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 4f);
    }

}
