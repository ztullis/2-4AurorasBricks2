using System;
using Google.Api.Gax.ResourceNames;
using Google.Cloud.RecaptchaEnterprise.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace _2_4AurorasBricks2.Models

{

    public class CreateAssessmentSample
    {
        // Model Class
        public class FormModel
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}

