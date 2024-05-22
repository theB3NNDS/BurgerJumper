using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   #region Singleton class: GameManager

	public static GameManager Instance;

	void Awake ()
	{
		if (Instance == null) {
			Instance = this;
		}
		audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audioManager>();
	}

	#endregion

	Camera cam;

	public ball ball;
    public grabObject grabObjectscript;
	public Trajectory trajectory;
	[SerializeField] float pushForce = 4f;

	bool isDragging = false;
    

	Vector2 startPoint;
	Vector2 endPoint;
	Vector2 direction;
	Vector2 force;
	float distance;

	audioManager audioManager;

	//---------------------------------------
	void Start ()
	{
		cam = Camera.main;
		// ball.DesactivateRb ();
	}

	void Update ()
	{
       if(grabObjectscript.grabbedObject){

       
            if (Input.GetMouseButtonDown (0)) {
                isDragging = true;
                OnDragStart ();
            }
            if (Input.GetMouseButtonUp (0)) {
                isDragging = false;
                OnDragEnd ();
            }

            if (isDragging) {
                OnDrag ();
            }
       } 
	}

	//-Drag--------------------------------------
	void OnDragStart ()
	{
		ball.DesactivateRb ();
		startPoint = cam.ScreenToWorldPoint (Input.mousePosition);

		trajectory.Show ();
	}

	void OnDrag ()
	{
		endPoint = cam.ScreenToWorldPoint (Input.mousePosition);
		distance = Vector2.Distance (startPoint, endPoint);
		direction = (startPoint - endPoint).normalized;
		force = direction * distance * pushForce;

		//just for debug
		Debug.DrawLine (startPoint, endPoint);


		trajectory.UpdateDots (ball.pos, force);
	}

	void OnDragEnd ()
	{
		//push the ball
		ball.ActivateRb ();

		ball.Push (force);
		audioManager.PlaySFX(audioManager.shoot);

		trajectory.Hide ();
        grabObjectscript.grabbedObject = null;
        
	}
}
