using System;
using System.Collections.Generic;
using MedAdmin.Models; // Make sure you import the appropriate namespace
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MedicationAPI.Controllers;

namespace MedicationAPI.Tests
{
    [TestClass]
    public class MedicationControllerTests
    {
        [TestMethod]
        public void GetMedicationPeriods_ValidPatientId_ReturnsMedicationPeriods()
        {
            // Arrange
            var timeframes = new List<MedAdminTimeframe>
            {
                new MedAdminTimeframe { patient_id = "123", medication_name = "MedA", start_date = DateTime.Parse("2023-08-01"), end_date = DateTime.Parse("2023-08-03") },
                new MedAdminTimeframe { patient_id = "123", medication_name = "MedA", start_date = DateTime.Parse("2023-08-05"), end_date = DateTime.Parse("2023-08-06") }
            };

            var controller = new MedicationController(timeframes);

            // Act
            var result = controller.GetMedicationPeriods("123");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.IsTrue(result.ContainsKey("MedA"));
            Assert.AreEqual("2", result["MedA"]);
        }

        [TestMethod]
        public void GetMedicationPeriods_InvalidPatientId_ReturnsEmptyDictionary()
        {
            // Arrange
            var timeframes = new List<MedAdminTimeframe>
            {
                new MedAdminTimeframe { patient_id = "456", medication_name = "MedB", start_date = DateTime.Parse("2023-09-01"), end_date = DateTime.Parse("2023-09-05") }
            };

            var controller = new MedicationController(timeframes);

            // Act
            var result = controller.GetMedicationPeriods("789");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }
    }
}
