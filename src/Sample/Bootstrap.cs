using Godot;
using System;
using Entitas;

public class Bootstrap : Node
{
    private Contexts _contexts;
    private Systems _feature;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _contexts = Contexts.sharedInstance;
        
        var rootScene = GetTree().Root;
        _contexts.game.ReplaceScene(rootScene);
        
        _feature = new GameFeature(_contexts);
        if (_feature != null)
        {
            _feature.Initialize();
        }
    }

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
      if (_feature != null)
      {
          _feature.Execute();
          _feature.Cleanup();
      }
  }
}
