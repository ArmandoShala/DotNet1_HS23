using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DN11.Properties
{
    public partial class WeightField : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Initialize if necessary
        }

        public string TheValue
        {
            get => weightTxt.Text;
            set => weightTxt.Text = value;
        }

        public void Select(object sender, EventArgs arg)
        {
            weightTxt.Text = CalculateWeight(weightTxt.Text, weightDD.SelectedItem.Value).ToString();
        }

        private static double CalculateWeight(string weightText, string unit)
        {
            return double.TryParse(weightText, out double weightValue) && unit.ToUpper() == "LB"
                ? weightValue * 0.453
                : weightValue;
        }
    }
}
