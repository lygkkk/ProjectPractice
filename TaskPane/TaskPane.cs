using Microsoft.Office.Tools.Excel;
using Excel = Microsoft.Office.Interop.Excel;
namespace TaskPane
{
    public class TaskPane
    {
        private Microsoft.Office.Tools.Excel.ApplicationFactory _factory = (ApplicationFactory)typeof(ApplicationFactory);
        public Microsoft.Office.Tools.CustomTaskPaneCollection CustomTaskPanes;
        public Microsoft.Office.Tools.CustomTaskPane CustomTaskPane;
        private Excel.Application _app = new Excel.Application();
        public Microsoft.Office.Tools.Excel.ApplicationFactory Factory
        {
            get => _factory;
            set
            {
                if (_factory == null)
                {
                    _factory = value;
                }
                else
                {
                    throw new System.NotSupportedException();
                }
            }
        }

        public TaskPane()
        {
            CustomTaskPanes = _factory.CreateCustomTaskPaneCollection(null, null, "CustomTaskPanes", "CustomTaskPanes", this);
            CustomTaskPanes.Add(new UserControl1(), "zdy");
            //Factory =
            //InitControls();
            //CustomTaskPanes.BeginInit();
        }

        private void InitControls()
        {
            CustomTaskPanes = Factory.CreateCustomTaskPaneCollection(null, null, "CustomTaskPanes", "CustomTaskPanes", this);
        }
    }
}