using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    bool onClick = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    
    // Update is called once per frame
    void Update()
    {

    }
    

    void OnMove(InputValue movementValue)
    {
        //Get the movement vector
        Vector2 movementVector = movementValue.Get<Vector2>();

        //Get the current position of the GameObject
        Vector2 currenPos = transform.position;

        // Left
        if (movementVector.x > 0)
        {
            transform.position = new Vector2(currenPos.x + 0.5f, currenPos.y);
        }
        // Right
        if (movementVector.x < 0)
        {
            transform.position = new Vector2(currenPos.x - 0.5f, currenPos.y);
        }
        // Up
        if (movementVector.y > 0)
        {
            transform.position = new Vector2(currenPos.x, currenPos.y + 0.5f);
        }
        // Down
        if (movementVector.y < 0)
        {
            transform.position = new Vector2(currenPos.x, currenPos.y - 0.5f);
        }

    }

    void OnPoint(InputValue pointValue)
    {
        Vector2 pointVector = pointValue.Get<Vector2>();

        if (onClick)
        {
            //Get the 3D position of the mouse
            transform.position = MousePosTo3D(pointVector);
        }

    }

    void OnClick() {

        onClick = !onClick;
    }

    //Converts the mouse position from screen coordinates to World coordinates
    Vector3 MousePosTo3D(Vector2 mousePos) {

        Vector3 pos = Vector3.zero;

        // Convert screen space to world space
        var ray = Camera.main.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);

        RaycastHit hit;

        // Check if the ray hits an object
        if (Physics.Raycast(ray, out hit))
        {
            // Return the hit point
            return hit.point;
        }

        return Vector3.zero;
    }

}
