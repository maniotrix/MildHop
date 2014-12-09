using UnityEngine;

public class CenterOnScreen : MonoBehaviour
{
    // The game Object we follow.
    public GameObject go;

    // speed at witch to goto the object
    public float speed = 10;
    //Whether or not to correct.
    public bool correctWidth = true;
    // the screen point we are correcting after.
    private Vector3 point;
    // the screen point at teh center of the screen.
    private Vector3 pointCenter;

    // Use this for initialization
    void Start()
    {
        //todo cache values and transforms with a set method that is used again when the go is changed.
    }

    // Update is called once per frame
    void Update()
    {
        Bounds b = go.collider.bounds;

        Camera cam = Camera.main;

        // LookAt gives a forward vector towards the object.
        cam.transform.LookAt(b.center);

        // This is the point we use to correct after.
        point = cam.WorldToScreenPoint(go.transform.position + new Vector3(b.extents.x, 0, 0));

        pointCenter = cam.WorldToScreenPoint(go.transform.position);

        if (correctWidth)
        {
            Vector3 newPosition = transform.position;
            float screenCenter = Screen.width * 0.5f;
            float halfScreenWidth = screenCenter * 0.5f + Screen.width * 0.5f;

            // the plus 1 is so we don't jump back and forth.
            if (point.x > halfScreenWidth + 1)
            {
                newPosition += -cam.transform.forward * Time.deltaTime * speed;
            }
            if (point.x < halfScreenWidth - 1)
            {
                newPosition += cam.transform.forward * Time.deltaTime * speed;
            }

            cam.transform.position = newPosition;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(point.x, point.y, 30, 16), "point", "button");
        GUI.Label(new Rect(pointCenter.x, pointCenter.y, 30, 16), "c", "button");
    }
}
