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
    public partial class R_Step : UserControl
    {

        public R_Step()
        {
            InitializeComponent();
        }

        #region - - - - Properties - - - -
        readonly IVariableService VS = ApplicationService.GetService<IVariableService>();
        readonly IRegionService iRS = ApplicationService.GetService<IRegionService>();
        IVariable VWV_RotorDirection;
        IVariable VWV_PlanetDirection;
        IVariable VWV_TiltMode;
        IVariable VWV_AfterStep;
        IVariable VWV_AfterStepH;
        IVariable VWV_AfterStepM;
        IVariable VWV_AfterStepS;

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
                
                VWV_STH = VS.GetVariable("Ergospin.Recipe.Step[" + StepNumber + "].Step_Time.Hour");
                VWV_STH.Change += VWV_ST_Change;
                VWV_STM = VS.GetVariable("Ergospin.Recipe.Step[" + StepNumber + "].Step_Time.Minute");
                VWV_STM.Change += VWV_ST_Change;
                VWV_STS = VS.GetVariable("Ergospin.Recipe.Step[" + StepNumber + "].Step_Time.Second");
                VWV_STS.Change += VWV_ST_Change;


                VWV_RotorDirection = VS.GetVariable("Ergospin.Recipe.Step[" + StepNumber + "].Rotor_direction");
                VWV_RotorDirection.Change += VWV_RotorDirection_Change;
                VWV_PlanetDirection = VS.GetVariable("Ergospin.Recipe.Step[" + StepNumber + "].Planet_direction");
                VWV_PlanetDirection.Change += VWV_PlanetDirection_Change;
                VWV_TiltMode = VS.GetVariable("Ergospin.Recipe.Step[" + StepNumber + "].Swing_Mode");
                VWV_TiltMode.Change += VWV_TiltMode_Change;

                VWV_AfterStep = VS.GetVariable("Ergospin.Recipe.Step[" + StepNumber + "].Kontrolle_nach_Step");
                VWV_AfterStep.Change += VWV_AfterStep_Change;

                VWV_AfterStepH = VS.GetVariable("Ergospin.Recipe.Loop_Time_Hour");
                VWV_AfterStepM = VS.GetVariable("Ergospin.Recipe.Loop_Time_Minute");
                VWV_AfterStepS = VS.GetVariable("Ergospin.Recipe.Loop_Time_Second");

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
        private void Rotor_Click(object sender, RoutedEventArgs e)
        {
            if (ROptions.Width > 90)
            {
                ROptions.BeginAnimation(FrameworkElement.WidthProperty, new DoubleAnimation(ROptions.Width, 90, TimeSpan.FromMilliseconds(200)));

                if ((short)VWV_RotorDirection.Value != Convert.ToInt32(((VisiWin.Controls.Button)sender).Tag)) 
                {
                    VWV_RotorDirection.Value = Convert.ToInt32(((VisiWin.Controls.Button)sender).Tag); 
                }
                else
                {
                    switch (Convert.ToInt32(((VisiWin.Controls.Button)sender).Tag))
                    {
                        case 0:
                            R_B1.SymbolResourceKey = "X"; break;
                        case 1:
                            R_B1.SymbolResourceKey = "RotateRight"; break;
                        case 2:
                            R_B1.SymbolResourceKey = "RotateLeft"; break;
                        case 3:
                            R_B1.SymbolResourceKey = "Rotate"; break;
                    }
                }
            }
            else
            {
                R_B1.SymbolResourceKey = "X";
                ROptions.BeginAnimation(FrameworkElement.WidthProperty, new DoubleAnimation(ROptions.Width, 372, TimeSpan.FromMilliseconds(400)));
                

            }
        }
        private void Planet_Click(object sender, RoutedEventArgs e)
        {
            if (POptions.Width > 90)
            {
                POptions.BeginAnimation(FrameworkElement.WidthProperty, new DoubleAnimation(POptions.Width, 90, TimeSpan.FromMilliseconds(200)));
                if ((short)VWV_PlanetDirection.Value != Convert.ToInt32(((VisiWin.Controls.Button)sender).Tag))
                {
                    VWV_PlanetDirection.Value = Convert.ToInt32(((VisiWin.Controls.Button)sender).Tag);
                }
                else
                {
                    switch (Convert.ToInt32(((VisiWin.Controls.Button)sender).Tag))
                    {
                        case 0:
                            P_B1.SymbolResourceKey = ""; P_B1.Text = "1 : 1,6"; break;
                        case 1:
                            P_B1.SymbolResourceKey = "RotateRight"; P_B1.Text = ""; break;
                        case 2:
                            P_B1.SymbolResourceKey = "RotateLeft"; P_B1.Text = ""; break;
                        case 3:
                            break;
                    }
                }
            }
            else
            {
                POptions.BeginAnimation(FrameworkElement.WidthProperty, new DoubleAnimation(POptions.Width, 354, TimeSpan.FromMilliseconds(400)));
                P_B1.SymbolResourceKey = ""; P_B1.Text = "1 : 1,6";
            }
           
        }
        private void Tilt_Click(object sender, RoutedEventArgs e)
        {
            if (TOptions.Width > 90)
            {
                TOptions.BeginAnimation(FrameworkElement.WidthProperty, new DoubleAnimation(TOptions.Width, 90, TimeSpan.FromMilliseconds(200)));
                if ((short)VWV_TiltMode.Value != Convert.ToInt32(((VisiWin.Controls.Button)sender).Tag))
                {
                    VWV_TiltMode.Value = Convert.ToInt32(((VisiWin.Controls.Button)sender).Tag);
                }
                else
                {
                    switch (Convert.ToInt32(((VisiWin.Controls.Button)sender).Tag))
                    {
                        case 0:
                            T_B1.SymbolResourceKey = "X"; break;
                        case 1:
                            T_B1.SymbolResourceKey = "RotateRight"; break;
                        case 2:
                            break;
                        case 3:
                            T_B1.SymbolResourceKey = "Rotate"; break;
                    }
                }
            }
            else
            {
                TOptions.BeginAnimation(FrameworkElement.WidthProperty, new DoubleAnimation(TOptions.Width, 354, TimeSpan.FromMilliseconds(400)));
                T_B1.SymbolResourceKey = "X";
            }
            
        }
        private void AfterStep_Click(object sender, RoutedEventArgs e)
        {
            if (ASOptions.Width > 90)
            {
                ASOptions.BeginAnimation(FrameworkElement.WidthProperty, new DoubleAnimation(ASOptions.Width, 90, TimeSpan.FromMilliseconds(200)));
            }
            else
            {
                ASOptions.BeginAnimation(FrameworkElement.WidthProperty, new DoubleAnimation(ASOptions.Width, 370, TimeSpan.FromMilliseconds(400)));
            }
            VWV_AfterStep.Value = Convert.ToInt32(((VisiWin.Controls.Button)sender).Tag);
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            step.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
            addView.Visibility = Visibility.Visible;
            addView.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
            steptext.BeginAnimation(ContentControl.MarginProperty, SetMargin(new Thickness(0, steptext.Margin.Top, 0, 0), new Thickness(0, 47, 0, 0), 0.5));
            deletestep.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
            DeleteStepValues();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            sts.Value=1;
            tiltspeed.Value = 1;
        }
       
        private void VWV_ST_Change(object sender, VariableEventArgs e) 
        {
            if (this.IsLoaded)
            {
                if (((int)VWV_STH.Value == 0) && ((int)VWV_STM.Value == 0) && ((int)VWV_STS.Value == 0))
                {
                    Delete_Click(null, null);
                }
                else
                {
                    if (addView.Visibility != Visibility.Hidden)
                        AddStep();
                }

                RecipeAdapter RA = (RecipeAdapter)((Recipe_Main)iRS.GetView("Recipe_Main")).DataContext;
                RA.CalculateTotalTime();
            } 
        }
        private void Speed_ValueChanged(object sender, VisiWin.DataAccess.VariableEventArgs e)
        {
            CalculateRatio();
        }
        #region - - - - VWV Change - - - -
        private void VWV_RotorDirection_Change(object sender, VariableEventArgs e)
        {
            if (e.Value != e.PreviousValue)
            {
                CalculateRatio();
                switch ((short)e.Value)
                {
                    case 0:
                        rotorspeed.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
                        rotortime.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
                        R_B1.SymbolResourceKey = "X";
                        rotorspeed.Value = 0;
                        rth.Value = 0;
                        rtm.Value = 0;
                        rts.Value = 0;
                        break;
                    case 1:
                        rotorspeed.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
                        rotortime.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
                        R_B1.SymbolResourceKey = "RotateRight";
                        rth.Value = 0;
                        rtm.Value = 0;
                        rts.Value = 0;
                        break;
                    case 2:
                        rotorspeed.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
                        rotortime.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
                        R_B1.SymbolResourceKey = "RotateLeft";
                        rth.Value = 0;
                        rtm.Value = 0;
                        rts.Value = 0;
                        break;
                    case 3:
                        rotorspeed.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
                        rotortime.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
                        rtm.Value = 1;
                        R_B1.SymbolResourceKey = "Rotate"; break;
                }
            }
        }
        private void VWV_PlanetDirection_Change(object sender, VariableEventArgs e)
        {
            if (e.Value != e.PreviousValue)
            {
                CalculateRatio();
                switch ((short)e.Value)
                {
                    case 0:
                        planetspeed.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
                        P_B1.SymbolResourceKey = ""; P_B1.Text = "1 : 1,6"; 
                        planetspeed.Value = 0; 
                        break;
                    case 1:
                        planetspeed.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
                        P_B1.SymbolResourceKey = "RotateRight"; P_B1.Text = ""; break;
                    case 2:
                        planetspeed.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
                        P_B1.SymbolResourceKey = "RotateLeft"; P_B1.Text = ""; break;
                }
            }
        }
        private void VWV_TiltMode_Change(object sender, VariableEventArgs e)
        {
            if (e.Value != e.PreviousValue)
            {
                switch ((short)e.Value)
                {
                    case 0:
                        tiltangle1.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
                        tiltangle2.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
                        tilttime.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
                        T_B1.SymbolResourceKey = "X"; 
                        tiltangle1.Value = 0;
                        tiltangle2.Value = 0;
                        tth.Value = 0;
                        ttm.Value = 0;
                        tts.Value = 0;
                        tiltspeed.Value = 1;
                        break;
                    case 1:
                        tiltangle1.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
                        tiltangle2.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
                        tilttime.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
                        T_B1.SymbolResourceKey = "RotateRight";
                        tiltangle2.Value = 0;
                        tth.Value = 0;
                        ttm.Value = 0;
                        tts.Value = 0;
                        break;
                    case 3:
                        tiltangle1.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
                        tiltangle2.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
                        tilttime.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
                        T_B1.SymbolResourceKey = "Rotate";
                        ttm.Value = 1;
                        break;
                }
            }
        }
        private void VWV_AfterStep_Change(object sender, VariableEventArgs e)
        {
            if (e.Value != e.PreviousValue)
            {
                switch ((byte)e.Value)
                {
                    case 0:
                        AS_B1.SymbolResourceKey = "X"; break;
                    case 1:
                        AS_B1.SymbolResourceKey = "Glasses2"; break;
                    case 2:
                        AS_B1.SymbolResourceKey = "Arrows"; break;
                }
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
        private void CalculateRatio() 
        {
            double temp_PS = planetspeed.Value;
            if ((short)VWV_PlanetDirection.Value == 2)
            {
                temp_PS = (planetspeed.Value * -1);
            }

            double temp_RS = rotorspeed.Value;
            if ((short)VWV_RotorDirection.Value == 2)
            {
                temp_RS = (rotorspeed.Value * -1);
            }

            if ((short)VWV_PlanetDirection.Value == 0) 
            {
                if ((short)VWV_RotorDirection.Value == 1)
                {
                    rate.Value = "1 : -1,6";
                }
                else 
                {
                    rate.Value = "1 : 1,6";
                }
            }
            else
            {
                if (rotorspeed.Value == 0)
                {
                    rate.Value = "1 : 0,0";
                }
                else 
                {
                    rate.Value = "1 : " + Math.Round(temp_PS / temp_RS, 1).ToString("0.0");
                }
            } 
        }
        private void SetVariables() 
        {
            steptext.LocalizableText = "@RecipeSystem.Text" + (80+ StepNumber).ToString();

            note.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Kommentar#STRING113";

            sth.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Step_Time.Hour";
            stm.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Step_Time.Minute";
            sts.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Step_Time.Second";
            //Ergospin.Recipe.Step[1].Kontrolle_nach_Step
            
            //Ergospin.Recipe.Step[1].Rotor_direction
            rotorspeed.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Rotor_RPM";
            rth.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Rotor_Interval_Time.Hour";
            rtm.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Rotor_Interval_Time.Minute";
            rts.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Rotor_Interval_Time.Second";

            //Ergospin.Recipe.Step[1].Planet_direction
            planetspeed.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Planet_RPM";

            //Ergospin.Recipe.Step[1].Swing_Mode
            tiltangle1.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Swing_to";
            tiltangle2.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Swing_change_between";
            tiltspeed.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Swing_RPM";

            tth.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Swing_Interval_Time.Hour";
            ttm.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Swing_Interval_Time.Minute";
            tts.VariableName = "Ergospin.Recipe.Step[" + StepNumber + "].Swing_Interval_Time.Second";

        }
        private void DeleteStepValues() 
        {
            note.Value = "";

            sth.Value = 0;
            stm.Value = 0;
            sts.Value = 0;
            VWV_AfterStep.Value = 0;

            VWV_RotorDirection.Value = 0;
            rotorspeed.Value = 0;
            rth.Value = 0;
            rtm.Value = 0;
            rts.Value = 0;

            VWV_PlanetDirection.Value = 0;
            planetspeed.Value = 0;

            VWV_TiltMode.Value = 0;
            tiltangle1.Value = 0;
            tiltangle2.Value = 0;
            tiltspeed.Value = 1;
        }

        private void AddStep() 
        {
            addView.Visibility = Visibility.Hidden;
            addView.BeginAnimation(UIElement.OpacityProperty, SetOpacity(0, 0.3));
            step.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));
            steptext.BeginAnimation(ContentControl.MarginProperty, SetMargin(new Thickness(0, steptext.Margin.Top, 0, 0), new Thickness(0, 15, 0, 0), 0.5));
            deletestep.BeginAnimation(UIElement.OpacityProperty, SetOpacity(1, 0.3));

        }
        #endregion

    }
}
