   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c   UDNVI_TimePad  �� 
TargetType)   #VisiWin.Controls.UpDownNumericVarIn �� Property  OutputBackgroundBrush �� Value  InputFontBrush*  $VisiWin.Controls.VariableBaseControl  InputBlinkBrush  InputBorderBrush+  %VisiWin.Controls.VariableInputControl  EmptyValidationTemplate �� 
TargetType �Name � RowDefinitions ��Name    IncrementCommand    Delay	 �� Delay
    Interval �� Interval  RepeatIncrementButtonStyle ��Name   CornerRadius �� CornerRadius � ColumnDefinitions%  VisiWin.Controls.NumericTextBox  Name �� SelectionOpacity  VarInTextBoxStyle ! InputSelectionBackgroundBrush �� SelectionBrush   TextAlignment �� TextAlignment "	 ShadowLightDoubleVerticalBrush #
 ShadowDarkDoubleHorizontalBrush    DecrementCommand  RepeatDecrementButtonStyle �� Triggers P� Property P� Value �� 
TargetName�� 5      F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      :x,http://schemas.microsoft.com/winfx/2006/xaml      5      &vwhttp://inosoft.com/visiwin7   5      %P  &	        �� 5      "    6"   .�5   
   ��  � ��# �  6'   �� 5   
    � ��# �  6'   �� 5	   
    �@ 
BlinkBrush# �  6'   �� 5
   
    � ��# �  6(   �� 5   
    � ��$ 1q�6,   �� 5   
    �@ CornerRadius$ 3��6)   �� 5   
    �@ 	LabelText$  ��6&   �� 5   
    � ��$
 10,0q�6$   �� 5   
    � ��$ Segoe UI)�6'   �� 5   
    � ��$ SemiBold"�6'   �� 5   
    � ��$ 16(�6%   �� 5   
    �@ ValidationErrorTemplate# �  64   �� 5   
    � ��$ Center=�65   �� 5   
    � ��$ Right=�67   �� 5   
   ! �@ SymbolHorizontalAlignment$ Right=�66   �� 5   
    �@ TextAlignment$ Right=�6*   �� 5   
    � �� 5      �� 5      "   6"   .R�5      � $
 Grid��6    5      �� 5      $��60 �6,   �� 5      $��50 �6,   �� 5      $��60 �6,   .+�5       �� $ PART_ButtonUp��6'   $��1q�6>   #��z 6R   #	 z 6   |�.  # z
 6�   $��0,0,0,4q�6�   #���  6�   �� 5!      $ 
Background��6!   #��z��65   #��z��6a   #��z��6�   # z 6�   $��0,5,0,5q�6�   $��1��6�   ._�5"      �  5#   "   �� 5$   &   $
��Auto �67   �� 5%   &   $��* �67   .+�5'   "   �� $ RoundCorner��6)   #��z��6>   $ 3.5,0,0,3.5��6h     5(   "   $ PART_TextBox��64   $��0q�6J   
������ $��1��6w   $��Normal"�6�   #��z��6�   {�.  #��z��6�   #��z��6"  $	 0.3Q�6F  #���  6]  # �  6�  # z 6�  #��z��6�  �� 5*   "   $ VerticalInputShadow��6)   #��� 	 6F   $	��0,4q�6�   $��1��6�   # z 6�   �� 5+   "   $ HorizontalInputShadowLeft��6)   #��� 
 6L   $��4,0,0,0q�6�   $��1��6�   �� 5,   "   $  HorizontalInputShadowRight��6)   #��� 
 6M   $��0,0,4,0q�6�   $��1��6�   # z 6�   {�. 6�   5-      5.      �� 5/      $ PART_ButtonDown��6'   $��1q�6@   #��z 6T   #	 z 6�   |�.  # z
 6�   $��3��6�   #���  6�   51       52      P� 53       � {� .  . �54      �� $ 
Background��68    �@J�Opacity$	 0.3Q�6P   55      58      5:      5;      5<      