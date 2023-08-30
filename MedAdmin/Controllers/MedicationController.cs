using MedAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Collections.Generic;
using System.Collections;

namespace MedicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicationController : ControllerBase
    {
        private readonly List<MedAdminTimeframe> timeframes;

        public MedicationController(List<MedAdminTimeframe> timeframes)
        {
            this.timeframes = timeframes;
        }

        [HttpGet("/get_periods")]
        public Dictionary<string, string> GetMedicationPeriods(string patientId)
        {
       
            List<MedAdminTimeframe> lst = (List<MedAdminTimeframe>)timeframes.Where(t => t.patient_id == patientId);
            Dictionary<string, string> allDrugsOfPatients = new Dictionary<string, string>();

            if (lst != null)
            {
                List<string> medications = lst.Select(t => t.medication_name).Distinct().ToList();

                foreach (var medication in medications)
                {
                    List<MedAdminTimeframe> lstWithDrug = (List<MedAdminTimeframe>)lst.Where(t => t.medication_name == medication && 
                                                                   t.start_date.HasValue && t.end_date.HasValue);

                    var sumOfMed = lstWithDrug.Sum(t => long.Parse(t.end_date.Value.ToString()) - long.Parse(t.start_date.Value.ToString()));
                    allDrugsOfPatients.Add(medication, sumOfMed.ToString());
                }
            }
            return allDrugsOfPatients;
        }
    }
}
