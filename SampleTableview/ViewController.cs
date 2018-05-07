using System;
using Foundation;
using UIKit;
using System.Collections.Generic;
using ObjCRuntime;

namespace SampleTableview
{
    public partial class ViewController : UIViewController, IUITableViewDelegate, IUITableViewDataSource
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.sampleTableview.Delegate = this;
            this.sampleTableview.DataSource = this;
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public nint RowsInSection(UITableView tableView, nint section)
        {
            return 10;
        }
        [Export("tableView:heightForRowAtIndexPath:")]
        public nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 200;
        }
        [Export("numberOfSectionsInTableView:")]
        public nint NumberOfSections(UITableView tableView)
        {
            return 1;
        }
        public UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            UITableViewCell cell = tableView.DequeueReusableCell("cell");

            if (cell == null)
            {
                cell = tableView.DequeueReusableCell("MyTableViewCellId");
            }


            return cell;
        }
    }
}
