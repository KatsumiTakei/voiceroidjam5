using System.Collections;
using UnityDLL;
using UnityEngine;
using TMPro;

public enum eSceneState
{
    Title,
    Play,
    Result,
}

public abstract class SceneBase : MonoBehaviour
{
    public SceneBase()
    {
    }

    public abstract void Open();
    public abstract void Close();
}

public class ProgressManager : SingletonMonoBehaviour<ProgressManager>
{
    [SerializeField]
    TextMeshPro textMesh = null;
    
    [SerializeField]
    TitleScene titleScene = null;
    
    [SerializeField]
    PlayScene playScene = null;

    [SerializeField]
    ResultScene resultScene = null;

    SceneBase currentScene = null;


    private void Start()
    {
        //currentScene = titleScene;
        //titleScene.gameObject.SetActive(true);
        //playScene.enabled = false;
        //resultScene.gameObject.SetActive(false);

        Reset();
    }

    void OnEnable()
    {
    }

    void OnDisable()
    {
    }

    public void Reset()
    {
        UpdateHUD();
    }

    void UpdateHUD()
    {
    }


    private void Update()
    {
    }

    public void MoveScene(eSceneState sceneState)
    {
        currentScene.Close();

        switch (sceneState)
        {
            case eSceneState.Title:
                Reset();
                currentScene = titleScene;
                    break;
            case eSceneState.Play:
                currentScene = playScene;
                break;
            case eSceneState.Result:
                currentScene = resultScene;
                break;
        }

        currentScene.Open();
    }

}
