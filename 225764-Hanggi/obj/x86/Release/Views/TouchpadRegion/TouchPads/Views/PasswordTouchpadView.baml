   M S B A M L   `   `   `  ����   225764-Hanggi    HMI.PasswordTouchpadView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   -  'System.Windows.Input.KeyboardNavigation    ControlTabNavigation$
  Once=�   TabNavigation$ Cycle=�$��Center=�$��Center=�.��� $
��1920��$
��1080��   DialogSurroundBrush#���   .+��� $
��1000��$	��540��  TouchKeyboardBorderBrush#���  $��1q�  FP_Dark#���   �� CornerRadius$ 5��$��Center=�$��Center=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect    ShadowDarkBottomColor   Color# �  ._�� $��
10,0,10,10q� � RowDefinitions �� $��60 ��� $��* �.+��� -    ��Name$ lblAlphaPadDescription��$
��Left=�$
��Wrap=�
�������$��Center=�$��22(�$��AlphaPad��$	��400��  VisiWin.Controls.Button  -     Name$ CancelButton��$��Right=�$	��Top=�$��Cancel��  B_Close#���  $��60��$��40��   Text$ X��$��0,-1,0,0q�{��� *CancelButtonIsEnabled+y��� *CancelButtonVisible+���� *CloseDialogCommand+�� $��1��  GroupBoxBackgroundBrush#���  $ 4���� $��1��$��10q�.+�$  VisiWin.Controls.PasswordVarIn  -   	  Name$	 passwordVarIn1��+  %VisiWin.Controls.VariableInputControl
   TouchpadMember
 . $��50��*  $VisiWin.Controls.VariableBaseControl   CornerRadius$ 4�� # TouchKeyboardPasswordVarInStyle#���  $��14(�$  VisiWin.Controls.TouchKeyboard  -     Name$ TouchKeyboard��$��TouchKeyboard��  AlphaTouchKeyboard#���  $
��Auto��$
��Auto��$��0,8,0,0q�