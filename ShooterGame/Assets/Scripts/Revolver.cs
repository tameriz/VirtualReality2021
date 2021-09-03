using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Revolver : MonoBehaviour
{
    public Transform spawnPoint;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device device;
    public GameObject flashEffectPrefab;

    AudioSource audioSource;

    private void Start(){
        trackedObj = GetComponentInParent<SteamVR_TrackedObject>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);


        //Raycast for debug visible 
        Debug.DrawRay(spawnPoint.transform.position, spawnPoint.transform.forward, Color.red);

        // Raycast to check what we hit
        RaycastHit hit;

        if (Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.transform.tag == "Target")
            {
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    Debug.Log("Trigger pressed");
                    hit.transform.GetComponent<Bottle>().GotShot(hit.point);
                }

            }
        }

        DoOnShoot();
    }

    //Method that are executed when press the trigger
    private void DoOnShoot()
    {
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            device.TriggerHapticPulse(2000);
            audioSource.PlayOneShot(audioSource.clip);
        
            GameObject effect = Instantiate(flashEffectPrefab, spawnPoint.transform.position, Quaternion.identity);
            effect.transform.parent = spawnPoint.transform;
            Destroy(effect, .2f);
        }
    }
}
