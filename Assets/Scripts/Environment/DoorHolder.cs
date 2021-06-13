using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHolder : MonoBehaviour
{
    [SerializeField] GameObject[] doors;

    public void OpenDoor(int doorNumber)
    {
        if (doorNumber < doors.Length)
        {
            // audio cue
            GameObject door = doors[doorNumber];

            var audio = door.GetComponent<AudioSource>();
            audio.Play();
            StartCoroutine(VanishAfter(audio.clip.length + 0.2f, door));
        }
    }

    private IEnumerator VanishAfter(float duration, GameObject door)
    {
        yield return new WaitForSecondsRealtime(duration);
        door.SetActive(false);
    }
}
