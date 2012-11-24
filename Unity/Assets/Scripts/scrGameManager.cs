using UnityEngine;
using System.Collections;

public class scrGameManager : MonoBehaviour
{
    public bool DebugMode;

    // Use this for initialization
    public void Start()
    {
        print("changed physics.gravity!");
        Physics.gravity = new Vector3(x: 0F, y: -40F, z: 0F);
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public static bool IsDebugMode()
    {
        return ((scrGameManager)FindObjectOfType(typeof (scrGameManager))).DebugMode;
        ;
    }
}
