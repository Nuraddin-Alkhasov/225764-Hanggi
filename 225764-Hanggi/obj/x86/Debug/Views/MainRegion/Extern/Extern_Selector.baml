   M S B A M L   `   `   `  ����  225764-Hanggi*    $HMI.Views.MainRegion.Extern_Selector   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      $
��1920��5      $
��1080��6      DialogSurroundBrush#���   6!   .��5      � -   5        $��Center=�5   4   $��Center=�6Q   $
��1000��6l   .+�5   
     VisiWin.Controls.Border  
�������  J� Opacity$	  0.7Q�6(    �� CornerRadius$ 5��66   $��-5q�6G    J� Effect 5	      -  'System.Windows.Media.Effects.BlurEffect  5
         Radius$ 10Q�6   5      �� 5   
   
���   �$��0q�6'     FP_Dark#���  6;   $ 5��6b   ._�5      � $��	10,0,10,0q�6    � RowDefinitions 5      �� 5      $��70 �6$   �� 5      $��12 �6$   �� 5      $��* �6$   �� 5      $��12 �6$   �� 5      $��70 �6$   .+�5         VisiWin.Controls.TextBlock  -   5          Name$ 
HeaderText��5      $
��Left=�63   $��Center=�6N   
�������$��16(�6|   $
��Bold"�6�      LocalizableText$ @RecipeSystem.Text52��6�   $	��400��6�     VisiWin.Controls.Button  5      -   5          Name$ CancelButton��5      $��Right=�62   $	��Top=�6N     B_Close#���  6f   $��80��6�   $��40��6�      Text$ X��6�   $��0,0,0,0q�6�   ��6�   �� *CloseRecipeSelectViewCommand+6�   �� 5      $��1��6   $	��Top=�6&    
 FP_Red#���  6>   $��2��6e   $ 2��6p   �� 5      $��2��6   $��	10,0,10,0q�6*   .+�5      � $��1��6   	 � ColumnDefinitions	 5      �� 5      $��* �6/   �� 5       $��* �6/    5"      �� 5#      $��* �6,   �� 5$      $��* �6,   .+�5&      !  VisiWin.Controls.TextVarOut  -   5        
  Name$
 tbName��5&   (     TVO_Main#���  68   *  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$ @Extern.Text3��6[   $��0,0,5,0q�6�      VariableName$ __UNLINKED_BSTR��6�   $��50��6�      TextLengthMin$ 2Q�6�      TextLengthMax$ 40Q�6�   $	��Top=�6     Value 6�   �� *SelectedRecipe.Name+6    5'      -   5        $
 tbParts��5'   (   $��1��69   #���  6I   $ @Extern.Text15��6l   $��5,0,0,0q�6�   $ __UNLINKED_BSTR��6�   $��50��6�   $	��Top=�6�    6�   �� *SelectedRecipe.Parts+6�     5)      -   5        $
 tbDescription��5)   (   $��1��6?   $��2��6L   #���  6`   $ @RecipeSystem.Text11��6�   $ __UNLINKED_BSTR��6�   $��50��6�   $	 113Q�6  $	��Top=�6  $��0,5,0,5q�6.   6�   �� *SelectedRecipe.Note+6.  5*      &   System.Windows.Controls.DataGrid  5+      -   5          Name$ 
dg_recipes��5+   ,   $��2��6   $��2q�6@     FP_BorderBrush#���  6T     DG_Standart#���  6�   $	��450��6�      AutoGenerateColumns .     
IsReadOnly . "   VerticalScrollBarVisibility$ Visible=�6;  $   HorizontalScrollBarVisibility$ Disabled=�6a  ��6�   �� *	Recipes+ �� Mode$ TwoWay=� �� SelectedItem 6�   �� *SelectedRecipe+   Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	 200
 6�    	  Header 61   6  0VisiWin.Extensions.LocalizedTextBindingExtension     LocalizableText$ @RecipeSystem.Text13��1  +System.Windows.Controls.DataGridBoundColumn   Binding 6y   �� *Name+6�     5.      $	 370
 6�    61     $ @RecipeSystem.Text12�� 6y   �� *Note+6�     5/        	TB_Center   ElementStyle# [ 6�   $ *
 6�    61     $ @RecipeSystem.Text53�� 6y   �� *LastChanged+ �� StringFormat$ dd.MM.yyyy HH:mm:ss��6�   51         VisiWin.Controls.TextVarIn  52      $��3��6#     TVI_Main#���  6\   $ @RecipeSystem.Text15��6   $��50��6�   $��0,5,0,0q�6�      Value 60   �� *RecipeFilter+$ TwoWay=�6�   53      �� 54      $��3��6   $��Bottom=�6&   #���  6A   $��2��6h   $ 2��6s   � 56      $��4��6   	 57      �� 58      $��* �6+   �� 59      $��* �6+   �� 5:      $��* �6+   �� 5;      $��* �6+   .+�5=        -   5        $ 
LeftButton��5=   0   $��0��6    $	��200��6E   $��50��6Q    	 	B_Blue_ns#��� 	 6]      LocalizableText$ @Buttons.Text44��6�   ��6�   �� *SelectMachineRecipeCommand+  5>      -	   5        $ RightButton��5>   0   $��4��6    $	��200��6F   $��50��6R    
 B_Red_ns#��� 
 6^   $ @Buttons.Text13��6�   ��6�   �� *CloseRecipeSelectViewCommand+6�   5@      5B      5C      � 5D   
   $��5��6   $��0,0,0,0q�6    #���   62   y�6e   �� *	IsLoading+.+�5E        
�������$	  0.7Q�6,   $ 10��6:   $��0,0,0,0q�6L   $	��150��6^   $	��290��6k   $��Center=�6w   $��Center=�6�    5F        5G      $ 10Q�6!   5I      �� 5J        FP_Wait#���  6   $	  0.7Q�6=   $��0,0,0,0q�6K   $ 10��6]   $	��140��6o   $	��280��6|   $��3q�6�   
���   �$��Center=�6�   $��Center=�6�   ._�5K      �� -
   5          ��Name$	  gif��5K      $
��None=�6%   5L      5M      5N      5O      