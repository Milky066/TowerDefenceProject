using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Responsible for camera movement 
    public float panSpeed = 10f;
    public float panBoarder = 25f;
    public float scrollSpeed = 10f;

    private float scroll;
    void Update()
    {
        if(GameManager.gameEnd==true)
        {
            this.enabled = false;
            return;
        }
        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBoarder)
        {
            transform.Translate(new Vector3(-1f, 0f, 0f) * panSpeed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBoarder)
        {
            transform.Translate(new Vector3(0f, 0f, -1f) * panSpeed * Time.deltaTime,Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBoarder)
        {
            transform.Translate(new Vector3(0f, 0f, 1f) * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBoarder)
        {
            transform.Translate(new Vector3(1f, 0f, 0f) * panSpeed * Time.deltaTime, Space.World);
        }
        scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 100 * Time.deltaTime * scrollSpeed;
        transform.position = pos;
    }
}
