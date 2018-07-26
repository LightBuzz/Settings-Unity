using LightBuzz.Settings;
using System;
using UnityEngine;

public class Sample : MonoBehaviour
{
    private void Start()
    {
        Settings.Initialize();

        DateTime date = DateTime.Now;

        PlayerPrefs.SetString("foo", "bar");

        Settings.Set("foo", "bar");

        date = Settings.Get<DateTime>("date");

        Debug.Log(date);
    }

    public void TestUnity_Click()
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();

        for (int i = 0; i < 1; i++)
        {
            string key = "foo" + i;
            string value = "bar";

            PlayerPrefs.SetString(key, value);
        }

        sw.Stop();

        Debug.Log("Unity time: " + sw.ElapsedMilliseconds);
    }

    public void TestLightBuzz_Click()
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();

        for (int i = 0; i < 1; i++)
        {
            string key = "foo" + i;
            string value = "bar";

            Settings.Set(key, value);
        }

        sw.Stop();

        Debug.Log("LightBuzz time: " + sw.ElapsedMilliseconds);
    }
}
