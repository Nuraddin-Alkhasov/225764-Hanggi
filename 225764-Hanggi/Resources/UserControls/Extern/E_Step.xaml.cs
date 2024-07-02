using HMI.Views.MainRegion;
using HMI.Views.MainRegion.Recipe;
using System;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using VisiWin.ApplicationFramework;
using VisiWin.DataAccess;

namespace HMI.UserControls
{
    public partial class E_Step : UserControl
    {

        public E_Step()
        {
            InitializeComponent();
        }

        #region - - - - Properties - - - -
        readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();

        IVariable VWV_STH;
        IVariable VWV_STM;
        IVariable VWV_STS;

        int stepnumber=1;
        public int StepNumber 
        { 
            get { return stepnumber; }
            set 
            { 
                stepnumber = value;
                SetVariables();
            }
        }
        bool ucloaded = false;

        #endregion

        #region - - - - Event Handlers - - - -
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!ucloaded)
            {
                A.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 1));
                ucloaded = true;
            }
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            step.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
            addView.Visibility = Visibility.Visible;
            addView.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
            steptext.BeginAnimation(ContentControl.MarginProperty, SetMargin(new Thickness(0, steptext.Margin.Top, 0, 0), new Thickness(0, 105, 0, 0), 0.5));
            stepnote.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));

            deletestep.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
            DeleteStepValues();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            sts.Value=1;
        }
        private void StepTime_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            if ((sth.Value == 0) && (stm.Value == 0) && (sts.Value == 0))
            {
                Delete_Click(null, null);
            }
            else 
            {
                if(addView.Visibility != Visibility.Hidden)
                    AddStep();
            }

            ExternAdapter EA = (ExternAdapter)((Extern_Main)iRS.GetView("Extern_Main")).DataContext;
            EA.CalculateTotalTime();
        }

        #region - - - - VWV Change - - - -


        private void VWV_ST_Change(object sender, VariableEventArgs e)
        {
            if (this.IsLoaded)
            {
                if (((short)VWV_STH.Value == 0) && ((short)VWV_STM.Value == 0) && ((short)VWV_STS.Value == 0))
                {
                    Delete_Click(null, null);
                }
                else
                {
                    if (addView.Visibility != Visibility.Hidden)
                        AddStep();
                }

                ExternAdapter RA = (ExternAdapter)((Extern_Main)iRS.GetView("Extern_Main")).DataContext;
                RA.CalculateTotalTime();
            }
        }


        #endregion

        #endregion

        #region - - - - Methods - - - -
        private ThicknessAnimation SetMargin(Thickness _From, Thickness _To, double _T)
        {
            return new ThicknessAnimation
            {
                From = _From,
                To = _To,
                Duration = TimeSpan.FromSeconds(_T),
            };
        }
        private DoubleAnimation SetOpacity(Double _O, double _T)
        {
            return new DoubleAnimation
            {
                To = _O,
                Duration = TimeSpan.FromSeconds(_T),
            };
        }
     
        private void SetVariables() 
        {
            steptext.LocalizableText = "@RecipeSystem.Text" + (80+ StepNumber).ToString();

           

            note.VariableName = "Extern.Recipe.Step[" + StepNumber + "].Note";
            stepnote.VariableName = "Extern.Recipe.Step[" + StepNumber + "].Type";

            sth.VariableName = "Extern.Recipe.Step[" + StepNumber + "].STH";
            stm.VariableName = "Extern.Recipe.Step[" + StepNumber + "].STM";
            sts.VariableName = "Extern.Recipe.Step[" + StepNumber + "].STS";

            VWV_STH = VS.GetVariable("Extern.Recipe.Step[" + StepNumber + "].STH");
            VWV_STH.Change += VWV_ST_Change;
            VWV_STM = VS.GetVariable("Extern.Recipe.Step[" + StepNumber + "].STM");
            VWV_STM.Change += VWV_ST_Change;
            VWV_STS = VS.GetVariable("Extern.Recipe.Step[" + StepNumber + "].STS");
            VWV_STS.Change += VWV_ST_Change;

            count.VariableName = "Extern.Recipe.Step[" + StepNumber + "].Count";
            speed.VariableName = "Extern.Recipe.Step[" + StepNumber + "].Speed";
            change.VariableName = "Extern.Recipe.Step[" + StepNumber + "].Change";

            dimension1.VariableName = "Extern.Recipe.Step[" + StepNumber + "].D1";
            dimension2.VariableName = "Extern.Recipe.Step[" + StepNumber + "].D2";
            dimension3.VariableName = "Extern.Recipe.Step[" + StepNumber + "].D3";

            weight1.VariableName = "Extern.Recipe.Step[" + StepNumber + "].W1";
            weight2.VariableName = "Extern.Recipe.Step[" + StepNumber + "].W2";
            weight3.VariableName = "Extern.Recipe.Step[" + StepNumber + "].W3";

            atype.VariableName = "Extern.Recipe.Step[" + StepNumber + "].AType";

            aweight1.VariableName = "Extern.Recipe.Step[" + StepNumber + "].AWeight1";
            aweight2.VariableName = "Extern.Recipe.Step[" + StepNumber + "].AWeight2";
            aweight3.VariableName = "Extern.Recipe.Step[" + StepNumber + "].AWeight3";

            ftype1.VariableName = "Extern.Recipe.Step[" + StepNumber + "].FType1";
            ftype2.VariableName = "Extern.Recipe.Step[" + StepNumber + "].FType2";
            ftype3.VariableName = "Extern.Recipe.Step[" + StepNumber + "].FType3";

            fweight1.VariableName = "Extern.Recipe.Step[" + StepNumber + "].FWeight1";
            fweight1.VariableName = "Extern.Recipe.Step[" + StepNumber + "].FWeight1";
            fweight1.VariableName = "Extern.Recipe.Step[" + StepNumber + "].FWeight1";
        }

        private void DeleteStepValues() 
        {
            note.Value = "";

            sth.Value = 0;
            stm.Value = 0;
            sts.Value = 0;

            count.Value = 0;
            speed.Value = 0;
            change.Value = 0;

            dimension1.Value = "";
            dimension2.Value = "";
            dimension3.Value = "";

            weight1.Value = 0;
            weight2.Value = 0;
            weight3.Value = 0;

            atype.Value = "";

            aweight1.Value = 0;
            aweight2.Value = 0;
            aweight3.Value = 0;

            ftype1.Value = "";
            ftype2.Value = "";
            ftype3.Value = "";

            fweight1.Value = 0;
            fweight1.Value = 0;
            fweight1.Value = 0;
        }

      

        private void AddStep() 
        {
            addView.Visibility = Visibility.Hidden;
            addView.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
            step.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
            steptext.BeginAnimation(ContentControl.MarginProperty, SetMargin(new Thickness(0, steptext.Margin.Top, 0, 0), new Thickness(0, 20, 0, 0), 0.5));
            stepnote.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3)); ;
            deletestep.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
        }
        #endregion

    }
}
