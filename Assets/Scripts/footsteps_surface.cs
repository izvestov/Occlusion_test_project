using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Invector.vCharacterController;
using FMOD.Studio;

public class footsteps_surface : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string footstepsevent;
    public LayerMask layer_varible;
    private float surface_type_varible;
    private vThirdPersonInput tpInput;

    // Start is called before the first frame update
    void Start()
    {
        tpInput = GetComponent<vThirdPersonInput>();
    }

    void footstep()
    {
        if (tpInput.cc.inputMagnitude > 0.1)
        {
            Surface_Check();
            FMOD.Studio.EventInstance eventInstance = FMODUnity.RuntimeManager.CreateInstance(footstepsevent);
            //eventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(transform.position));
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(eventInstance, gameObject.transform, gameObject.GetComponent<Rigidbody>());
            //eventInstance.setParameterByName("isRunning", tpInput.cc.inputMagnitude);
            eventInstance.setParameterByName("surface_type", surface_type_varible);
            eventInstance.start();
            eventInstance.release();
        }
        
    }

    void Surface_Check()
    {
        RaycastHit hit_varible;
        if (Physics.Raycast(transform.position, Vector3.down, out hit_varible, 0.3f, layer_varible))
        {   
            switch (hit_varible.collider.tag)    //Свитч проверки типа поверхности
            {
                case "vLino":
                    surface_type_varible = 0f;
                    break;
                case "vGrate":
                    surface_type_varible = 1f;
                    break;
                case "vDirt":
                    surface_type_varible = 2f;
                    break;
                default:
                    surface_type_varible = 0f;
                    break;
            }
        }
    }
}
