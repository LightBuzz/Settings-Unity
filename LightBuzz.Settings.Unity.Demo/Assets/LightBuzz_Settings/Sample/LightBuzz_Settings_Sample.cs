using LightBuzz.Settings;
using System;
using UnityEngine;

public class LightBuzz_Settings_Sample : MonoBehaviour
{
    private void Start()
    {
        Settings.Initialize();
    }

    public void Set_Click()
    {
        DateTime date = DateTime.Now;

        Settings.Set("lightbuzz_date", date);

        Debug.Log("Saved!");
    }

    public void Get_Click()
    {
        DateTime date = Settings.Get<DateTime>("lightbuzz_date");

        Debug.Log(date);
    }
}
