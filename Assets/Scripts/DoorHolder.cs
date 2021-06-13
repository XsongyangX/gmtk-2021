using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHolder : MonoBehaviour
{
    [SerializeField] GameObject[] doors;

    public void OpenDoor(int doorNumber)
    {
        Debug.Log(doors.Length);
        doors[doorNumber].SetActive(false);
    }
}
