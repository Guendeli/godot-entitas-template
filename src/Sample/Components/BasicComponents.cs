using Godot;
using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class PlayerComponent : IComponent
{
    
}

[Game]
public class PositionComponent : IComponent
{
    public Vector3  Position;
}

[Game]
public class ViewComponent : IComponent
{
    public Node GameObject;
}

[Game][Unique]
public class SceneComponent : IComponent
{
    public Node Root;
}

[Game]
public class DisposeComponent : IComponent
{
    
}

[Game][Unique]
[Serializable]
public class CurrentTickComponent : IComponent
{
    public int Tick;
    
}
