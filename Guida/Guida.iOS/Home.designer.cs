// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Guida.iOS
{
    [Register ("Home")]
    partial class Home
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BodyParts { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PatientsInfo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SearchAntibiotic { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BodyParts != null) {
                BodyParts.Dispose ();
                BodyParts = null;
            }

            if (PatientsInfo != null) {
                PatientsInfo.Dispose ();
                PatientsInfo = null;
            }

            if (SearchAntibiotic != null) {
                SearchAntibiotic.Dispose ();
                SearchAntibiotic = null;
            }
        }
    }
}