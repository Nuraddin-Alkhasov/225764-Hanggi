   M S B A M L   `   `   `  ����   225764-Hanggi    HMI.UserControls.E_Step   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   -     >�Name$  _this��.��� -    �Name$ A�� J� Opacity$ 0Q�$��0,6,0,0q�$	��236��$
��1796�� � ColumnDefinitions �� $	��140 ��� $��* �.+�� -   $
 step��$��1��$��Center=�$ 0Q� � RowDefinitions �� $��60 ��� $��50 ��� $��50 ��� $��50 ��� $��10 � �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+�   VisiWin.Controls.TextVarIn  -     Name$
 note��$��10��$��0,8,3,5q�   TextLengthMax$	 200Q�$��65,0,0,0q�$
��Left=�*  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$ @RecipeSystem.Text28��   TVI_Main#���   �� $��4��$��10��$��3��  FP_Blue_Gradient#���  $��Bottom=�$��0,0,0,0q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  	   Color$	 White��
   	Direction$	
 270Q�   Opacity$ 0Q��� -    ��Name$ steptime��$��0,2,3,2q� �� Orientation$ 
Horizontal=�$��1��$��1��$��0��$��Center=�$��45��.+�#  VisiWin.Controls.NumericVarIn  -     Name$	 sth��$��49��   RawLimitMin$ 0Q�   RawLimitMax$ 99Q�  NVI_Main#���  
 � Tag$ -���� $��:��
�������$��Center=�$��1,0,1,0q�$��20(�$��SemiBold"�  -   $	 stm��$��49��$ 0Q�$ 59Q�#���  $ -���� $��:��
�������$��Center=�$��1,0,1,0q�$��20(�$��SemiBold"�  -   $	 sts��$��49��$ 0Q�$ 59Q�#���  $ -��  -	   $ count��$��1��$��1��$��1��$	��3,2q�$ 0Q�$��45��$ 99999Q�$��Center=�#���    -
   $ speed��$��1��$��1��$��2��$	��3,2q�$ 0Q�$��45��$	 999Q�$��Center=�#���     LocalizableUnitText$ 
@Units.Rpm��  -   $ change��$��1��$��1��$��3��$	��3,2q�$ 0Q�$��45��$ 99Q�$��Center=�#���    -   $ 
dimension1��$��1��$��4��$	��3,2q�   TextLengthMin$ 0Q�$��45��$ 20Q�#���   $��Center=�  -   $ 
dimension2��$��2��$��4��$	��3,2q�$ 0Q�$��45��$ 20Q�#���   $��Center=�  -   $ 
dimension3��$��3��$��4��$	��3,2q�$ 0Q�$��45��$ 20Q�#���   $��Center=�  -   $ weight1��$��1��$��5��$	��3,2q�$ 0Q�$��45��$ 99Q�#���  $��Center=�   FormatString$
 0.00��$ 	@Units.kg��  -   $ weight2��$��2��$��5��$	��3,2q�$ 0Q�$��45��$ 99Q�#���  $��Center=�$
 0.00��$ 	@Units.kg��  -   $ weight3��$��3��$��5��$	��3,2q�$ 0Q�$��45��$ 99Q�#���  $��Center=�$
 0.00��$ 	@Units.kg��  -   $ atype��$��1��$��1��$��6��$	��3,2q�$��45��$ 0Q�$ 10Q�#���   $��Center=�  -   $ aweight1��$��1��$��7��$	��3,2q�$ 0Q�$��45��$
 9999Q�#���  $��Center=�$ @Units.g��  -   $ aweight2��$��2��$��7��$	��3,2q�$ 0Q�$��45��$
 9999Q�#���  $��Center=�$ @Units.g��  -   $ aweight3��$��3��$��7��$	��3,2q�$ 0Q�$��45��$
 9999Q�#���  $��Center=�$ @Units.g��  -   $ ftype1��$��1��$��8��$	��3,2q�$ 0Q�$��45��$ 10Q�#���   $��Center=�  -   $ ftype2��$��2��$��8��$	��3,2q�$ 0Q�$��45��$ 10Q�#���   $��Center=�  -   $ ftype3��$��3��$��8��$	��3,2q�$ 0Q�$��45��$ 10Q�#���   $��Center=�  -   $ fweight1��$��1��$��9��$	��3,2q�$ 0Q�$��45��$
 9999Q�#���  $��Center=�$ 	@Units.ml��  -   $ fweight2��$��2��$��9��$	��3,2q�$ 0Q�$��45��$
 9999Q�#���  $��Center=�$ 	@Units.ml��  -   $ fweight3��$��3��$��9��$	��3,2q�$ 0Q�$��45��$
 9999Q�#���  $��Center=�$ 	@Units.ml���� $��-2q�
������� �� CornerRadius$ 5�� -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q���   FP_Gray_Gradient#���  $ 5��$��3q�#���  $��3,0,3,0q�._��� .+�   VisiWin.Controls.TextBlock  -     Name$ steptext��
�������$��0,75,0,0q�$
��Wrap=� �� TextAlignment$ Center=�$��Center=�$��Center=�$��14(�$��SemiBold"�  -   $ stepnote��$��1��$ 0Q�$��50��$ 0Q�$ 20Q�$��3,20,3,0q�   TextAlignment$ Center=�$��Center=�$��12(�#���     VisiWin.Controls.Button  -     Name$ 
deletestep��$	��108��$��2��$��3,10,3,0q�$ 0Q�  B_Red_ns#���     LocalizableText$ @Buttons.Text9��� -   $ addView��$��1��$��13��$��2��$ 1Q�$y�Visible=�$��1,1,3,1q�.+��� 
������   FP_Red_Gradient#���  $��2�� �� StrokeDashArray$ 4R� �� RadiusX$ 5�� �� RadiusY$ 5��  -    $ Addbtn��   SymbolResourceKey$ D_Add��$��0q�  B_Dashboard_Add#���  