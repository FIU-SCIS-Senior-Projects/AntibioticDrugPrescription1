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
    [Register ("AntibioticSearch")]
    partial class AntibioticSearch
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AntibioticInfo { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField nameField { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton searchButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AntibioticInfo != null) {
                AntibioticInfo.Dispose ();
                AntibioticInfo = null;
            }

            if (nameField != null) {
                nameField.Dispose ();
                nameField = null;
            }

            if (searchButton != null) {
                searchButton.Dispose ();
                searchButton = null;
            }
        }
    }
}