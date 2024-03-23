using Godot;
using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public partial class PlayerComponent : IComponent
{
    
}

[Game]
public partial class PositionComponent : IComponent
{
    public Godot.Vector3  Position;
}

[Game]
public partial class ViewComponent : IComponent
{
    public Godot.Node GameObject;
}

[Game][Unique]
public partial class SceneComponent : IComponent
{
    public Godot.Node Root;
}

[Game]
public partial class DisposeComponent : IComponent
{
    
}

[Game][Unique]
[Serializable]
public partial class CurrentTickComponent : IComponent
{
    public int Tick;
    
}
