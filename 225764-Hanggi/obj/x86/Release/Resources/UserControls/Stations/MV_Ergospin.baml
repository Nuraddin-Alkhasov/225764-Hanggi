   M S B A M L   `   `   `  ����   225764-Hanggi"    HMI.UserControls.MV_Ergospin   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $��Center=�$��Center=�.��� -     �Name$  A�� J� Opacity$ 0Q�.+�!  VisiWin.Controls.PictureBox  -     Name$	 pic��   SymbolResourceKey$ ErgospinDarkBlue��$	��450��$	��423��$��3q�$��Center=�$��Center=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ White��   Opacity$	 0.7Q�  -   $
 picx��$ Ergospin��$��30��$	��114��$��Right=�$	��Top=�$��
0,111,11,0q�      	FP_Dark_C# �   $	 0.8Q�!  VisiWin.Controls.TextVarOut  -     Name$
 conn��   Value$ Offline��$ 1Q�$��45��$	��104��$��1q�*  $VisiWin.Controls.VariableBaseControl	   CornerRadius$	 3��  FP_Dark#���    FP_Red_Gradient#���  ���	#FFFFFFFF
   TextAlignment$
 Center=�$��Normal"�$��14(�$��0,0,7,35q�$��Bottom=�$��Right=�  -   $ status��$	 Aus��$ 1Q�$��45��$	��104��$��1q�$	 3��#���  #���  ���	#FFFFFFFF$
 Center=�$��Normal"�$��14(�$��0,0,7,82q�$��Bottom=�$��Right=��� $	��Top=�$
��Left=�$��
37,243,0,0q�$	��308��.+�  -   $ recipe��$	 0��   VariableName$ __UNLINKED_BSTR��  TVO_Main#���  $��40��$��13(�   LocalizableLabelText$ @MainView.Text5��  -   $
 step��$	 0��$��0,-1,0,0q�$ __UNLINKED_BSTR��#���  $��40��$��13(�$ @MainView.Text6��� $��40��$��0,-1,0,0q�.+�  -   $ stepresttime��$��40��$	 0��$ __UNLINKED_BSTR��#���  $��13(�$ @MainView.Text8����  �� Orientation$ 
Horizontal=�$��Right=�.+�$  VisiWin.Controls.NumericVarOut  -	     Name$ sh��$��45��$��Center=�$	 0��$��SemiBold"�  NVO_Main#���  
 � Tag$ -��   VisiWin.Controls.TextBlock  $��:��$��Center=�$��15(�$��3,0,3,3q�$��SemiBold"�  -
   $ sm��$��45��$��Center=�$	 0��$��SemiBold"�#���  $ -��  $��:��$��Center=�$��15(�$��3,0,3,3q�$��SemiBold"�  -   $ ss��$��45��$��Center=�   Value$ 55Q�$	 0��$��SemiBold"�#���  $ -��� $��40��$��0,-1,0,0q�.+�  -   $ totalresttime��$ __UNLINKED_BSTR��#���  $	 0��$��40��$��13(�$ @MainView.Text9���� $ 
Horizontal=�$��Right=�.+�  -   $ th��$��45��$��Center=�#���  $	 0��$ -��  $��:��$��Center=�$��15(�$��3,0,3,3q�$��SemiBold"�  -   $ tm��$��45��$��Center=�#���  $	 0��$ -��  $��:��$��Center=�$��15(�$��3,0,3,3q�$��SemiBold"�  -   $ ts��$��45��$��Center=�#���  $	 0��$ -��  VisiWin.Controls.Border    FP_Gray_Gradient#���  $��2q�  FP_Blue_Gradient#���   �� CornerRadius$ 5,5,0,0��$��	37,38,0,0q�$	��308��$
��Left=�$	��Top=�$	��206��   Child. � .+�  VisiWin.Controls.Gauge  -     Name$ planet��$	��125��$	��125��$��9(�   RawLimitMax$	 250Q�   RawLimitMin$
 -250Q�  RealisticGaugeStyle_2#���  $
��Left=�$��Center=�   LocalizableUnitText$ 
@Units.Rpm��$ @MainView.Text11��+	  %VisiWin.Controls.GraphicalBaseControl 	  Limits 
  VisiWin.Controls.Limit
   
  Fill
 �  �� 
  
StartValue$
 -250Q� 
  EndValue$	 250Q�
  
 � E��$
 -200Q�$	 200Q�
  
 � ���$
 -150Q�$	 150Q�
  
 �/���$
 -100Q�$	 100Q�
  
 � � �$	 -50Q�$ 50Q�  -   $ swing��$	��125��$	��125��$��9(�$	 200Q�$	 -20Q�  RealisticGaugeStyle_3#���  $��Right=�$��Center=�$ @Units.grad��$ @MainView.Text13�� 
  
 �  ��$	 140Q�$	 200Q�
  
 � E��$	 100Q�$	 140Q�
  
 � ���$ 60Q�$	 100Q�
  
 �/���$ 20Q�$ 60Q�
  
 � � �$	 -20Q�$ 20Q�  -   $ rotor��$	��160��$	��160��$��11(�$	 250Q�$
 -250Q� 	 RealisticGaugeStyle_1#��� 	 $��Center=�$��Center=�$ 
@Units.Rpm��$ @MainView.Text12�� 
  
 �  ��$
 -250Q�$	 250Q�
  
 � E��$
 -200Q�$	 200Q�
  
 � ���$
 -150Q�$	 150Q�
  
 �/���$
 -100Q�$	 100Q�
  
 � � �$	 -50Q�$ 50Q�  VisiWin.Controls.Button  -    
 	B_Station#��� 
 $	��460��$	��433��$��Center=�$��Center=�  -     
B_Material#���  $	��316��$��48��$
��Left=�$	��top=�$��
33,239,0,0q�