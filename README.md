# Entitas 1.14 Template for Godot 3.x LTS
A template to work with Entitas within Godot, including a Sample

- Entitas: https://github.com/sschmid/Entitas
- Godot Version: [3.5.2 LTS](https://godotengine.org/)

## Godot Editor Setup
- Editor Settings -> Builds: MSBuild (VS Build Tool)

## Steps to setup from scratch
if you want to setup Jenny and Entitas for your godot project here are the steps

### Create an empty godot project
Create an empty godot project, and generate the CS files from Project->Tools->C#->Generate.

### Getting Entitas

Get the release version of entitas.zip and Jenny.zip from https://github.com/sschmid/Entitas/releases/tag/1.14.1
Extract the content of Jenny.zip at the root of your project, and Entitas.zip somewhere in your code project 

### Setup Jenny

Setup [Jenny.properties](https://github.com/Guendeli/godot-entitas-template/blob/master/Jenny.properties). Difference from Unity are
- Jenny.Plugins.ProjectPath need to point to you project .csproj file instead of Assembly-CSharp.csproj
- remove "Jenny.Plugins.UpdateCsprojPostProcessor" from Jenny.PostProcessor or it will cause misc errors with Godot Editor as well as subconsequent jenny executions
- Setup Jenny.SearchPaths to point to your Folder where Entitas.dll exists as well as jenny

### Setup Rider/Visual Studio

Unlike in Unity3D where .Dlls are automaticly added, here you have to manually add them from your IDE, check the provided [project.csproj](https://github.com/Guendeli/godot-entitas-template/blob/master/godot-entitas.csproj) as reference.
You need to add the references to:

- Entitas.dll, Entitas.codeGeneration.Attributes.dll from the Entitas/Entitas folder
- DesperateDevs.Caching/Reflection/Extensions/Serialization/Threading from the Entitas/DesperateDevs folder
Also add these two flags in your <PropertyGroup>

```
<PropertyGroup>
    .....
    <_TargetFrameworkDirectories>Jenny.Plugins.ReferenceAssemblyPathsPreProcessor</_TargetFrameworkDirectories>
    <_FullFrameworkReferenceAssemblyPaths>Jenny.Plugins.ReferenceAssemblyPathsPreProcessor</_FullFrameworkReferenceAssemblyPaths>
    .....
  </PropertyGroup>
```

### Jenny Gen:

To run Jenny, open a console from your project root folder and run
```
dotnet ./Jenny/Jenny.Generator.Cli.dll gen
```

You're good to go !

## Sample Demo
from within src/Sample is a small working demo

 
