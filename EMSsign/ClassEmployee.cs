using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMSsign
{
     class ClassEmployee
     {
          public string EmployeeId { get; set; }
          public string EmployeeName { get; set; }
          public string MobileNo { get; set; }
          public string Designation { get; set; }
         public string UserRole { get; set; }
         public string UserPassword { get; set; }
         public string EmployerId { get; set; }
         public bool IsVerified { get; set; }

    }
}