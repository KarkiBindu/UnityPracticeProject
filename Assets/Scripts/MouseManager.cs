using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask ClickableLayer;
    public Texture2D Target;
    public Texture2D Pointer;
    public Texture2D DoorWay;
    public Texture2D Combat;

    public EventVector3 OnClickEnvironment;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, ClickableLayer.value))
        {
            bool door = false;
            bool item = false;

            if(hit.collider.gameObject.tag == "Doorway")
            {
                Cursor.SetCursor(DoorWay, new Vector2(16, 16), CursorMode.Auto);
                door = true;
            }
            else if(hit.collider.gameObject.tag == "Item")
            {
                Cursor.SetCursor(Combat, new Vector2(16, 16), CursorMode.Auto);
                item = true;
            }
            else
            {
                Cursor.SetCursor(Target, new Vector2(16, 16), CursorMode.Auto);
            }
            if (Input.GetMouseButtonDown(0))
            {
                if (door)
                {
                    Transform doorway = hit.collider.gameObject.transform;
                    OnClickEnvironment.Invoke(doorway.position);
                }
                else if (item)
                {
                    Transform itemPos = hit.collider.gameObject.transform;
                    OnClickEnvironment.Invoke(itemPos.position);
                }
                else
                    OnClickEnvironment.Invoke(hit.point);
            }
        }
        else
        {
            Cursor.SetCursor(Pointer, Vector2.zero, CursorMode.Auto);
        }
    }
}

[System.Serializable]
public class EventVector3: UnityEvent<Vector3> { }
