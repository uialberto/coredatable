using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApp.Entities
{   
    public enum Position
    {
        [Display(Name = "Accountant")]
        Accountant,
        [Display(Name = "Chief Executive Officer")]
        ChiefExecutiveOfficer,
        [Display(Name = "Integration Specialist")]
        IntegrationSpecialist,
        [Display(Name = "Junior Technical Author")]
        JuniorTechnicalAuthor,
        [Display(Name = "Pre Sales Support")]
        PreSalesSupport,
        [Display(Name = "Sales Assistant")]
        SalesAssistant,
        [Display(Name = "Senior Javascript Developer")]
        SeniorJavascriptDeveloper,
        [Display(Name = "Software Engineer")]
        SoftwareEngineer
    }
}
