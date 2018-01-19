using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomCoroutine {
    public static IEnumerator WaitForSeconds(float time)
    {
        float start = Time.realtimeSinceStartup;
        
        while(Time.realtimeSinceStartup < (start + time)){
            yield return null;
        }
    }
}
