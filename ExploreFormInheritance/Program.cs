/* This project tests what it looks like if we inherit the OnLoad() method and the Load event handler from a parent Windows
 * Form class in a child Windows Form class.
 * 
 * Case 1
 * - Override both OnLoad method and Load event handler from the base class
 * - Call base.OnLoad(e) and base.BaseForm_Load(sender, e) in the child's OnLoad() method and Load event handler respectively.
 * 
 * Outcome:
 *   ChildForm.OnLoad()
 *   BaseForm.OnLoad()
 *   ChildForm.BaseForm_Load()
 *   BaseForm.BaseForm_Load()
 * 
 * 
 * Case 2
 * - Only override the OnLoad() method without overriding the Load event handler.
 * - Call base.OnLoad(e) in the child's OnLoad() method.
 * 
 * Outcome:
 *   ChildForm.OnLoad()
 *   BaseForm.OnLoad()
 *   BaseForm.BaseForm_Load()
 * 
 * 
 * Case 3
 * - Only override the Load event handler without overriding the OnLoad() method.
 * - Call base.BaseForm_Load(sender, e) in the child's Load event handler.
 * 
 * Outcome:
 *   BaseForm.OnLoad()
 *   ChildForm.BaseForm_Load()
 *   BaseForm.BaseForm_Load()
 * 
 * 
 * Case 4
 * - Override neither the OnLoad() method nor the Load event handler.
 * 
 * Outcome:
 *   BaseForm.OnLoad()
 *   BaseForm.BaseForm_Load()
 * 
 * 
 * Case 5
 * - Only override the OnLoad() method without overriding the Load event handler.
 * - NOT calling base.OnLoad(e) in the child's OnLoad() method.
 * 
 * Outcome:
 *   ChildForm.OnLoad()
 * 
 * 
 * Case 6
 * - Only override the Load event handler without overriding the OnLoad() method.
 * - NOT calling base.BaseForm_Load(sender, e) in the child's Load event handler.
 * 
 * Outcome:
 *   BaseForm.OnLoad()
 *   ChildForm.BaseForm_Load()
 * 
 * 
 * Case 7
 * - Only override the Load event handler without overriding the OnLoad() method.
 * - Set the child form's own Load event handler to it's own BaseForm_Load() method.
 * - NOT calling base.BaseForm_Load(sender, e) in the child's Load event handler.
 * 
 * Outcome:
 *   BaseForm.OnLoad()
 *   ChildForm.BaseForm_Load()
 *   ChildForm.BaseForm_Load()
 * 
 * 
 * Case 8
 * - Only override the Load event handler without overriding the OnLoad() method.
 * - Set the child form's own Load event handler to it's own BaseForm_Load() method.
 * - Call base.BaseForm_Load(sender, e) in the child's Load event handler.
 * 
 * Outcome:
 *   BaseForm.OnLoad()
 *   ChildForm.BaseForm_Load()
 *   BaseForm.BaseForm_Load()
 *   ChildForm.BaseForm_Load()
 *   BaseForm.BaseForm_Load()
 * 
 * 
 * 
 * Findings:
 * 1. OnLoad() method is always triggered before the Load event handler.
 * 2. If overriding the parent's Load event handler and setting the child form's own Load event handler at the same time, 
 *    the child's own Load event handler will be executed twice. So, NEVER set the child form's own Load event handler if 
 *    you are going to override the parent's Load event handler.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExploreFormInheritance
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ChildForm());
        }
    }
}
