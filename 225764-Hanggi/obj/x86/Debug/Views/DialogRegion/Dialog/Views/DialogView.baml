   M S B A M L   `   `   `  ����  225764-Hanggi'    !HMI.Views.DialogRegion.DialogView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      $
��1920��5      $
��1080��6      DialogSurroundBrush#���   6!   -  'System.Windows.Input.KeyboardNavigation    ControlTabNavigation$
  Once=�6T      TabNavigation$ Cycle=�6�    � DataContext 5      0  *VisiWin.Extensions.AdapterBindingExtension  5	   
      Name$ DialogAdapter��6   .��5      � $��Center=�6   $	��250��6&   $
��1600��66   $��Center=�6F   .+�5   
     VisiWin.Controls.Border  
������� J� Opacity$	 0.7Q�6(    �� CornerRadius$ 5��66   $��-5q�6G    J� Effect 5      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6   5      �� 5   
   
���   �$��0q�6'     FP_Dark#���  6;   $ 5��6b   ._�5      � $��	10,0,10,0q�6    � RowDefinitions 5      �� 5      $��70 �6$   �� 5      $��12 �6$   �� 5      $��* �6$   �� 5      $��12 �6$   �� 5      $��10 �6$   .+�5         VisiWin.Controls.TextBlock  -   5        	  Name$	 
HeaderText��5      $
��Left=�6�   $��Center=�6�   
�������$��16(�6�   $
��Bold"�6�   
   LocalizableText
 63   �� *HeaderLocalizableText+��6e   �� *
HeaderText+6�     VisiWin.Controls.Button  5      -   5          Name$ CancelButton��5      $��Right=�62   $	��Top=�6N   $��Cancel��6�     B_Close#���  6�   $��80��6�   $��40��6�      Text$ X��6  $��0,0,0,0q�6  y�6f   �� *CancelButtonVisible+��6�   �� *CloseDialogCommand+6  �� 5      $��1��6   $	��Top=�6&    
 FP_Red#���  6>   $��2��6e   $ 2��6p   �� 5      $��2��6   $ 5��6&   
������ ._�5         VisiWin.Controls.Region  -   5          Name$ 
DialogArea��5        $��	10,0,10,0q�6Q      ViewName 64   �� *	Content+6Q   5!      �� 5"      $��3��6   $��Bottom=�6&   #���  6A   $��2��6h   $ 2��6s   � 5#      $��4��6    � ColumnDefinitions 5$      �� 5%      $��* �6+   �� 5&      $��* �6+   �� 5'      $��* �6+   .+�5)        -   5        $ 
LeftButton��5)       $��2��64   $	��200��6B   $��50��6N   $��0��6Z   $
��Left=�6j   $��Center=�6�   $
��Left��6F    	B_Blue_ns#���  6�  $��	0,10,0,10q�6�   6�   �� *LeftButtonText+   LocalizableText 6�   �� *LeftButtonLocalizableText+y�6�   �� *LeftButtonVisible+��6  �� *CloseDialogCommand+ �� 	IsDefault 6^  �� *LeftButtonIsDefault+6�    5*      -   5        $ MiddleButton��5*       $��2��66   $	��200��6D   $��50��6P   $��1��6\   $��Center=�6l   $��Center=�6�   $��Middle��6P    	B_Gray_ns#���  6�  $��	0,10,0,10q�6�   6�   �� *MiddleButtonText+ 6�   �� *MiddleButtonLocalizableText+y�6�   �� *MiddleButtonVisible+��6)  �� *CloseDialogCommand+ 6j  �� *MiddleButtonIsDefault+6�    5+      -   5        $ RightButton��5+       $��2��65   $	��200��6B   $��50��6N   $��2��6Z   $��Right=�6j   $��Center=�6�   $��Right��6J    B_Red_ns#���  6�  $��	0,10,0,10q�6�   6�   �� *RightButtonText+ 6�   �� *RightButtonLocalizableText+y�6�   �� *RightButtonVisible+��6#  �� *CloseDialogCommand+ 6c  �� *RightButtonIsDefault+6�  5-      5/      51      53      54      