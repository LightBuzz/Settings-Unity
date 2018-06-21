# Settings utility for Unity apps

An easy-to-use mchanism for managing the settings within a Unity app.

## Installation
Simply drag-and-drop the ```Settings.cs``` file in your Assets folder.

## Examples
Import the assembly to your project and include its namespace:

```
using LightBuzz.Settings;
```

### Add / Update a setting

```
Settings.Set<string>("name", "Vangos Pterneas");
Settings.Set<int>("age", 30);
Settings.Set<bool>("nice_guy", true);
Settings.Set<float>("height", 1.67f);
```

### Retrieve a setting

```
string name = Settings.Get<string>("name");
int age = Settings.Get<int>("age");
bool niceGuy = Settings.Get<bool>("nice_guy");
float height = Settings.Get<float>("height");
```

### Delete a setting

```
Settings.Remove("name");
Settings.Remove("age");
Settings.Remove("nice_guy");
Settings.Remove("height");
```

## Contributors
* [Vangos Pterneas](http://pterneas.com) from [LightBuzz](http://lightbuzz.com)

## License
You are free to use these libraries in personal and commercial projects by attributing the original creator of the project. [View full License](https://github.com/LightBuzz/Settings-Unity/blob/master/LICENSE).
