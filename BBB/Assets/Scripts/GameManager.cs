using UnityEngine;

[CreateAssetMenu]
public class GameManager : ScriptableObject
{
    private static GameManager _instance = null;
    private SceneLoader _sceneLoader = new SceneLoader("Loading");
    
    public void LoadScene(SceneGroup group)
    {
        _sceneLoader.Load(group);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = Resources.Load<GameManager>("GameManager");
                if (_instance == null)
                    _instance = CreateInstance<GameManager>();
            }

            return _instance;
        }
    }
}
