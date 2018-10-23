using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.ProvidedInfoViewModel
{
    public class EmploymentEmailVerificationViewModel
    {
        public string CandidateName { get; set; }
        public string CompanyName { get; set; }
        public string CompanyNameAddress            { get; set; }
        public string EmployeeCode                  { get; set; }
        public string PeriodOfEmployment            { get; set; }
        public string Designation                   { get; set; }
        public string Remuneration                  { get; set; }
        public string SupervisorNameDesignation     { get; set; }
        public string Reasonforleaving              { get; set; }
        public string EligibleForRehire             { get; set; }
        public string IsExitFormalitiesCompleted    { get; set; }
        public string DutiesResponsibilitiesHandled { get; set; }
        public string AnyIntegrityDisciplinaryIssue { get; set; }
        public string PerformanceAtWork             { get; set; }
        public string AdditionalComments            { get; set; }
    }   

    public class EducationEmailVerificationViewModel
    {
        public string CandidateName { get; set; }      
        public string UniversityName                { get; set; }
        public string InstituteCollegeSchoolName    { get; set; }
        public string CourseName                    { get; set; }
        public string RollNoRegistrationNoSeatNo    { get; set; }
        public string YearOfPassing                 { get; set; }
        public string Comments                      { get; set; }
    }

    //public class ReferenceEmailVerificationViewModel
    //{
    //    //public string NatureLength              { get; set; }
    //    //public string DutiesResponsibilities    { get; set; }
    //    //public string ProfessionalStrengths     { get; set; }
    //    //public string EffectivenessInMeeting    { get; set; }
    //    //public string AbilityWithStandPressure  { get; set; }
    //    //public string AnyIntegrityIssue         { get; set; }
    //    //public string ModeOfExit                { get; set; }
    //    //public string OverallPerformanceRating  { get; set; }
    //    //public string Remarks                   { get; set; }

    //    //Verified From
    //    //public short TeamMemerRowId { get; set; }
    //    //public string VName { get; set; }
    //    //public string VDesignation { get; set; }
    //    //public string VContactNumber { get; set; }
    //    //public string VEmailId { get; set; }
    //}   
}
