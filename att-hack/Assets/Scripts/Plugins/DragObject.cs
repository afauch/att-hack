using UnityEngine;
using System.Collections;
using VRTK;

public class DragObject : MonoBehaviour {

    // Currently this contains definitions for both
    // Mouse-based and controller-based interactions

	private Vector3 screenPoint;
	private Vector3 offset;

    private bool _isGrabbed = false;

	public delegate void Moved (GameObject g);
	public event Moved OnMove;

    void Start()
    {
        // Subscribe to Grab Events for this VRTK_InteractableObject
        GetComponent<VRTK_InteractableObject>().InteractableObjectGrabbed += OnGrab;
        GetComponent<VRTK_InteractableObject>().InteractableObjectUngrabbed += OnUngrab;
        
        // If this GameObject is NOT a handle, then subscribe to the Handle's move events too
        if(this.gameObject.GetComponent<Handle>() == null)
        {
            this.gameObject.GetComponent<UiComponent>()._handle.OnHandleMove += OnMoveMethod;
        }

    }

    void Update()
    {
        if (_isGrabbed)
        {
            OnMoveMethod(this.gameObject);
        }
    }

    void OnMouseDown(){

		if(Input.GetKey(KeyCode.LeftAlt)) {
			return;
		}

		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag(){

		if(Input.GetKey(KeyCode.LeftAlt)) {
			return;
		}

		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;

		// Publish the event
		if (OnMove != null) {
			OnMove (this.gameObject);
		}

	}

    void OnMoveMethod(GameObject g)
    {
        // Publish the event
        if (OnMove != null)
        {
            OnMove(g);
        }
    }

    void OnGrab(object o, InteractableObjectEventArgs e)
    {
        _isGrabbed = true;
    }

    void OnUngrab(object o, InteractableObjectEventArgs e)
    {
        _isGrabbed = false;
    }

}