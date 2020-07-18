namespace RhinoWPFIntorWorkshop.VeiwsModels
{
    class MyViewModel : Rhino.UI.ViewModel
    {
        public MyViewModel(uint documentSerialNumber)
        {
            documentSerialNumber = documentSerialNumber;
            Rhino.UI.Panels.Show += OnShowPanel;
        }

        private void OnShowPanel(object sender, Rhino.UI.ShowPanelEventArgs e)        {            var sn = e.DocumentSerialNumber;        }        private uint DocumentRuntimeSerialNumber { get; }
    }
}
