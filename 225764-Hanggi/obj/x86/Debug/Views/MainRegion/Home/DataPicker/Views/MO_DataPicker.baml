   M S B A M L   `   `   `  ����  225764-Hanggi(    "HMI.Views.MainRegion.MO_DataPicker   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   5      $
��1920��5   	   $
��1080��6      DialogSurroundBrush#���   6$   .��5      � -   5          �Name$  
LayoutRoot��5      #���   6   $��Center=�6m   $��Center=�6�   $
��1000��6�   .+�5	   
     VisiWin.Controls.Border  
������� J� Opacity$	 0.7Q�6(    �� CornerRadius$ 5��66   $��-5q�6G    J� Effect 5
      -  'System.Windows.Media.Effects.BlurEffect  5         Radius$ 10Q�6   5      �� 5   
   
���   �$��0q�6%     FP_Dark#���  69   $ 5��6`   ._�5      � $��	10,0,10,0q�6    � RowDefinitions 5      �� 5      $��70 �6$   �� 5      $��12 �6$   �� 5      $��* �6$   �� 5      $��12 �6$   �� 5      $��70 �6$   .+�5         VisiWin.Controls.TextBlock  -   5          Name$ 
HeaderText��5      $
��Left=�63   $��Center=�6N   
�������$��18(�6|   $
��Bold"�6�      LocalizableText$ @MainView.Text10��6�   $	��400��6�     VisiWin.Controls.Button  5      -   5          Name$ CancelButton��5      $��Right=�62   $	��Top=�6N     B_Close#���  6f   $��80��6�   $��40��6�   	   Text$	 X��6�   $��0,0,0,0q�6�   {�6�   �� *IsLoadingNotActive+��6�   �� *CloseDataPickerCommand+�� 5      $��1��6   $	��Top=�6&    
 FP_Red#���  6>   $��2��6e   $ 2��6p   � 5      $��2��6   $��	10,0,10,0q�6%    5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   .+�5       �� .+�5!      � 
 � ColumnDefinitions
 5"      �� 5#   "   $��* �63   �� 5$   "   $
��Auto �63   .+�5&      !  VisiWin.Controls.TextVarOut  -   5          Name$ mr��5&   ,   $��45��68   *  $VisiWin.Controls.VariableBaseControl   VariableName$ __UNLINKED_BSTR��6D     TVO_Main#���  6c      LocalizableLabelText$ @MainView.Text5��6�      TextLengthMin$ 1Q�6�      TextLengthMax$ 40Q�6�      Value 6�   �� *
RecipeName+  5'      $��-5q�6(     
B_Material#���  65   {�6Z   �� *IsLoadingNotActive+��6�   �� *
ShowMRList+  5(      -   5        $ h1��5(   (   $��1��64   $	��160��6f   $��10,0,0,0q�6r      LocalizableText$ @RecipeSystem.Text10��6�     	B_Blue_ns#���  6�   y�6E   �� *	IsHistory+��6�   �� *ShowHistory+6�   5)        5*      -   5        $ parts��5*   (   $��45��67   $��0,5,0,0q�6C   $ __UNLINKED_BSTR��6T   #���  6s   $ @Extern.Text15��6�    6�   �� *RecipeParts+  5,      -   5        $ rd��5,   (   $��45��64   $��0,5,0,0q�6@   $ __UNLINKED_BSTR��6Q   #���  6p   $ @MainView.Text14��6�    6�   �� *
RecipeNote+� 5-      $��0,5,0,0q�6    y�62   �� *IsExternRecipe+
 5.      �� 5/   "   $��* �63   �� 50   "   $
��Auto �63   .+�52        -   5        $ externRecipe��52   ,   $��45��6B   $ __UNLINKED_BSTR��6N   #���  6m   $ @MainView.Text18��6�    6�   �� *ExternRecipe+  53      $��-5q�6(   #���  65   {�6Z   �� *IsLoadingNotActive+��6�   �� *ShowExternRecipe+  54      -	   5        $ h2��54   (   $��1��64   $��10,0,0,0q�6D   $ @RecipeSystem.Text10��6V   #���  6}   $	��160��6�   y�6�   �� *
IsEHistory+��6�   �� *ShowEHistory+6�   56         VisiWin.Controls.TextVarIn  57      -
   5          Name$ bc��57   '   $��45��63   $��0,5,0,5q�6?   $ __UNLINKED_BSTR��6P     TVI_Main#���  6o   $ @Extern.Text1��6�      TextLengthMin$ 0Q�6�      TextLengthMax$ 20Q�6�   {�6�   �� *IsLoadingNotActive+   Value 6  �� *RecipeBarcode+ �� Mode$ TwoWay=�58      )  #VisiWin.Controls.PanoramaNavigation  5:      -   5        $��pn_dp��5:   ,   $��2��69   $	��370��6G      Orientation$ 
Horizontal=�6T    J� IsManipulationEnabled .     PanoramaRegions 5<      %	  VisiWin.Controls.PanoramaRegion	  
  VisiWin.Controls.Region 
  	StartView$ MO_DP_Ergospins_1_8��60   	  5=      $ MO_DP_Ergospins_9_16��61   5?        5@      -   5        $ b1��5@       $��2��6,   $��80��69   $��40��6D   $��Right=�6P   $��Bottom=�6l   $��18(�6�     	B_Gray_ns#���  6�   $		 > >��6�      CornerRadius$ 20,0,0,0��6�   $	 0.7Q�6�   $��0,0,0,0q�6�   6�     5A      -   5        $ b2��5A       $��2��6,   $��80��69   $��40��6D   $
��Left=�6P   $��Bottom=�6k   $��18(�6�   #���  6�   $		 < <��6�   $ 0,20,0,0��6�   $	 0.7Q�6�   $��0,0,0,0q�6�   6  5D      �� 5E      $��3��6   $��Bottom=�6&   #���  6A   $��2��6h   $ 2��6s   � 5F      $��4��6   
 5G      �� 5H      $��* �6+   �� 5I      $��* �6+   .+�5K        -   5        $ 
LeftButton��5K       $	��200��64   $��50��6@   $
��Left=�6L   $��Center=�6g   #���  6�   $��	0,10,0,10q�6�   $ @Buttons.Text10��6�   {�6�   �� *IsLoadingNotActive+��6  �� *
LoadRecipe+  5L      -   5        $ RightButton��5L       $��1��65   $	��200��6E   $��50��6Q   $��Right=�6]   $��Center=�6y    	 B_Red_ns#��� 	 6�   $��	0,10,0,10q�6�   $ @Buttons.Text13��6�   {�6�   �� *IsLoadingNotActive+��6  �� *CloseDataPickerCommand+5M      5N      5O      � 5P   
   #���   6   y�6C   �� *	IsLoading+.+�5Q        
�������$	 0.7Q�6,   $ 10��6:   $��0,0,0,0q�6L   $	��150��6^   $	��290��6k   $��Center=�6w   $��Center=�6�    5R        5S      $ 10Q�6!   5U      �� 5V       
 FP_Wait#��� 
 6   $	 0.7Q�6=   $��0,0,0,0q�6K   $ 10��6]   $	��140��6o   $	��280��6|   $��3q�6�   
���   �$��Center=�6�   $��Center=�6�   ._�5W      �� -   5         ��Name$	 gif��5W      $
��None=�6%   5X      5Z      5[      5]      