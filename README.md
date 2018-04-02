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
Settings.Set("name", "Vangos Pterneas");
```

### Retrieve a setting

```
string name = (string)Settings.Get("name");
```

### Delete a setting

```
Settings.Remove("name");
```

## Contributors
* [Vangos Pterneas](http://pterneas.com) from [LightBuzz](http://lightbuzz.com)

## License
You are free to use these libraries in personal and commercial projects by attributing the original creator of the project. [View full License](https://github.com/LightBuzz/Settings-Unity/blob/master/LICENSE).
