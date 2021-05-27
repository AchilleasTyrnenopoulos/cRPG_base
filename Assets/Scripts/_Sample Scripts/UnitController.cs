using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitController : MonoBehaviour
{
    [SerializeField]
    private bool selected;
    public LayerMask clickMask;
    public NavMeshAgent agent;

    private void OnMouseDown()
    {
        selected = !selected;
        print(name + "was clicked");
    }

    private void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (!selected)
                MouseClick();
            else
                Move();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            //DistanceFromUnit();
        }
    }

    private Vector3 MouseClick()
    {
        Vector3 clickPos = Vector3.zero;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000, clickMask))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                clickPos = hit.point;

                print(clickPos);
                return clickPos;                
            }                
        }

        return this.transform.position;
    }

    private void Move()
    {
        agent.SetDestination(MouseClick());
    }
    //private void DistanceFromUnit()
    //{
    //    Vector3 clickPos = Vector3.zero;

    //    Plane plane = new Plane(this.transform.position, 0f);
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    float distanceToPlane;        
    //    if (plane.Raycast(ray, out distanceToPlane))
    //    {
    //        clickPos = ray.GetPoint(distanceToPlane);
    //        clickPos.y = 0;
    //        print("Distance from player was " + clickPos);
    //    }
    //}
}
