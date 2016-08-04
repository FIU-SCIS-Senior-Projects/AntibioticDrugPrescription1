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
    [Register ("AntibioticPrescription")]
    partial class AntibioticPrescription
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton abs { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton lung { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (abs != null) {
                abs.Dispose ();
                abs = null;
            }

            if (lung != null) {
                lung.Dispose ();
                lung = null;
            }
        }
    }
}