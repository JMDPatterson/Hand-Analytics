using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AveragePronation : MonoBehaviour
{
    public Transform target;
    private int count = 0;
    private float sum = 0;
    private float avg = 0;
    [SerializeField]
    private TextMeshProUGUI transformText;

    // Update is called once per frame
    void LateUpdate()
    {
        count++;
        float ang = target.transform.rotation.eulerAngles.z;
        ang = Mathf.Repeat(ang + 180, 360) - 180;
        sum += ang;
        avg = sum / count;
        transformText.text = string.Format(@"Mean Forearm Pronation: {0:0.0} deg"
, avg);
    }
}
