   M S B A M L   `   `   `  ����  225764-Hanggi)    #HMI.Views.MainRegion.Recipe_Compare   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      $
��1920��5      $
��1080��6      DialogSurroundBrush#���   6!   .��5      � $	��840��6   $	��698��6   .+�5   
     VisiWin.Controls.Border  
�������  J� Opacity$	  0.7Q�6(    �� CornerRadius$ 5��66   $��-5q�6G    J� Effect 5	      -  'System.Windows.Media.Effects.BlurEffect  5
         Radius$ 10Q�6   5      �� 5   
     TouchKeyboardBorderBrush#���  6   $��0q�6K     FP_Dark#���  6_   $ 5��6�   ._�5      � -   5        $��
10,0,10,10q�5       � RowDefinitions 5      �� 5      $��70 �6(   �� 5      $��12 �6(   �� 5      $��* �6(   �� 5      $��12 �6(   .+�5         VisiWin.Controls.TextBlock  -   5          Name$ 
HeaderText��5   #      LocalizableText$ @RecipeSystem.IE.Text20��67   $	��400��6a   $
��Left=�6n   $��Center=�6�   $��16(�6�   
�������$
��Bold"�6�     VisiWin.Controls.Button  5      -   5          Name$ CancelButton��5       $��Right=�66   $	��Top=�6R     B_Close#���  6�   $��80��6�   $��40��6�      Text$ X��6�   $��0,0,0,0q�6�   ��6j   �� *CloseDialogViewCommand+6�   �� 5      $��1��6   $	��Top=�6*    
 FP_Red#���  6B   $��2��6i   $ 2��6t   �� 5      $��	10,0,10,0q�6   $��2��60   $ 5��6=     MainViewBackgroundBrush#��[ 6N   ._�5      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 toImport��5   #     DG_Standart#���  6W   $��2q�6}     FP_BorderBrush#���  6�   
   AutoGenerateColumns
 .     
IsReadOnly .  
 DGR_IE   RowStyle# �  6�   "   VerticalScrollBarVisibility$ Visible=�6  $   HorizontalScrollBarVisibility$ Disabled=�69  ��65   �� *	Variables+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5   "    	 TB_Right1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle# � 	 6�   ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$	 400	 6�      Header 65   6
  0VisiWin.Extensions.LocalizedTextBindingExtension
   
  LocalizableText$ @RecipeSystem.IE.Text17��   Binding 6�   �� *Name+6�     5   "    
 	TB_Center# � 
 6�   $	 200	 6�    65   
  $ @RecipeSystem.IE.Text18�� 6�   �� *	Forplan+6�     5!   "   # � 
 6�   $ *	 6�    65   
  $ @RecipeSystem.IE.Text19�� 6�   �� *Extern+6�   5#      5&      �� 5'      $��3��6   $��Bottom=�6*   #���  6E   $��2��6l   $ 2��6w   5(      5)      � 5*   
   $��6��6   $��0,0,0,0q�6    #���   62   y�6e   �� *	IsLoading+.+�5+        
�������$	  0.7Q�6,   $ 10��6:   $��0,0,0,0q�6L   $	��150��6^   $	��290��6k   $��Center=�6w   $��Center=�6�    5,        5-      $ 10Q�6!   5/      �� 50        FP_Wait#���  6   $	  0.7Q�6=   $��0,0,0,0q�6K   $ 10��6]   $	��140��6o   $	��280��6|   $��3q�6�   
���   �$��Center=�6�   $��Center=�6�   ._�51      �� -   5         ��Name$	 gif��51      $
��None=�6%   52      53      54      55      