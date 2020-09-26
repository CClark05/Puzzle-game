using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler 
{
    public static int sceneNum = 3;
    public enum Scenes
    {
        Menu,
        Game,
        LevelSelect
    }
    public static int GetSceneIndex(Scenes scene)
    {
        switch (scene)
        {
            default:
            case Scenes.Menu:
                return 0;
            case Scenes.Game:
                return 1;
            case Scenes.LevelSelect:
                return 2;
            
        }
    }


}
