
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Grabber : MonoBehaviour
{
    private GameObject selectedObject;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public AudioSource audioSwoosh;
    public AudioClip Swoosh;

    public AudioSource audioWin;
    public AudioClip Win;

    public Rigidbody clouds;

    public GameObject Canvas;
    public List<GameObject> list = new List<GameObject>();
    public LayerMask HitLayer;


    public void Start()
    {
        Canvas.GetComponent<Canvas>().enabled = false;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playClip();

            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();

                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("drag"))
                    {
                        return;
                    }
                    selectedObject = hit.collider.gameObject;

                   
                }
            }
            else {

                Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

                Vector3 cellPosition = RoundToGrid(new Vector3(worldPosition.x, 0f, worldPosition.z));
                selectedObject.transform.position = cellPosition;

                Debug.Log("Cell position: " + selectedObject.gameObject.name);

                selectedObject.GetComponent<Particles>().ParticlesOn();

                selectedObject = null;
                Cursor.visible = true;

                CheckLevelCompleted();
            }

        }

        if (selectedObject != null)
        {
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
            selectedObject.transform.position = new Vector3(worldPosition.x, .25f, worldPosition.z);
            


            if (Input.GetMouseButtonDown(1)) 
            {
                playSwoosh();
               
                    selectedObject.transform.rotation = Quaternion.Euler(new Vector3(
                    selectedObject.transform.rotation.eulerAngles.x,
                    selectedObject.transform.rotation.eulerAngles.y + 90f,
                    selectedObject.transform.rotation.eulerAngles.z)); 
            }
        }
    }

    public Vector3 RoundToGrid(Vector3 inputPosition)
    {
        return new Vector3(Mathf.RoundToInt(inputPosition.x), 0, Mathf.RoundToInt(inputPosition.z));
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane);
        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane);
        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);


        return hit;


    }

    public void CheckLevelCompleted()
    {
        bool IsLevelComplete = true;

        for(int i = 0; i < list.Count; i = i + 1)
        {
            RaycastHit hit;
            if (Physics.Raycast(list[i].transform.position, list[i].transform.forward, out hit, 1.8f, HitLayer))
            {
                
            }
            else
            {
                IsLevelComplete = false;
                break;
            }
        }
        if (IsLevelComplete)
        {
            Canvas.GetComponent<Canvas>().enabled = true;
            Debug.Log("Win");
            playWin();
            

        }

    }

    public void playClip()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
    public void playSwoosh()
    {
        audioSource.clip = Swoosh;
        audioSource.Play();
    }
    public void playWin()
    {
        audioSource.clip = Win;
        audioSource.Play();
    }

}



