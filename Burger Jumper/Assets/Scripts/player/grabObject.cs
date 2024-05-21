using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class grabObject : MonoBehaviour
{
    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;
    public GameManager GameManagerScript;

    [HideInInspector]public GameObject grabbedObject;
    private int layerIndex;
    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("grab");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if(hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex){
            
            //grab object
            if (Keyboard.current.eKey.wasPressedThisFrame && grabbedObject == null){
                grabbedObject  = hitInfo.collider.gameObject;
                Debug.Log("Grabbed object:" + grabbedObject);
                GameManagerScript.ball = hitInfo.collider.gameObject.GetComponent<ball>();
                GameManagerScript.trajectory = hitInfo.collider.gameObject.GetComponentInChildren<Trajectory>();
                grabbedObject.GetComponent<ball>().DesactivateRb();
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }

            else if(Keyboard.current.eKey.wasPressedThisFrame && grabbedObject){
                GameManagerScript.ball = null;
                GameManagerScript.trajectory = null;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
                grabbedObject.GetComponent<ball>().ActivateRb();
                // grabbedObject.transform.SetParent(null);
                // grabbedObject = null;
            }
        }

        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }
}
