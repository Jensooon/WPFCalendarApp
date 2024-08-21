using CalendarApp.Config;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CalendarApp.ViewModels
{
	public class SettingsViewModel : BindableBase
	{

        public bool newSave = true;
        public SettingsViewModel()
        {
            CalendarSettings myCalendarSettings = new CalendarSettings();
        }

        private void OpenConfig()
        {
            OpenFileDialog JSONFile = new OpenFileDialog();
            JSONFile.Filter = "JSON Files (*.json)|*.json";
            JSONFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (JSONFile.ShowDialog() == true)
            {
                try
                {

                    string data = File.ReadAllText(JSONFile.FileName);

                    JObject obj = JObject.Parse(data);

                    //Sets the opened json object to my settings object
                    CalendarSettings myCalendarSettings = obj.ToObject<CalendarSettings>();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Inavlid configuration file.");
                }

            }
        }

        private void SaveConfig()
        {

            //Need to copy current Calendar settings to this object to write to
            object myCalendarSettings = null;
            var jsonWriter = JsonConvert.SerializeObject(myCalendarSettings, Formatting.Indented);

            if (newSave)
            {
                SaveAsConfig();
            }
            else
            {
                using (var writer = new StreamWriter("calendarSettings.json"))
                {
                    writer.Write(jsonWriter);
                }
            }

        }
        private void SaveAsConfig()
        {
            SaveFileDialog saveConfDialog = new SaveFileDialog();
            saveConfDialog.DefaultExt = ".json";
            saveConfDialog.Filter = "JSON Files (*.json)|*.json";
            saveConfDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveConfDialog.AddExtension = true;
            saveConfDialog.OverwritePrompt = true;

            if (saveConfDialog.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(saveConfDialog.FileName))
                {
                    newSave = false;
                    SaveConfig();

                }
            }
        }
    }
}
