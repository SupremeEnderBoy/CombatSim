using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObject : MonoBehaviour
{

    public GameObject obj;
    public GameObject obj2;
    
    public void OnTriggerEnter(Collider other)
    {

        StartCoroutine (timer());

        IEnumerator timer()
        {
            yield return new WaitForSeconds(2);

            if (other.tag == "vrkb_mallet")
            {
                obj.SetActive(false);

                obj2.SetActive(true);
            }

        }

    }

}
