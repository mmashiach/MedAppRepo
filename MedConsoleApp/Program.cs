using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using MedAdmin.Models;


class Program
{
    static void Main()
    {
        string filePath = @"C:\\Users\mmash\source\repos\MedAdmin\MedAdmin\\Mock\medEventAdmin.json"; // Replace with the actual file path

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            List<MedAdminEvent> medAdminEventsList = JsonConvert.DeserializeObject<List<MedAdminEvent>>(json);
            List<MedAdminTimeframe> medAdminTimeFrame = new List<MedAdminTimeframe>();
            foreach (var item in medAdminEventsList)
            {
                List< MedAdminTimeframe> medTimeFrame = (List<MedAdminTimeframe>)medAdminTimeFrame.Where(t => t.patient_id == 
                item.patient_id && t.medication_name == item.medication_name);      

            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
