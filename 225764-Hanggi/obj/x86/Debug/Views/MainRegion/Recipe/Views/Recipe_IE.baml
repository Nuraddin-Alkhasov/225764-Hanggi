   M S B A M L   `   `   `  ����  225764-Hanggi$    HMI.Views.MainRegion.Recipe_IE   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      $
��1920��5      $
��1080��6      DialogSurroundBrush#���   6   .��5      � $
��1000��6   $	��691��6   .+�5   
     VisiWin.Controls.Border  
�������  J� Opacity$	  0.7Q�6(    �� CornerRadius$ 5��66   $��-5q�6G    J� Effect 5	      -  'System.Windows.Media.Effects.BlurEffect  5
         Radius$ 10Q�6   5      �� 5   
   
���   �$��0q�6'     FP_Dark#���  6<   $ 5��6c   ._�5      � .+�5      � $��	10,0,10,0q�6    � RowDefinitions 5      �� 5      $��70 �6(   �� 5      $��12 �6(   �� 5      $��* �6(   �� 5      $��12 �6(   �� 5      $��70 �6(   .+�5         VisiWin.Controls.TextBlock  -   5          Name$ 
HeaderText��5   #   $
��Left=�67   $��Center=�6R   
�������$��16(�6�   $
��Bold"�6�      LocalizableText$ @RecipeSystem.IE.Text13��6�   $	��400��6�     VisiWin.Controls.Button  5      -   5          Name$ CancelButton��5       $��Right=�66   $	��Top=�6R     B_Close#���  6j   $��80��6�   $��40��6�      Text$ X��6�   $��0,0,0,0q�6�   ��6�   �� *CloseDialogViewCommand+6�   �� 5      $��1��6   $	��Top=�6*    
 FP_Red#���  6B   $��2��6i   $ 2��6t   �� 5      -   5        $��2��5   !   	 �� TabStripPlacement$
	 Left=�6.   $��	10,0,10,0q�6G   
���   �$��1q�6n   .@�5      �� -   5        
 ��Name$

 btn1��5   "   $	��263��61   $	��160��6>     	TI_Filter#���  6J   $��0,-3,0,0q�6�   ��6o   /  )VisiWin.Extensions.LocalizedTextExtension     LocalizedText$ @RecipeSystem.IE.Text2��.��5      &   System.Windows.Controls.DataGrid  -   5          Name$ toImport��5   '     DG_Standart#���  6a   $��2q�6�     FP_BorderBrush#���  6�      AutoGenerateColumns .     
IsReadOnly .  
 DGR_IE   RowStyle# �  6�   "   VerticalScrollBarVisibility$ Visible=�6  $   HorizontalScrollBarVisibility$ Disabled=�6B  ��69   �� *RecipesToImport+   Columns 5   "   4  .System.Windows.Controls.DataGridTemplateColumn  5    &   ,  &System.Windows.Controls.DataGridColumn   Width5	  /System.Windows.Controls.DataGridLengthConverter$	 150	 6�      Header 6=   6
  0VisiWin.Extensions.LocalizedTextBindingExtension
   
  LocalizableText$ @RecipeSystem.IE.Text5��   CellTemplate 5!   *   �� 5"   .   .R�5#   2     VisiWin.Controls.CheckBox  $��Center=�6>   $��35��6[   $��35��6f    d� 	IsChecked 6r   ��  �� Path$ 
isSelected� �� UpdateSourceTrigger$ PropertyChanged=�5$   /   5&   '     5'   &   $	 150	 6�    6=   
  $ @RecipeSystem.Text16�� 5(   *   �� 5)   .   .R�5*   2     -   5        $��Center=�5*   <     	B_Gray_ns#���  6z   $��70��6�   $��35��6�   {�6Y   �� *
isExisting+6�   5+   /   5-   '   0  *System.Windows.Controls.DataGridTextColumn  5.   &   $	 150	 6�    69   
  $ @RecipeSystem.IE.Text15��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6�   �� *Type+6�     50   &   $ *	 6�    69   
  $ @RecipeSystem.IE.Text14�� 6�   �� *Name+6�   52      53      �� 54      -   5        $

 btn2��54   "   $	��264��61   $	��160��6>   #���  6J   $��0,-3,0,0q�6�   ��6o     $ @RecipeSystem.IE.Text3��.��55        -   5        $ toExport��55   '   #���  6a   $��2q�6�   #���  6�   # �  6�    .   . $ Visible=�6  $ Disabled=�6B  ��69   �� *RecipesToExport+ 56   "     57   &   $	 150	 6�    6=   
  $ @RecipeSystem.IE.Text5�� 58   *   �� 59   .   .R�5:   2     $��Center=�6>   $��35��6[   $��35��6f    6r   �� $ 
isSelected�$ PropertyChanged=�5;   /   5=   '     5>   &   $	 150	 6�    69   
  $ @RecipeSystem.IE.Text15�� 6�   �� *Type+6�     5?   &   $ *	 6�    69   
  $ @RecipeSystem.IE.Text14�� 6�   �� *Name+6�   5A      5B      5C      �� 5D      $��3��6   $��Bottom=�6*   #���  6E   $��2��6l   $ 2��6w   � 5F      $��4��6    � ColumnDefinitions 5G      �� 5H      $��* �6/   �� 5I      $��* �6/   �� 5J      $��* �6/   �� 5K      $��* �6/   .+�5M        -	   5        $ sopen��5M   $   $��0��63   $��50��6g   $	��200��6t      LocalizableText$ @RecipeSystem.IE.Text11��6�   $��Center=�6�    	 	B_Blue_ns#��� 	 6�   $��0��6�   ��6D   �� *SelectSCommand+6�     5O      -
   5        $ fopen��5O   $   $��1��63   $��50��6f   $	��200��6s   $ @RecipeSystem.IE.Text12��6   $��Center=�6�   #��� 	 6�   $��1��6�   ��6C   �� *SelectFCommand+6�     5P      -   5        $	 imp��5P   $   $��3��61   $��50��6c   $	��200��6p   $ @RecipeSystem.IE.Text2��6|    
 B_Red_ns#��� 
 6�   $��2��6�   ��6A   �� *ImportCommand+6�     5Q      -   5        $	 exp��5Q   $   $��3��61   $��50��6d   $	��200��6q   $ @RecipeSystem.IE.Text3��6}   #��� 	 6�   $��2��6�   ��6B   �� *ExportCommand+6�   5S      5U      5W      5X      � 5Y   
   $��5��6   $��0,0,0,0q�6    #���   62   y�6e   �� *	IsLoading+.+�5Z        
�������$	  0.7Q�6,   $ 10��6:   $��0,0,0,0q�6L   $	��150��6^   $	��290��6k   $��Center=�6w   $��Center=�6�    5[        5\      $ 10Q�6!   5^      �� 5_        FP_Wait#���  6   $	  0.7Q�6=   $��0,0,0,0q�6K   $ 10��6]   $	��140��6o   $	��280��6|   $��3q�6�   
���   �$��Center=�6�   $��Center=�6�   ._�5`      �� -   5         ��Name$	 gif��5`      $
��None=�6%   5a      5c      5d      5e      