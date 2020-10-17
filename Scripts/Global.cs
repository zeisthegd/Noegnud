using Godot;
using System;

//Class này được sử dụng để chuyển đổi các Scene, thay đổi màn chơi
public class Global : Node
{
    //Scene hiện tại, VD:Stage1
    public static Node CurrentScene { get; set; }
    public override void _Ready()
    {
        Viewport root = GetTree().Root;
        CurrentScene = root.GetChild(root.GetChildCount() - 1);
    }

    public void GotoScene(string path)
    {
        CallDeferred(nameof(DeferredGotoScene), path);
    }

    public void ReloadScene(Node scene)
    {
        scene.GetTree().ReloadCurrentScene();
    }

    public void DeferredGotoScene(string path)
    {
        CurrentScene.Free();
        var nextScene = (PackedScene)GD.Load(path);
        CurrentScene = nextScene.Instance();
        GetTree().Root.AddChild(CurrentScene);
        GetTree().CurrentScene = CurrentScene;
    }


}