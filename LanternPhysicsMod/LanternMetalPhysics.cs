using UnityEngine;

public class LanternMetalPhysics : MonoBehaviour {
    
    private Transform lanternBody;
    
    private void Start(){
        lanternBody = transform
            .GetChild(0)
            .GetChild(0);
    }

    private void Update(){
        lanternBody.rotation = 
            Quaternion.Euler(0,0,0);
    }
}