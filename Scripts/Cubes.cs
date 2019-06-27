using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
  
    // Use this for initialization
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Camera cam = Camera.main;
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {

            Transform objectHit = hit.transform;

            // Do something with the object that was hit by the raycast.
        }

    }

    void OnMouseDrag()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));

    }



    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collision Enter");
        if (col.gameObject.tag == "Bucket")
        {
            Debug.Log("Hit bucket");
            Destroy(this.gameObject);
        }
    }
}