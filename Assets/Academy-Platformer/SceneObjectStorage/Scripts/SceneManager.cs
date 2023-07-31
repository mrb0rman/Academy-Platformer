using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    private ISceneObjectStorage _storage = new SceneObjectStorage();
    void Start()
    {
        var camera = _storage.Create<Camera>("Main Camera");
        print(camera);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
