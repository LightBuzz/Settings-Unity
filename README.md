# Settings utility for Unity apps

An easy-to-use mechanism for managing your game settings (```PlayerPrefs```) within your Unity app. The ```LightBuzz.Settings``` framework is exposing a generic C# API that allows you to store a lot of different value types.

```
DateTime date = Settings.Get<DateTime>("date_time_key");
```

## Supported data types

The following data types are currently supported:

* ```bool```
* ```int```
* ```short```
* ```long```
* ```float```
* ```double```
* ```string```
* ```DateTime```
* ```Guid```

## Supported Platforms

The ```LightBuzz.Settings``` framework supports all of the Unity platforms:

* Android
* iOS
* Standalone (Windows & Mac OS X)
* Universal Windows Platform (UWP)
* HoloLens

## Examples

Simply import the [latest Unity Package](https://github.com/LightBuzz/Settings-Unity/releases/latest) or the ```LightBuzz.Settings.dll``` file in your Assets folder.

### Initialization

Upon importing the assembly to your project, include its namespace in your C# file:

```
using LightBuzz.Settings;
```

Then, initialize the Settings module from Unity's main thread:

```
private void Start()
{
   Settings.Initialize();
}
```

### Add / Update a setting

```
Settings.Set<string>("name", "Vangos Pterneas");
Settings.Set<bool>("nice_guy", true);
Settings.Set<double>("height", 1.670);
Settings.Set<DateTime>("birthday", new DateTime(1988, 05, 20));
```

### Retrieve a setting

```
string name = Settings.Get<string>("name");
bool niceGuy = Settings.Get<bool>("nice_guy");
double height = Settings.Get<double>("height");
DateTime birthday = Settings.Get<DateTime>("birthday");
```

### Delete a setting

```
Settings.Remove("name");
Settings.Remove("nice_guy");
Settings.Remove("height");
Settings.Remove("birthday");
```

## Contributors
* [Vangos Pterneas](http://pterneas.com) from [LightBuzz](http://lightbuzz.com)

## License
You are free to use these libraries in personal and commercial projects by attributing the original creator of the project. [View full License](https://github.com/LightBuzz/Settings-Unity/blob/master/LICENSE).
