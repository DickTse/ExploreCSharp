using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExploreFormInheritance
{
    public partial class ChildForm : BaseForm
    {
        public ChildForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("ChildForm.OnLoad()");
            base.OnLoad(e);
        }

        protected override void BaseForm_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("ChildForm.BaseForm_Load()");
            base.BaseForm_Load(sender, e);
        }
    }
}
