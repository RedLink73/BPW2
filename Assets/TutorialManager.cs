using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;


    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }

        
        if (popUpIndex == 0)
        {
            if (Input.GetMouseButtonDown(0))

            {
                Debug.Log(popUpIndex);
                popUpIndex++;
            }
        }


        else if (popUpIndex == 1)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log(popUpIndex);

                popUpIndex++;
            } 
        }


        else if (popUpIndex == 2)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log(popUpIndex);

                popUpIndex++;
            }
        }


        else if (popUpIndex == 3)
        {
            if (Input.anyKeyDown)
            {
                Debug.Log(popUpIndex);

                popUpIndex++;
            }
        }

        else if (popUpIndex == 4)
        {
            if (Input.anyKeyDown)
            {
                Debug.Log(popUpIndex);

                popUpIndex++;
            }
        }


    }
}




