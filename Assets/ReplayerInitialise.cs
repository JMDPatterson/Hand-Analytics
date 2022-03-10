using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayerInitialise : MonoBehaviour
{
    public Transform customRepOrigin;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(LateStart(3));
    }
    // Delayed start for enabling motion recorder
    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(3);
        //recorder.customOrigin = startPos;
        //customOrigin.transform = ((MotionRecorder)gameObject.GetComponent<MotionRecorder>()).customOrigin;
        customRepOrigin.transform.position = GameObject.Find("CenterEyeAnchor").transform.position;
        Vector3 pos = customRepOrigin.transform.position;
        pos.y = 0;
        customRepOrigin.transform.position = pos;
        ((MotionReplayer)gameObject.GetComponent<MotionReplayer>()).enabled = true;
    }
}
