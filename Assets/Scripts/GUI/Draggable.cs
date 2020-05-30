using UnityEngine;

public class Draggable : MonoBehaviour 
{
    public bool UsePointerDisplacement = true;
    // PRIVATE FIELDS
    // a flag to know if we are currently dragging this GameObject
    private bool dragging = false;
    // distance from the center of this Game Object to the point where we clicked to start dragging 
    private Vector3 pointerDisplacement = Vector3.zero;
    // distance from camera to mouse on Z axis 
    private float zDisplacement;

    public bool Dragging { get => dragging; set => dragging = value; }

    void onStart()
    {
    }

    // MONOBEHAVIOUR METHODS
    void OnMouseDown()
    {
        Dragging = true;
        zDisplacement = -Camera.main.transform.position.z + transform.parent.position.z;
        if (UsePointerDisplacement)
            pointerDisplacement = -transform.parent.position + MouseInWorldCoords();
        else
            pointerDisplacement = Vector3.zero;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Dragging)
        { 
            Vector3 mousePos = MouseInWorldCoords();
            transform.parent.position = new Vector3(mousePos.x - pointerDisplacement.x, mousePos.y - pointerDisplacement.y, transform.parent.position.z);   
        }
    }

    void OnMouseUp()
    {
        if (Dragging)
        {
            Dragging = false;
        }
    }   

    // returns mouse position in World coordinates for our GameObject to follow. 
    private Vector3 MouseInWorldCoords()
    {
        var screenMousePos = Input.mousePosition;
        screenMousePos.z = zDisplacement;
        return Camera.main.ScreenToWorldPoint(screenMousePos);
    }

}