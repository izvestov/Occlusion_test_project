using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Automatic_door : MonoBehaviour
{
    //public bool isAuto;
    private Animator anim;
    [FMODUnity.EventRef] public string DoorOpenEvent;
    [FMODUnity.EventRef] public string DoorCloseEvent;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
      if(other.tag == "Player")
        {
            anim.SetBool("character_nearby", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("character_nearby", false);
        }
    }
    public void DoorOpen()
    {
        FMOD.Studio.EventInstance evInst = FMODUnity.RuntimeManager.CreateInstance(DoorOpenEvent);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(evInst, gameObject.transform, gameObject.GetComponent<Rigidbody>());
        evInst.start();
        evInst.release();
    }
    public void DoorClose()
    {
        FMOD.Studio.EventInstance evInst = FMODUnity.RuntimeManager.CreateInstance(DoorCloseEvent);
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(evInst, gameObject.transform, gameObject.GetComponent<Rigidbody>());
        evInst.start();
        evInst.release();
    }


}

