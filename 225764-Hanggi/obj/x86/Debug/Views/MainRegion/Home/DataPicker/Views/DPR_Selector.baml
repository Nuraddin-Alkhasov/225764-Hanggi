   M S B A M L   `   `   `  ����  225764-Hanggi'    !HMI.Views.MainRegion.DPR_Selector   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      $
��1920��5   	   $
��1080��6      DialogSurroundBrush#���   6$   .��5      � -   5        $��Center=�5   4   $��Center=�6Q   $
��1100��6l   .+�5	   
     VisiWin.Controls.Border  
�������  J� Opacity$	  0.7Q�6(    �� CornerRadius$ 5��66   $��-5q�6G    J� Effect 5
      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6   5      �� 5   
   
���   �$��0q�6'     FP_Dark#���  6;   $ 5��6b   $��Center=�6s   $��Center=�6�   ._�5      � $��	10,0,10,0q�6    � RowDefinitions 5      �� 5      $��70 �6$   �� 5      $��12 �6$   �� 5      $��* �6$   �� 5      $��12 �6$   �� 5      $��70 �6$   .+�5         VisiWin.Controls.TextBlock  -   5          Name$ 
HeaderText��5      $
��Left=�63   $��Center=�6N   
�������$��16(�6|   $
��Bold"�6�      LocalizableText$ @RecipeSystem.Text52��6�   $	��400��6�     VisiWin.Controls.Button  5      -   5          Name$ CancelButton��5      $��Right=�62   $	��Top=�6N     B_Close#���  6f   $��80��6�   $��40��6�      Text$ X��6�   $��0,0,0,0q�6�   ��6�   �� *CloseRecipeSelectorCommand+6�   �� 5      $��1��6   $	��Top=�6&    
 FP_Red#���  6>   $��2��6e   $ 2��6p   �� 5      $��2��6   $��	10,0,10,0q�6*   .+�5      � $��1��6   	 � ColumnDefinitions	 5      �� 5      $��* �6/   �� 5       $��* �6/    5"      �� 5#      $��* �6,   �� 5$      $��* �6,   .+�5&      !  VisiWin.Controls.TextVarOut  -   5        
  Name$
 tbName��5&   (     TVO_Main#���  68   *  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$ @Extern.Text3��6[   $��0,0,5,0q�6�      VariableName$ __UNLINKED_BSTR��6�   $��50��6�      TextLengthMin$ 2Q�6�      TextLengthMax$ 40Q�6�   $	��Top=�6     Value 6�   �� *SelectedRecipe.Name+6    5'      -   5        $
 tbParts��5'   (   $��1��69   #���  6I   $ @Extern.Text15��6l   $��5,0,0,0q�6�   $ __UNLINKED_BSTR��6�   $��50��6�   $	��Top=�6�    6�   �� *SelectedRecipe.Parts+6�     5(      -   5        $
 	tbArticle��5(   (   $��1��6;   #���  6H   $ @Extern.Text1��6k   $��0,5,5,5q�6�   $ __UNLINKED_BSTR��6�   $��50��6�   $	��Top=�6   6�   �� *SelectedRecipe.Article+ �� Mode$ TwoWay=�6    5)      -   5        $
 tbDescription��5)   (   $��1��6?   $��1��6L   #���  6\   $ @RecipeSystem.Text11��6   $��5,5,0,0q�6�   $ __UNLINKED_BSTR��6�   $��50��6  $	 113Q�6  $	��Top=�6#   6�   �� *SelectedRecipe.Note+6#  5*      &   System.Windows.Controls.DataGrid  5+      -   5          Name$ 
dg_recipes��5+       $	��450��64     DG_Standart#���  6A      AutoGenerateColumns .     
IsReadOnly . "   VerticalScrollBarVisibility$ Visible=�6�   $   HorizontalScrollBarVisibility$ Disabled=�6  $��0,0,0,0q�6:  ��6g   �� *	Recipes+$ TwoWay=� �� SelectedItem 6�   �� *SelectedRecipe+   Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	 200
 6�    	  Header 61   6  0VisiWin.Extensions.LocalizedTextBindingExtension     LocalizableText$ @RecipeSystem.Text13��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6y   �� *Name+6�     5.      $	 200
 6�    61     $ @RecipeSystem.Text14�� 6y   �� *	Article+6�     5/      $	 370
 6�    61     $ @RecipeSystem.Text12�� 6y   �� *Note+6�     50        	TB_Center   ElementStyle# [ 6�   $ *
 6�    61     $ @RecipeSystem.Text53�� 6y   �� *LastChanged+ �� StringFormat$ dd.MM.yyyy HH:mm:ss��6�   52         VisiWin.Controls.TextVarIn  53      $��50��6I     TVI_Main#���  6U   $ @RecipeSystem.Text15��6x   $��0,5,0,0q�6�      Value 6#   �� *Filter+$ TwoWay=�6�   55      �� 58      $��3��6   $��Bottom=�6&   #���  6A   $��2��6h   $ 2��6s   � 5:      $��4��6   	 5;      �� 5<      $��* �6+   �� 5=      $��* �6+   �� 5>      $��* �6+   �� 5?      $��* �6+   .+�5A        -	   5        $ 
LeftButton��5A   0   $��0��6    $	��200��6E   $��50��6Q   $
��Left=�6]   $��Center=�6x     	B_Blue_ns#���  6�      LocalizableText$ @Buttons.Text44��6�   ��6�   �� *SelectMachineRecipe+  5B      -
   5        $ RightButton��5B   0   $��3��6    $	��200��6F   $��50��6R   $��Right=�6^   $��Center=�6z    	 B_Red_ns#��� 	 6�   $ @Buttons.Text13��6�   ��6�   �� *CloseRecipeSelectorCommand+5C      5D      5E      � 5F   
   $��5��6   $��-10,0,-10,0q�6    #���   66   y�6i   �� *	IsLoading+.+�5G        
�������$	  0.7Q�6,   $ 10��6:   $��	0,100,0,0q�6L   $	��150��6`   $	��290��6m   $��Center=�6y   $��Center=�6�    5H        5I      $ 10Q�6!   5K      �� 5L       
 FP_Wait#��� 
 6   $	  0.7Q�6=   $��	0,100,0,0q�6K   $ 10��6_   $	��140��6q   $	��280��6~   $��3q�6�   
���   �$��Center=�6�   $��Center=�6�   ._�5M      �� -   5          ��Name$	  gif��5M      $
��None=�6%   5N      5P      5R      5S      