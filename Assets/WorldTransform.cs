using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WorldTransform : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI transformText;
    public Transform target;
    // Update is called once per frame
    void Update()
    {
        Vector3 eulerAngles = target.transform.rotation.eulerAngles;

        eulerAngles.x = Mathf.Repeat(eulerAngles.x + 180, 360) - 180;
        eulerAngles.y = Mathf.Repeat(eulerAngles.y + 180, 360) - 180;
        eulerAngles.z = Mathf.Repeat(eulerAngles.z + 180, 360) - 180;

        transformText.text = string.Format(@"Radial/Ulnar Angle (X):                  {0:0.0} (deg)
Extension/Flexion Angle (Y):          {1:0.0} (deg)
Pronation/Supination Angle (Z):     {2:0.0} (deg)"
, eulerAngles.x, eulerAngles.y, eulerAngles.z);
        

        //Debug.Log("transform.rotation angles x: " + eulerAngles.x + " y: " + eulerAngles.y + " z: " + eulerAngles.z);
    }
}
