using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityDLL;

public enum eScene
{
    Title,
    Play,
    Result
}

public class ProgressMamager : SingletonMonoBehaviour<ProgressMamager>
{

    SceneBase currentScene = null;
    SceneBase[] scenes = null;

    void Start()
    {
        scenes = new SceneBase []{
            FindObjectOfType<TitleScene>(),
            FindObjectOfType<PlayScene>(),
            FindObjectOfType<ResultScene>(),
        };
    }

    void Update()
    {
        
    }

    public void MoveScene(eScene scene)
    {
        currentScene.gameObject.SetActive(false);
        currentScene = scenes[(int)scene];
        currentScene.gameObject.SetActive(true);
    }


}
