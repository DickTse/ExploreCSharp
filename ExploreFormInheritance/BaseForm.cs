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
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("BaseForm.OnLoad()");
            base.OnLoad(e);
        }

        protected virtual void BaseForm_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("BaseForm.BaseForm_Load()");
        }
    }
}
