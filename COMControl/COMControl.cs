using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ExploreCSharp.COMControl
{
    [Guid("3DE32ECD-EECF-4110-8560-AC8DFD468E8A")]
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class COMControl
    {
        private int _count = 0;

        public COMControl()
        {
            _count = 1;
        }

        [ComVisible(true)]
        public int Count { get { return _count; } }

        [ComVisible(true)]
        public void SayHello()
        {
            MessageBox.Show("Say Hello from COM control");
        }
    }
}
