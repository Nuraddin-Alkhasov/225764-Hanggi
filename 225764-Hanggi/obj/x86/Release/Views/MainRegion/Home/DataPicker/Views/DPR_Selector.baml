   M S B A M L   `   `   `  ����   225764-Hanggi'    !HMI.Views.MainRegion.DPR_Selector   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Z VVisiWin7.System.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241cX TVisiWin7.View.WPF, Version=7.2.0.0, Culture=neutral, PublicKeyToken=3d70d0e64510241c&vwhttp://inosoft.com/visiwin7   $
��1920��$
��1080��   DialogSurroundBrush#���   .��� -   $��Center=�$��Center=�$
��1100��.+�  VisiWin.Controls.Border  
�������  J� Opacity$	  0.7Q� �� CornerRadius$ 5��$��-5q� J� Effect -  'System.Windows.Media.Effects.BlurEffect     Radius$ 10Q��� 
���   �$��0q�  FP_Dark#���  $ 5��$��Center=�$��Center=�._�� $��	10,0,10,0q� � RowDefinitions �� $��70 ��� $��12 ��� $��* ��� $��12 ��� $��70 �.+�   VisiWin.Controls.TextBlock  -     Name$ 
HeaderText��$
��Left=�$��Center=�
�������$��16(�$
��Bold"�   LocalizableText$ @RecipeSystem.Text52��$	��400��  VisiWin.Controls.Button  -     Name$ CancelButton��$��Right=�$	��Top=�  B_Close#���  $��80��$��40��   Text$ X��$��0,0,0,0q����� *CloseRecipeSelectorCommand+�� $��1��$	��Top=� 
 FP_Red#���  $��2��$ 2���� $��2��$��	10,0,10,0q�.+�� $��1��	 � ColumnDefinitions	 �� $��* ��� $��* � �� $��* ��� $��* �.+�!  VisiWin.Controls.TextVarOut  -   
  Name$
 tbName��  TVO_Main#���  *  $VisiWin.Controls.VariableBaseControl   LocalizableLabelText$ @Extern.Text3��$��0,0,5,0q�   VariableName$ __UNLINKED_BSTR��$��50��   TextLengthMin$ 2Q�   TextLengthMax$ 40Q�$	��Top=�   Value �� *SelectedRecipe.Name+  -   $
 tbParts��$��1��#���  $ @Extern.Text15��$��5,0,0,0q�$ __UNLINKED_BSTR��$��50��$	��Top=� �� *SelectedRecipe.Parts+  -   $
 	tbArticle��$��1��#���  $ @Extern.Text1��$��0,5,5,5q�$ __UNLINKED_BSTR��$��50��$	��Top=� �� *SelectedRecipe.Article+ �� Mode$ TwoWay=�  -   $
 tbDescription��$��1��$��1��#���  $ @RecipeSystem.Text11��$��5,5,0,0q�$ __UNLINKED_BSTR��$��50��$	 113Q�$	��Top=� �� *SelectedRecipe.Note+&   System.Windows.Controls.DataGrid  -     Name$ 
dg_recipes��$	��450��  DG_Standart#���     AutoGenerateColumns .     
IsReadOnly . "   VerticalScrollBarVisibility$ Visible=�$   HorizontalScrollBarVisibility$ Disabled=�$��0,0,0,0q����� *	Recipes+$ TwoWay=� �� SelectedItem �� *SelectedRecipe+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,	  &System.Windows.Controls.DataGridColumn 	  Width5
  /System.Windows.Controls.DataGridLengthConverter$	 200
  	  Header 6  0VisiWin.Extensions.LocalizedTextBindingExtension     LocalizableText$ @RecipeSystem.Text13��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Name+  $	 200
    $ @RecipeSystem.Text14�� �� *	Article+  $	 370
    $ @RecipeSystem.Text12�� �� *Note+    	TB_Center   ElementStyle# [ $ *
    $ @RecipeSystem.Text53�� �� *LastChanged+ �� StringFormat$ dd.MM.yyyy HH:mm:ss��   VisiWin.Controls.TextVarIn  $��50��  TVI_Main#���  $ @RecipeSystem.Text15��$��0,5,0,0q�   Value �� *Filter+$ TwoWay=��� $��3��$��Bottom=�#���  $��2��$ 2��� $��4��	 �� $��* ��� $��* ��� $��* ��� $��* �.+�  -	   $ 
LeftButton��$��0��$	��200��$��50��$
��Left=�$��Center=�  	B_Blue_ns#���     LocalizableText$ @Buttons.Text44������ *SelectMachineRecipe+  -
   $ RightButton��$��3��$	��200��$��50��$��Right=�$��Center=� 	 B_Red_ns#��� 	 $ @Buttons.Text13������ *CloseRecipeSelectorCommand+� $��5��$��-10,0,-10,0q�#���   y��� *	IsLoading+.+�  
�������$	  0.7Q�$ 10��$��	0,100,0,0q�$	��150��$	��290��$��Center=�$��Center=�   $ 10Q���  
 FP_Wait#��� 
 $	  0.7Q�$��	0,100,0,0q�$ 10��$	��140��$	��280��$��3q�
���   �$��Center=�$��Center=�._��� -     ��Name$	  gif��$
��None=�