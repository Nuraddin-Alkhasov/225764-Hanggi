   M S B A M L   `   `   `  ����  225764-Hanggi'    !HMI.Views.MainRegion.DPR_EHistory   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      $
��1920��5      $
��1080��6      DialogSurroundBrush#���   6!   .��5      � $
��1520��6   $	��680��6   .+�5   
     VisiWin.Controls.Border  
�������  J� Opacity$	  0.7Q�6(    �� CornerRadius$ 5��66   $��-5q�6G    J� Effect 5	      -  'System.Windows.Media.Effects.BlurEffect  5
         Radius$ 10Q�6   5      �� 5   
     TouchKeyboardBorderBrush#���  6   $��0q�6K     FP_Dark#���  6_   $ 5��6�    5      3  -System.Windows.Media.Effects.DropShadowEffect  5        ShadowDarkBottomColor   Color# �  6#   ._�5      � -   5        $��
10,0,10,10q�5       � RowDefinitions 5      �� 5      $��70 �6$   �� 5      $��12 �6$   �� 5      $��* �6$   �� 5      $��12 �6$   .+�5         VisiWin.Controls.TextBlock  -   5          Name$ 
HeaderText��5         LocalizableText$ @RecipeSystem.Text10��63   $	��400��6Z   $
��Left=�6g   $��Center=�6�   $��16(�6�   
�������$
��Bold"�6�     VisiWin.Controls.Button  5      -   5          Name$ CancelButton��5      $��Right=�62   $	��Top=�6N     B_Close#���  6�   $��80��6�   $��40��6�   	   Text$	 X��6�   ��6f   �� *CloseDialogViewCommand+6�   �� 5      $��1��6   $	��Top=�6&    
 FP_Red#���  6>   $��2��6e   $ 2��6p   �� 5      $��2��6   $ 5��6&     MainViewBackgroundBrush#��[ 67   ._�5      � .+�5      �� -   5        
 ��Name$	
 txt��5   "   $��16(�6/    �� 
IsReadOnly . $��SemiBold"�6O   $��	Seagoe UI)�6e   $��10q�6|    �� TextWrapping$
 Wrap=�6�   $��3q�6�   " �� VerticalScrollBarVisibility$ Visible=�6�   .��6�    � 	Resources 5       �� 
TargetType  SmallScrollBarStyle �� BasedOn��%0   '��       7  �� 5    "   " ��6(   8   6I   5!      .��61   5"      5#      5&      �� 5'      $��3��6   $��Bottom=�6&   #���  6A   $��2��6h   $ 2��6s   5)      5,      5-      5.      