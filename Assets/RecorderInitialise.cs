using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecorderInitialise : MonoBehaviour
{
    private OVRSkeleton skeleton;
    public Transform customRecOrigin;
    //public MotionRecorder recorder;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(LateStart(3));
    }
    // Delayed start for enabling motion recorder
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(3);
        customRecOrigin.transform.position = GameObject.Find("CenterEyeAnchor").transform.position;
        Vector3 pos = customRecOrigin.transform.position;
        pos.y = 0;
        customRecOrigin.transform.position = pos;
        //((MotionRecorder)gameObject.GetComponent<MotionRecorder>()).customOrigin = customRecOrigin;
        ((MotionRecorder)gameObject.GetComponent<MotionRecorder>()).enabled = true;
    }  
}
