   M S B A M L   `   `   `  ����  225764-Hanggi/    )HMI.Views.MessageBoxRegion.MessageBoxView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      $
��1920��5      $
��1080��6#      DialogSurroundBrush#���   61   -  'System.Windows.Input.KeyboardNavigation    ControlTabNavigation$
  Once=�6d      TabNavigation$ Cycle=�6�    � DataContext 5	      0  *VisiWin.Extensions.AdapterBindingExtension  5
   
      Name$ DialogAdapter��6   .��5      �� $	��520��6   $	��250��6   $
��1600��6,   $	��800��6<   $��Center=�6L   $��Center=�6i   
���   �$��1q�6�     FP_Dark#���  6�    �� CornerRadius$ 5��6�   .  (System.Windows.Interactivity.Interaction   	Behaviors 5   
   /  )VisiWin.Controls.MouseDragElementBehavior  5         ConstrainToParentBounds . 6*    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5        ShadowDarkBottomColor   Color# �  6   ._�5   
   � $��	10,0,10,0q�6   	 � RowDefinitions	 5      �� 5      $��70 �6    �� 5      $��12 �6    �� 5      $��* �6    �� 5      $��12 �6    �� 5      $��70 �6    .+�5         VisiWin.Controls.TextBlock  -   5        
  Name$
 
HeaderText��5      $
��Left=�6/   $��Center=�6J   $	��400��6e   
�������$��18(�6�   $
��Bold"�6�      LocalizableText 6�   �� *HeaderLocalizableText+��6�   �� *
HeaderText+�� 5      $��1��6   $	��Top=�6"    
 FP_Red#���  6:   $��2��6a   $ 2��6l   �� 5      $��2��6   $��	10,0,10,0q�6"   $	��600��65   $ 5��6E     MainViewBackgroundBrush#��[ 6V   ._�5       � -   5         �Name$ MessageArea��5       $��Center=�6-   $��Center=�6J   $��10q�6e   .+�5!      &   VisiWin.Controls.SymbolPresenter  -   5          Name$ MessageIcon��5!   )   $
��Left=�6V   $��Center=�6q      Symbol 6>   �� *Icon+y�6�   �� *IconVisible+  5"      -   5        $
 MessageText��5"   #   $��16(�6Q     DialogForegroundBrush#���  6_   $��60,0,0,0q�6�   $
��Left=�6�   $��Center=�6�   ��68   �� *	Content+6�   5#      5$      �� 5&      $��3��6   $��Bottom=�6"   #���  6=   $��2��6d   $ 2��6o   � 5'      $��4��6    � ColumnDefinitions 5(      �� 5)      $��* �6'   �� 5*      $��* �6'   �� 5+      $��* �6'   .+�5-        VisiWin.Controls.Button  -   5          Name$ 
LeftButton��5-   ,   $��0��6   $	��200��6A   $��50��6M   $
��Left=�6Y   $
��Left��6    	B_Blue_ns#���  6\     Text 6t   �� *LeftButtonText+   LocalizableText 6�   �� *LeftButtonLocalizableText+y�6�   �� *LeftButtonVisible+��6�   �� *CloseDialogCommand+ �� 	IsDefault 62  �� *LeftButtonIsDefault+6\    5.      -   5        $ MiddleButton��5.   ,   $��1��6   $	��200��6C   $��50��6O   $��Center=�6[   $��Middle��6$    	B_Gray_ns#���  6>   6x   �� *MiddleButtonText+ 6�   �� *MiddleButtonLocalizableText+y�6�   �� *MiddleButtonVisible+��6�   �� *CloseDialogCommand+6>    5/      -   5        $ RightButton��5/   ,   $��2��6   $	��200��6B   $��50��6N   $��Right=�6Z   $��Right��6    B_Red_ns#���  6c   6v   �� *RightButtonText+ 6�   �� *RightButtonLocalizableText+y�6�   �� *RightButtonVisible+��6�   �� *CloseDialogCommand+ 68  �� *RightButtonIsDefault+6c  51      52      53      54      