using UnityEngine;

public class FactoryScript : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

        // if we are within range of a belt, then connect to it, changing the port color to green. 
        float range = 2.0f;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].gameObject.tag == "Belt")
            {
                // hitColliders[i].gameObject.GetComponent<BeltScript>().ConnectToFactory(gameObject);
                gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.green;
            }
            //else
            //{
            //    gameObject.transform.GetChild(0).GetComponent<Renderer>().material.color = Color.blue;
            //}
            i++;
        }
    }
}
