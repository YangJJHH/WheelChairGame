using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


public class AICar : AIController
{
    [SerializeField] float power = 4000f;
    // Start is called before the first frame update
    void Start()
    {
        wayPoint = GameObject.Find("CarWayPoints").GetComponentsInChildren<Transform>().ToList();
        wayPoint.RemoveAt(0);
        FindTarget();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToTarget();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ãæµ¹");
        if(collision.gameObject.tag == "WheelChair")
        {
            collision.rigidbody.AddForce(transform.forward * power,ForceMode.Impulse);
            collision.transform.Find("PlayerClone").gameObject.SetActive(true);
            collision.transform.Find("Player").gameObject.SetActive(false);
            GameManager.Instance.GameOver();
        }
    }
}
