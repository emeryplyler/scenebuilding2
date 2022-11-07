using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changelightrotation : MonoBehaviour
{
    Light dir_light;
    // Start is called before the first frame update
    void Start()
    {
        dir_light = GetComponent<Light>();
    }

    // cube1.transform.Rotate(90.0f, 0.0f, 0.0f, Space.Self);
    // Vector3 l_vec1 = new Vector3(385.172f, -91, 269.556f);
    // Vector3 l_vec2 = new Vector3(203.209f, -89.01501f, 269.593f);
    // Vector3 l_vec3 = new Vector3(745.172f, 269f, 629.556f);
    Vector3 l_vec1 = new Vector3(45, -90, 0);
    Vector3 l_vec2 = new Vector3(225, -90, 0);
    Vector3 l_vec3 = new Vector3(405, -90, 0);

    public double l_frames = 0;
    public Vector3 currentVec;
    public float fraction = 0;

    // Update is called once per frame
    void Update()
    {
        l_frames = (Time.time % 13.33) * 60;

        if (l_frames >= 0 && l_frames <= 400) {
            fraction = (float)(l_frames / 400);
            currentVec = Vector3.Lerp(l_vec1, l_vec2, fraction);
            
        } else {
            fraction = (float)((l_frames - 400) / 400);
            currentVec = Vector3.Lerp(l_vec2, l_vec3, fraction);

        }

        // dir_light.transform.Rotate(currentVec.x, currentVec.y, currentVec.z, Space.Self);
        dir_light.transform.eulerAngles = currentVec;

        // dir_light.transform.Rotate(0.45f, 0, 0, Space.Self);
        // TODO: use the euler angle changing function instead of rotate
    }
}
