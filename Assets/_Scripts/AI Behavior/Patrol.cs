using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;
    
    public Transform[] moveSpots;
    private int randomSpot;
    [SerializeField] private Animator anim;
    

    public Quaternion lookAt;
    private Rigidbody rbody;




    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        anim.GetComponent <Animator>();
        //lookAt = ChooseDirection();
        rbody = GetComponent<Rigidbody>();
        //transform.rotation = Quaternion.LookRotation(moveSpots[randomSpot].forward);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        transform.rotation = Quaternion.LookRotation(moveSpots[randomSpot].forward);


        if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                anim.SetBool("Walk", true);

                transform.rotation = Quaternion.LookRotation(moveSpots[randomSpot].forward);
                
            }
            else
            {
                waitTime -= Time.deltaTime;
                anim.SetBool("Walk", false);
            }
        }
    }

}
