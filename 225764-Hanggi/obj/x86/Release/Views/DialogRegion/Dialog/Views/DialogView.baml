   M S B A M L   `   `   `  ����   225764-Hanggi'    !HMI.Views.DialogRegion.DialogView   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���   -  'System.Windows.Input.KeyboardNavigation    ControlTabNavigation$
  Once=�   TabNavigation$ Cycle=� � DataContext 0  *VisiWin.Extensions.AdapterBindingExtension     Name$ DialogAdapter��.��� $��Center=�$	��250��$
��1600��$��Center=�.+�  VisiWin.Controls.Border  
������� J� Opacity$	 0.7Q� �� CornerRadius$ 5��$��-5q� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
���   �$��0q�  FP_Dark#���  $ 5��._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��10 �.+�   VisiWin.Controls.TextBlock  -   	  Name$	 
HeaderText��$
��Left=�$��Center=�
�������$��16(�$
��Bold"�
   LocalizableText
 �� *HeaderLocalizableText+���� *
HeaderText+  VisiWin.Controls.Button  -     Name$ CancelButton��$��Right=�$	��Top=�$��Cancel��  B_Close#���  $��80��$��40��   Text$ X��$��0,0,0,0q�y��� *CancelButtonVisible+���� *CloseDialogCommand+�� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� $��2��$ 5��
������ ._�  VisiWin.Controls.Region  -     Name$ 
DialogArea��$��	10,0,10,0q�   ViewName �� *	Content+�� $��3��$��Bottom=�#���  $��2��$ 2��� $��4�� � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+�  -   $ 
LeftButton��$��2��$	��200��$��50��$��0��$
��Left=�$��Center=�$
��Left��  	B_Blue_ns#���  $��	0,10,0,10q� �� *LeftButtonText+   LocalizableText �� *LeftButtonLocalizableText+y��� *LeftButtonVisible+���� *CloseDialogCommand+ �� 	IsDefault �� *LeftButtonIsDefault+  -   $ MiddleButton��$��2��$	��200��$��50��$��1��$��Center=�$��Center=�$��Middle��  	B_Gray_ns#���  $��	0,10,0,10q� �� *MiddleButtonText+ �� *MiddleButtonLocalizableText+y��� *MiddleButtonVisible+���� *CloseDialogCommand+ �� *MiddleButtonIsDefault+  -   $ RightButton��$��2��$	��200��$��50��$��2��$��Right=�$��Center=�$��Right��  B_Red_ns#���  $��	0,10,0,10q� �� *RightButtonText+ �� *RightButtonLocalizableText+y��� *RightButtonVisible+���� *CloseDialogCommand+ �� *RightButtonIsDefault+